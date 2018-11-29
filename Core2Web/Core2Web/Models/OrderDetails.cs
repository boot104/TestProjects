using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core2Web.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        public string ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
