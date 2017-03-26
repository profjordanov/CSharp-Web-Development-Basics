using System.Collections.Generic;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftStore.ViewModels;

namespace SoftStore.Views.Home
{
    public class Index : IRenderable<IEnumerable<HomeGameVm>>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.HeaderHtml);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavigationLoggedHtml);
            string home = File.ReadAllText(Constants.ContentPath + Constants.HomeHtml);

            StringBuilder builder = new StringBuilder();
            int counter = 0;
            foreach (HomeGameVm homeGameVm in Model)
            {
                if (counter != 0 && counter % 3 == 0)
                {
                    builder.Append("</div>");
                }
                if (counter % 3 == 0)
                {
                    builder.Append("<div class=\"card-group\">");
                }
                builder.Append(homeGameVm);
                counter++;
            }
            home = string.Format(home, builder);

            string footer = File.ReadAllText(Constants.ContentPath + Constants.FooterHtml);

            StringBuilder finalHtml = new StringBuilder();
            finalHtml.Append(header);
            finalHtml.Append(navigation);
            finalHtml.Append(home);
            finalHtml.Append(footer);

            return finalHtml.ToString();
        }

        public IEnumerable<HomeGameVm> Model { get; set; }
    }
}
