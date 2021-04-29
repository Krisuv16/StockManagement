using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class StockModel
    {
        [Key]
        public int StockModelID { get; set; }

        public int Quantity { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]

        public virtual ProductModel PID { get; set; }

    }
}
