using System.Collections.Generic;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Views.Topics
{
    public class New : IRenderable<IEnumerable<string>>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.GetUserName());
            string topic = File.ReadAllText(Constants.ContentPath + Constants.TopicNew);

            StringBuilder options = new StringBuilder();
            foreach (var categoryName in Model)
            {
                options.Append($"<option value=\"{categoryName}\">{categoryName}</option>");

            }
            topic = string.Format(topic, options);

            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(topic);
            builder.Append(footer);
            return builder.ToString();
        }

        public IEnumerable<string> Model { get; set; }
    }
}