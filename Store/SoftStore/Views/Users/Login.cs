using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using static SoftStore.Constants;

namespace SoftStore.Views.Users
{
    public class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(ContentPath + HeaderHtml);
            string navigation = File.ReadAllText(ContentPath + NavigationNotLoggedHtml);
            string login = File.ReadAllText(ContentPath + LoginHtml);
            string footer = File.ReadAllText(ContentPath + FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(login);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }
    }
}
