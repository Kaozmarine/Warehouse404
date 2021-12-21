using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    public class Client
    {
        public int Id { get; set; }

        public bool IsCompany { get; set; }

        public string Name { get; set; } = string.Empty;

        public string EntityNumber { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public  Address Address { get; set; } = new Address();

        public string Description => GetDescription();

        private string GetDescription()
        {
            var typeDesc = IsCompany ? "Firma" : string.Empty;
            var apartmentDesc = string.IsNullOrWhiteSpace(Address.ApartmentNumber)  ? $"/{Address.ApartmentNumber}" : string.Empty;
            return $" {typeDesc} {Name} - {Address.PostalCode} {Address.Town}, {Address.Street} {Address.BuildingNumber}{apartmentDesc}";
        }
    }
}
