using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Models
{
    //[Bind(Exclude = "ModelId")]
    public class Model
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int ModelId { get; set; }

        [DisplayName("Brand")]
        public int BrandId { get; set; } 

        [DisplayName("Supplier")]
        public int SupplierId { get; set; }

        [DisplayName("Toner")]
        public int TonerId { get; set; } 

        [Required(ErrorMessage = "A Title is required")]
        [DisplayName("Product")]
        [StringLength(160),MinLength(3)]
        public String ProductName { get; set; }

        [Required(ErrorMessage = "Compitible Models are required")]
        [Display(Name = "Compatible Models")]
        public String CompatibleModel { get; set; }

        [Required(ErrorMessage = "Menufacturer is required")]
        [Display(Name = "Manufacturer")]
        [StringLength(160),MinLength(2)]
        public String Manufacturer { get; set; }

        [Required(ErrorMessage = "Origin is required")]
        [Display(Name = "Origin")]
        [StringLength(160),MinLength(2)]
        public String CountryOfOrigin { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public String Status { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [Display(Name = "Type")]
        [StringLength(100),MinLength(2)]
        public String  Type { get; set; }

        [Required(ErrorMessage = "Packaging is required")]
        [Display(Name = "Packaging")]
        [StringLength(100)]
        public String  Packing { get; set; }

        [Required(ErrorMessage = "Delivery is required")]
        [Display(Name = "Delivery")]
        [StringLength(100)]
        public String  Delivery { get; set; }

        [Required(ErrorMessage = "Shipping is required")]
        [Display(Name = "Shipping")]
        [StringLength(100)]
        public String Shipping { get; set; }

        [Required(ErrorMessage = "Parts are required")]
        [Display(Name = "Parts")]
        public String Parts { get; set; }

        [Required(ErrorMessage = "Page/Toner is required")]
        [Display(Name = "Page/Toner")]
        [Range(500,30000)]
        public int PagePerToner { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(typeof(decimal),"0.00","200000.00")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Model Url is required")]
        [DisplayName("Model URL")]
        public String ModelUrl { get; set; }

       //[Required(ErrorMessage = "Model Zoom Url is required")]
        [DisplayName("Model Zoom URL")]
        public String ModelZoomUrl { get; set; }

        [Required(ErrorMessage = "Model Small Url is required")]
        [DisplayName("Model Small URL")]
        public String ModelSmallUrl { get; set; }

        public  virtual Brand Brand { get; set; }
        public  virtual Toner Toner { get; set; }
        public  virtual Supplier Supplier { get; set; }
        public  virtual List<OrderDetail> OrderDetails { get; set; }
    }

}
