using System.IO;
using System.Text;
using PizzaForum.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using static PizzaForum.Constants;

namespace PizzaForum.Views.Categories
{
    public class Edit : IRenderable<EditCategoryViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["username"]);
            string editCategories = File.ReadAllText(Constants.ContentPath + Constants.AdminCategoryEdit);
            editCategories = string.Format(editCategories, Model.ToString());
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(editCategories);
            builder.Append(footer);
            return builder.ToString();
        }

        public EditCategoryViewModel Model { get; set; }
    }
}