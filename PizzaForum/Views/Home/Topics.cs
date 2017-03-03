using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using PizzaForum.Models;
using PizzaForum.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Views.Home
{
    public class Topics : IRenderable<IEnumerable<TopicVM>>
    {
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
            if (currentUser != null)
            {
                topicsCollection.Append("<a class=\"btn btn-success\" href=\"/topics/new\">New Topic</a>");
            }

            foreach (var vm in Model)
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

        public IEnumerable<TopicVM> Model { get; set; }
    }
}