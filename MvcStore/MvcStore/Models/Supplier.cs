using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcStore.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier Name is required")]
        [StringLength(160), MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Origin is required")]
        [StringLength(160), MinLength(2)]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(160), MinLength(2)]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Delivery is required")]
        [StringLength(160)]
        public string Delivery { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}