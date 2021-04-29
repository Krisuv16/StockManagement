using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class SalesDetailsModel
    {
        [Key]
        public int SalesDetailsID { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]

        public DateTime? Manufacturedate { get; set; }
        [Required]
        public DateTime? Expirydate { get; set; }


        public int SalesID { get; set; }
        [ForeignKey("SalesID")]

        public virtual SalesModel SID { get; set; }

        public int PurchaseID { get; set; }
        [ForeignKey("PurchaseID")]

        public virtual PurchaseModel PID { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]

        public virtual CustomerModel CID { get; set; }
    }
}
