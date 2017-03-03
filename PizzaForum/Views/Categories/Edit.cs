using PizzaForum.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.IO;
using System.Text;
using static PizzaForum.Constants;

namespace PizzaForum.Views.Categories
{
    class Edit : IRenderable<EditCategoryViewModel>
    {
        public EditCategoryViewModel Model
        {
            get; set;
        }

        public string Render()
        {
            string header = File.ReadAllText(ContentPath + Header);
            string navigation = File.ReadAllText(ContentPath + NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["username"]);
            string editCategory = File.ReadAllText(ContentPath + AdminCategoryEdit);
            editCategory = string.Format(editCategory, this.Model);
            string footer = File.ReadAllText(ContentPath + Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(editCategory);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
