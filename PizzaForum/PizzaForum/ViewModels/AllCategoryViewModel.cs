namespace PizzaForum.ViewModels
{
    public class AllCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            string representation = "<tr>\r\n\t\t\t\t" +
                                    $"<td><a href=\"#\">{this.CategoryName}</a></td>\r\n\t\t\t\t" +
                                    $"<td><a href=\"/categories/edit?id={this.Id}\" class=\"btn btn-primary\"/>Edit</a>" +
                                    $"</td>\r\n\t\t\t\t<td><a href=\"/categories/delete?id={this.Id}\" class=\"btn btn-danger\"/>Delete</a></td>\r\n\t\t\t" +
                                    "</tr>";

            return representation;
        }
    }
}
