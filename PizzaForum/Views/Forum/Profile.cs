using PizzaForum.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.IO;
using System.Text;

namespace PizzaForum.Views.Forum
{
    class Profile : IRenderable<ProfileVM>
    {
        public ProfileVM Model
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

            string profile = File.ReadAllText(Constants.ContentPath + "profile-mine.html");
            

            StringBuilder topics = new StringBuilder();
            foreach (var topic in this.Model.Topics)
            {
                topics.Append("<tr>");
                topics.Append(topic.ToString());
                if (this.Model.ClickeUserId == this.Model.CurrentUserId)
                {
                    topics.Append(topic.GetDeleteButton());
                }

                topics.Append("</tr>");
            }

            profile = string.Format(profile, this.Model.ClickedUsername, topics);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(profile);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
