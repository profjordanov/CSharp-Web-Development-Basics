using SimpleMVC.Interfaces.Generic;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaForum.Views.Home
{
    class Categories : IRenderable<IEnumerable<string>>
    {
        public IEnumerable<string> Model
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

            StringBuilder categoriesCollection = new StringBuilder();
            categoriesCollection.Append("<div class=\"container\">");
            foreach (var item in this.Model)
            {
                categoriesCollection.Append($"<a href=\"/categories/topics?CategoryName={item}\">{item}</a>");
                categoriesCollection.Append("<br>");
            }
            categoriesCollection.Append("</div>");

            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(categoriesCollection);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
