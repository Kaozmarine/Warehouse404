using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    internal class Client
    {
        public int Id { get; set; }

        public bool IsCompany { get; set; }

        public string Name { get; set; }

        public string EntityNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public  Address Address { get; set; }
    }
}
