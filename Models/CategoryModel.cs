using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = ("Category Description Required!"))]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = ("Category Description Required!"))]
        public string CategoryDescription { get; set; }
    }
}
