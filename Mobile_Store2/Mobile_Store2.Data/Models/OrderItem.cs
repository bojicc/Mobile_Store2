using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store2.Data.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
