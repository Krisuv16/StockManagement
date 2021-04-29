using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Customer Name Required!")]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Customer Address Required!")]
        public string CustomerAddress { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Customer Phone Number Required!")]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email Incorrect Format!")]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Customer Gender Type not specified!")]
        public string CustomerGender { get; set; }
    }
}
