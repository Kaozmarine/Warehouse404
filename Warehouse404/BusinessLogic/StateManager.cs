using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Warehouse404.Model;

namespace Warehouse404.BusinessLogic
{
    public static class StateManager
    {
        public static User? CurrentUser { get; set; } = null;
    }
}
