using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = ("Required"))]
        public string ProductName { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = ("Required"))]
        public string ProductType { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = ("Required"))]
        public string ProductDescription { get; set; }
        public string ProductManufacturer { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID ")]
        public virtual CategoryModel CID { get; set; }

        //issalaeble
        public bool salable { get; set; }
    }
}
