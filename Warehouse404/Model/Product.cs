using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public string CatalogNumber { get; set; } = string.Empty;

        public string Category { get; set; }  = string.Empty;

        public int Count { get; set; }

        public float Price { get; set; }

        public int Rack { get; set; }

        public int Shelf { get; set; }

        public int OrderCount { get; set; } = 0;
    }
}
