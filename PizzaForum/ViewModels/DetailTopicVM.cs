using System;

namespace PizzaForum.ViewModels
{
    public class DetailTopicVM
    {
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public DateTime? PublicDate { get; set; }

        public string Content { get; set; }
        public override string ToString()
        {
            string representation = $"<div class=\"thumbnail\">\r\n\t<h4><strong><a href=\"#\">{this.Title}</a><strong></h4>\r\n\t<p><a href=\"#\">{this.AuthorName}</a> {this.PublicDate}</p>\r\n\t<p>{this.Content}</p>\r\n</div>";
            return representation;
        }
    }
}