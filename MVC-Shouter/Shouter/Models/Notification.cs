﻿namespace Shouter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        public int Id { get; set; }

        public virtual User ShoutAuthor { get; set; }

        [InverseProperty("Notifications")]
        public virtual ICollection<User> Notified { get; set; }

    }
}
