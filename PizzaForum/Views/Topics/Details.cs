using System.IO;
using System.Text;
using PizzaForum.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Views.Topics
{
    public class Details : IRenderable<DetailsVM>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.GetUserName());


            StringBuilder view = new StringBuilder();
            view.Append("<div class=\"container\">");
            view.Append(Model.Topic);
            foreach (var reply in Model.Replies)
            {
                view.Append(reply);
            }

            string form = File.ReadAllText(Constants.ContentPath + Constants.ReplyForm);
            form = string.Format(form, Model.Topic.Title);
            view.Append(form);
            view.Append("</div>");


            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(view);
            builder.Append(footer);

            return builder.ToString();

           
        }

        public DetailsVM Model { get; set; }
    }
}