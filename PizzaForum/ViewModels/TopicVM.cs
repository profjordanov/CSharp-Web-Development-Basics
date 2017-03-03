using System;

namespace PizzaForum.ViewModels
{
    public class TopicVM
    {
        public int Id { get; set; }
        public string TopicTitle { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int RepliesCount { get; set; }

        public DateTime? Date { get; set; }
        public override string ToString()
        {
            string representation =
                $"<div class=\"thumbnail\">\r\n\t<h4><strong><a href=\"/topics/details?id={this.Id}\">{this.TopicTitle}</a><strong> <small><a href=\"#\">{this.CategoryName}</a></small></h4>\r\n\t<p><a href=\"#\">{this.AuthorName}</a> | Replies: {this.RepliesCount} | {this.Date}</p>\r\n</div>";
            return representation;
        }
    }
}