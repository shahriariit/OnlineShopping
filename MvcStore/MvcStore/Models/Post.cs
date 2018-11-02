using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcStore.Models
{
    public class Post
    { 
        [Key]
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public DateTime? PostDate { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual Thread Thread { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Thread")]
        public int ThreadId { get; set; } 
    }
}