using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2Web.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }

        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }

        public string ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
