﻿using SimpleMVC.Interfaces.Generic;

namespace Shouter.Views.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class FeedSigned : IRenderable<List<ShoutViewModel>>
    {
        public string Render()
        {
            string feedSignedInHtml = File.ReadAllText("../../content/feed-signed.html");
            StringBuilder pageBuilder = new StringBuilder();
            foreach (var shoutViewModel in this.Model)
            {
                pageBuilder.Append($@"<div class=""thumbnail"">
			                               <h4>
                                            <strong>
                                             <a href=""/followers/profile?id={shoutViewModel.Author.Id}"">{shoutViewModel.Author.Username}</a>
                                            <strong> 
                                            <small>{shoutViewModel.PostedForTime}</small></h4>
			                            <p>{shoutViewModel.Content}</p>
		                            </div>");
            }
            feedSignedInHtml = feedSignedInHtml.Replace("##feed##", pageBuilder.ToString());
            return feedSignedInHtml;
        }

        public List<ShoutViewModel> Model { get; set; }
    }
}
