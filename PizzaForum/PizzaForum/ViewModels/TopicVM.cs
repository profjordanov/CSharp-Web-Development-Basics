using System;

namespace PizzaForum.ViewModels
{
    public class TopicVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorUsername { get; set; }

        public int RepliesCount { get; set; }

        public DateTime? PublishDate { get; set; }

        public override string ToString()
        {
            string representation = $"<div class=\"thumbnail\">\r\n\t<h4><strong><a href=\"/topics/details?id={this.Id}\">{this.Title}</a><strong> <small><a href=\"#\">{this.CategoryName}</a></small></h4>\r\n\t<p><a href=\"#\">{this.AuthorUsername}</a> | Replies: {this.RepliesCount} | {this.PublishDate}</p>\r\n</div>";

            return representation;
        }
    }
}
