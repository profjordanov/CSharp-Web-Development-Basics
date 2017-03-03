using System.Collections.Generic;

namespace PizzaForum.ViewModels
{
    class DetailsVM
    {
        public DetailTopicVM Topic { get; set; }

        public IEnumerable<DetailsReplyVM> Replies { get; set; }
    }
}
