using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    public class Order
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public Client Client { get; set; } = new Client();

        public List<Product> Products { get; set; } = new List<Product>();

        public DateTime Date { get; set; }

        public decimal Total { get; set; }
    }
}
