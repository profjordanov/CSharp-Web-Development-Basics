namespace PizzaForum.Views.Forum
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.ContentPath + Constants.Register);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(register);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
