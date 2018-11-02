using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcStore.Models
{
    public class Thread
    {
        [Key]
        public int ThreadId { get; set; }
        public DateTime? PostDate { get; set; }
        public string ThreadText { get; set; }
        public string ThreadTitle { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}