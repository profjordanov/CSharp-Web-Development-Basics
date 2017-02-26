using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    class All : IRenderable<IEnumerable<AllUsersViewModel>>
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3> All users</h3>");
            sb.AppendLine("<a href=\"/home/index\">Home<a/>");
            sb.AppendLine("<ul>");
            foreach (var username in ((IRenderable<IEnumerable<AllUsersViewModel>>)this).Model)
            {
                sb.AppendLine($"<li><a href=\"/users/profile?id={username.Id}\">{username.Username}</a></li>");
            }

            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        IEnumerable<AllUsersViewModel> IRenderable<IEnumerable<AllUsersViewModel>>.Model { get; set; }
    }
}
