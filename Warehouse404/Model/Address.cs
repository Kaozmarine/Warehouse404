using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    public class Address
    {
        public int Id { get; set; }

        public string Town { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string BuildingNumber { get; set; } = string.Empty;

        public string ApartmentNumber { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;
    }
}
