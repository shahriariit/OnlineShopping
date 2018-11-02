using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcStore.Models
{
    public class MessageFromCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}