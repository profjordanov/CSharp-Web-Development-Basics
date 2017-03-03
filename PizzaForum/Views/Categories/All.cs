namespace PizzaForum.Views.Categories
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    class All : IRenderable<AllViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["username"]);
            string categories = File.ReadAllText(Constants.ContentPath + Constants.AdminCategories);
            categories = string.Format(categories, this.Model);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(categories);
            builder.Append(footer);

            return builder.ToString();
        }

        public AllViewModel Model { get; set; }
    }
}
