using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcStore.Models
{
    public class Toner
    {
        public int TonerId { get; set; }

        [Required(ErrorMessage = "Toners are required")]
        public string Name { get; set; }
    }
}