using SimpleMVC.Interfaces;
using System.IO;
using System.Text;
using System.Collections.Generic;
using PizzaForum.ViewModels;

namespace PizzaForum.Views.Home
{
    public class Topics : SimpleMVC.Interfaces.Generic.IRenderable<IEnumerable<TopicVM>>
    {
        public IEnumerable<TopicVM> Model
        {
            get; set;
        }

        string IRenderable.Render()
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

            if (currentUser != null)
            {
                topicsCollection.Append("<a class=\"btn btn-success\" href=\"/topics/new\">New Topic</a>");
            }

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
