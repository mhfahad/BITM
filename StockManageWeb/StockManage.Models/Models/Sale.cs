using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManage.Models.Models
{
    public class Sale
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customers { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public int ProductID { get; set; }
        public Product Products { get; set; }

        public int quantity { get; set; }
        public int MRP { get; set; }
        public int TotalMRP { get; set; }
    }
}
