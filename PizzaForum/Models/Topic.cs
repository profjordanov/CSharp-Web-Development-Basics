using System;
using System.Collections.Generic;

namespace PizzaForum.Models
{
    public class Topic
    {
        public Topic()
        {
            this.Replies = new HashSet<Replies>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? PublishDate { get; set; }

        public virtual User Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Replies> Replies { get; set; }
    }
}