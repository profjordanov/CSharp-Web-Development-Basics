using PizzaForum.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using System.Text;
using System.IO;

namespace PizzaForum.Views.Topics
{
    class Details : IRenderable<DetailsVM>
    {
        public DetailsVM Model
        {
            get; set;
        }

        string IRenderable.Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.GetUserName());

            StringBuilder view = new StringBuilder();
            view.Append("<div class=\"container\">");
            view.Append(this.Model.Topic);
            foreach (var reply in this.Model.Replies)
            {
                view.Append(reply);
            }

            string form = File.ReadAllText(Constants.ContentPath + Constants.ReplyForm);
            form = string.Format(form, this.Model.Topic.Title);
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
    }
}
