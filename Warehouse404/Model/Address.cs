using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    internal class Address
    {
        public int Id { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public string PostalCode { get; set; }
    }
}
