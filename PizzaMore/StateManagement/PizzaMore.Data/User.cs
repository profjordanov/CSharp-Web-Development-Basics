using System.Collections.Generic;

namespace PizzaMore.Data
{
    public class User
    {
        private ICollection<Pizza> suggestions;

        public User()
        {
            this.Suggestions = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Pizza> Suggestions
        {
            get { return suggestions; }
            set { suggestions = value; }
        }
    }
}
