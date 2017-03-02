using SimpleMVC.Interfaces;

namespace Shouter.Views.Home
{
    using System.IO;

    public class Login : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/login.html");
        }
    }
}
