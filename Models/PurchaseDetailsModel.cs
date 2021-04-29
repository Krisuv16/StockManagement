using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class PurchaseDetailsModel
    {
        [Key]
        public int PurchaseDetailID { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual ProductModel PID { get; set; }

        public int PurchaseID { get; set; }
        [ForeignKey("PurchaseID")]
        public virtual PurchaseModel PDID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = ("Required"))]
        public string PurchaseQuantity { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = ("Required"))]
        public string PurchasePrice { get; set; }
    }
}
