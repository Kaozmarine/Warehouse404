using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse404.Model
{
    internal class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }
    }
}
