using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using static SoftStore.Constants;

namespace SoftStore.Views.Users
{
    public class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(ContentPath + HeaderHtml);
            string navigation = File.ReadAllText(ContentPath + NavigationNotLoggedHtml);
            string register = File.ReadAllText(ContentPath + RegisterHtml);
            string footer = File.ReadAllText(ContentPath + FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(register);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }
    }
}
