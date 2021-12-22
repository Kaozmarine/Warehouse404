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

        public OrderStatus Status { get; set; } = OrderStatus.New;

        public Client Client { get; set; } = new Client();

        public List<Product> Products { get; set; } = new List<Product>();

        public DateTime Date { get; set; } = DateTime.Now;

        public float Total => !Products.Any() ? 0 : Products.Sum(x => x.OrderCount * x.Price);
    }
}
 