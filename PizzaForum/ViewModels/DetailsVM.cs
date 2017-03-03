using System.Collections.Generic;

namespace PizzaForum.ViewModels
{
    public class DetailsVM
    {
        public DetailTopicVM Topic { get; set; }

        public IEnumerable<DetailsReplyVM> Replies { get; set; }
    }
}