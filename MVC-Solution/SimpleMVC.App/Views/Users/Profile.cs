﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    public class Profile : IRenderable<UserProfileViewModel>
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h2>User: {Model.Username}</h2>");
            sb.AppendLine("<a href=\"/home/index\">Home<a/>");
            sb.AppendLine("<form action=\"profile\" method=\"POST\">");
            sb.AppendLine("Title: <input type=\"text\" name=\"Title\" /></br>");
            sb.AppendLine("Content: <input type=\"text\" name=\"Content\" /></br>");
            sb.AppendLine($"<input type=\"hidden\" name=\"UserId\" value=\"{Model.UserId}\"/>");
            sb.AppendLine("<input type=\"submit\" value=\"Add Note\" />");
            sb.AppendLine("</form>");
            sb.AppendLine("<h5>List of nodes</h5>");
            sb.AppendLine("<ul>");
            foreach (var note in Model.Notes)
            {
                sb.AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li>");
            }

            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        public UserProfileViewModel Model { get; set; }
    }
}
