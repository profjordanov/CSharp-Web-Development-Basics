using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftStore.ViewModels;

namespace SoftStore.Views.Admin
{
    class All : IRenderable<IEnumerable<AllGameVm>>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderHtml);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavigationLoggedHtml);
            string adminGames = File.ReadAllText(Constants.ContentPath + Constants.AdminGames);

            StringBuilder models = new StringBuilder();
            foreach (AllGameVm allGameVm in Model)
            {
                models.Append(allGameVm);
            }

            adminGames = string.Format(adminGames, models);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(adminGames);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }

        public IEnumerable<AllGameVm> Model { get; set; }
    }
}
