using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftStore.ViewModels;

namespace SoftStore.Views.Admin
{
    public class Edit : IRenderable<EditGameVm>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderHtml);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavigationLoggedHtml);
            string editGame = File.ReadAllText(Constants.ContentPath + Constants.EditGame);

            editGame = string.Format(editGame, Model.Id, Model.Title, Model.Description, Model.ImageThumbnail, Model.Price, Model.Size, Model.Trailer);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(editGame);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }

        public EditGameVm Model { get; set; }
    }
}
