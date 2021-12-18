using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Warehouse404.Model;

namespace Warehouse404.Common
{
    public static class Extensions
    {
        public static string ToFriendlyString(this OrderStatus os)
        {
            switch (os)
            {
                case OrderStatus.New:
                    return "Nowe/przyjęte";
                case OrderStatus.Completed:
                    return "Skompletowane";
                case OrderStatus.Finished:
                    return "Wydane/opłacone";
                default:
                    return os.ToString();
            }
        }

        public static string ToFriendlyString(this Role role)
        {
            switch (role)
            {
                case Role.Owner:
                    return "Właściciel";
                case Role.Warehoouse:
                    return "Magazynier";
                case Role.Store:
                    return "Sprzedawca";
                default:
                    return role.ToString();
            }
        }
    }
}
