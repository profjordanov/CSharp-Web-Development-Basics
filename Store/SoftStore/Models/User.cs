using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStore.Models
{
    public class User
    {
        public User()
        {
            this.Games = new HashSet<Game>();
            this.Logins = new HashSet<Login>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
