using SimpleMVC.Interfaces;

namespace Shouter.Views.Home
{
    using System.IO;

    public class Register:IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/register.html");
        }
    }
}
