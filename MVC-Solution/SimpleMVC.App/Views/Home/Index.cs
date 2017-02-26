using System.Text;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb=  new StringBuilder("<h2>Notes App</h2>");
            sb.AppendLine("<a href=\"/users/all\">All users</a> <a href=\"/users/register\">Register Users</a>");

            return sb.ToString();
        }
    }
}
