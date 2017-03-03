using System.Net.Mime;

namespace PizzaForum.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
           string representation = $"<form method=\"POST\" action=\"/categories/edit\">\r\n        <label>Name</label>\r\n        <div class=\"form-group\">\r\n            <input type=\"hidden\" hidden=\"hidden\" class=\"form-control\" value=\"{this.Id}\" name=\"categoryId\" />\r\n            <input type=\"text\" class=\"form-control\" value=\"{this.CategoryName}\" name=\"categoryName\" />\r\n        </div>\r\n        <input type=\"submit\" class=\"btn btn-primary\" value=\"Edit Category\" />\r\n    </form>";
            return representation;
        }
    }
}