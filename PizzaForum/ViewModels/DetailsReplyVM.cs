﻿using System;

namespace PizzaForum.ViewModels
{
    public class DetailsReplyVM
    {
        public string AuthorName { get; set; }

        public string Content { get; set; }

        public DateTime? PublishDate { get; set; }

        public string ImageUrl { get; set; }
        public override string ToString()
        {
            string representation = $"<div class=\"thumbnail reply\">\r\n\t<h5><strong><a href=\"#\">{this.AuthorName}</a><strong> {this.PublishDate}</h5>\r\n\t<p>{this.Content}</p>\r\n";
            if (!string.IsNullOrEmpty(this.ImageUrl))
            {
                representation += $"\t<img src=\"{this.ImageUrl}\" />";
            }
            representation += "</div>";
            return representation;
        }
    }
}