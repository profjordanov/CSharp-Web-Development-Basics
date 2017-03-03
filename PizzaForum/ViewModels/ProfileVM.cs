using System.Collections.Generic;

namespace PizzaForum.ViewModels
{
    public class ProfileVM
    {
        public string ClickedUsername { get; set; }

        public int ClickeUserId { get; set; }

        public int CurrentUserId { get; set; }

        public IEnumerable<ProfileTopicVM> Topics { get; set; }
    }
}
