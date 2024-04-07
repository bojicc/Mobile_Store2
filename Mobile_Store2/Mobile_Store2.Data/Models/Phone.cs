using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store2.Data.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
