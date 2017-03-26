namespace SoftStore.ViewModels
{
    public class AllGameVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            string representation = "<tr>\r\n" +
                                    $"<td>{this.Title}</td>\r\n" +
                                    $"<td>{this.Size} GB</td>\r\n" +
                                    $"<td>{this.Price} &euro;</td>\r\n" +
                                    "<td>\r\n" +
                                    $"<a href=\"/admin/edit?id={this.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>\r\n" +
                                    $"<a href=\"/admin/delete?id={this.Id}\" class=\"btn btn-danger btn-sm\">Delete</a>\r\n</td>\r\n</tr>";

            return representation;
        }
    }
}
