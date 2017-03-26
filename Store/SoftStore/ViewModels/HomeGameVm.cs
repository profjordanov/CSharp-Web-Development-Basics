using System;

namespace SoftStore.ViewModels
{
    public class HomeGameVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {

            string representation =
                "<div class=\"card col-4 thumbnail\">\r\n\r\n" +
                "<img\r\n" +
                "class=\"card-image-top img-fluid img-thumbnail\"\r\n" +
                $"src=\"{this.ImageThumbnail}\">\r\n\r\n" +
                "<div class=\"card-block\">\r\n" +
                $"<h4 class=\"card-title\">{this.Title}</h4>\r\n" +
                $"<p class=\"card-text\"><strong>Price</strong> - {this.Price}&euro;</p>\r\n" +
                $"<p class=\"card-text\"><strong>Size</strong> - {this.Size} GB</p>\r\n" +
                $"<p class=\"card-text\">{this.Description.Substring(0, 300)}</p>\r\n" +
                "</div>\r\n\r\n" +
                "<div class=\"card-footer\">\r\n " +
                $"<a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/home/details?id={this.Id}\">Info</a>\r\n" +
                "</div>\r\n\r\n" +
                "</div>";

            return representation;
        }
    }
}
