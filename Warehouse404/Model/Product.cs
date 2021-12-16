using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    internal class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string CatalogNumber { get; set; }

        public string Category { get; set; }

        public int Count { get; set; }

        public float Price { get; set; }

        public int Rack { get; set; }

        public int Shelf { get; set; }
    }
}
