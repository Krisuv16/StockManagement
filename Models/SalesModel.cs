using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class SalesModel
    {
        [Key]
        public int SalesModedID { get; set; }

        public DateTime? SalesDate { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual ProductModel CID { get; set; }
    }
}
