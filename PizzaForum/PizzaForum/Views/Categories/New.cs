namespace PizzaForum.Views.Categories
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    public class New : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["username"]);
            string newCategory = File.ReadAllText(Constants.ContentPath + Constants.AdminCategoryNew);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(newCategory);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
