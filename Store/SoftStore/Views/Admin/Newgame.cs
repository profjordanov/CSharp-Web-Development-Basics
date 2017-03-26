using System.IO;
using System.Text;
using SimpleMVC.Interfaces;

namespace SoftStore.Views.Admin
{
    class Newgame : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderHtml);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavigationLoggedHtml);
            string addGame = File.ReadAllText(Constants.ContentPath + Constants.AddGame);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(addGame);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }
    }
}
