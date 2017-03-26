using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces.Generic;
using SoftStore.ViewModels;

namespace SoftStore.Views.Home
{
    public class Details : IRenderable<DetailsGameVm>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderHtml);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavigationLoggedHtml);
            string details = File.ReadAllText(Constants.ContentPath + Constants.DetailsGameHtml);

            details = string.Format(details, Model.Title, Model.Trailer, Model.Description, Model.Price, Model.Size, Model.ReleaseDate, Model.Id);

            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(details);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }

        public DetailsGameVm Model { get; set; }
    }
}
