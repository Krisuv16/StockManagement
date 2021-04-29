using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class PurchaseModel
    {
        [Key]
        public int PurchaseID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = ("Purchase Description Required"))]
        public string PurchaseDescription { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = ("Vendor name Required"))]
        public string VendorName { get; set; }
    }
}
