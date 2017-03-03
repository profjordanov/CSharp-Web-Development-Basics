using System.Collections.Generic;

namespace PizzaForum.Models
{
    public class Category
    {
        public Category()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}