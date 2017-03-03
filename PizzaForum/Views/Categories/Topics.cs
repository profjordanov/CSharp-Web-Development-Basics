using PizzaForum.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaForum.Views.Categories
{
    class Topics : IRenderable<IEnumerable<TopicVM>>
    {
        public IEnumerable<TopicVM> Model
        {
            get; set;
        }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation;
            string currentUser = ViewBag.GetUserName();
            if (currentUser != null)
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
                navigation = string.Format(navigation, currentUser);
            }
            else
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            }
            StringBuilder topicsCollection = new StringBuilder();
            topicsCollection.Append("<div class=\"container\">");

            foreach (var vm in this.Model)
            {
                topicsCollection.Append(vm);
            }

            topicsCollection.Append("</div>");

            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(topicsCollection);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
