using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftStore.ViewModels;

namespace SoftStore.Views.Admin
{
    public class Delete : IRenderable<DeleteGameVm>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderHtml);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavigationLoggedHtml);
            string deleteGame = File.ReadAllText(Constants.ContentPath + Constants.DeleteGame);

            deleteGame = string.Format(deleteGame, Model.Id, Model.Title);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(deleteGame);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }

        public DeleteGameVm Model { get; set; }
    }
}
