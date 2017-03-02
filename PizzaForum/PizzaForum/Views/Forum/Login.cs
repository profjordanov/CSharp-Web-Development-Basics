using System.Text;

namespace PizzaForum.Views.Forum
{
    using System.IO;
    using SimpleMVC.Interfaces;
    class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            string login = File.ReadAllText(Constants.ContentPath + Constants.Login);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(login);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
