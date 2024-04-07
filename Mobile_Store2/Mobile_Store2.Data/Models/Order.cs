using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store2.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public List<OrderItem> OrderItems { get; set; }
    }
}
