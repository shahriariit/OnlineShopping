using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcStore.Models
{
    public class ThreadDetailViewModel
    {
        public int Id { get; set; }
        public Thread Thread { get; set; }
        public Post NewPost { get; set; }
    }
}