using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Warehouse404.Model;
using Warehouse404.Persistence;

namespace Warehouse404.View
{
    public partial class OrdersView : UserControl
    {
        private DatabaseMapper databaseMapper;
        private List<Order> orders = new();

        public OrdersView(DatabaseMapper db)
        {
            InitializeComponent();

            databaseMapper = db;
            RedownloadList();
        }

        public void RedownloadList()
        {
            orders = databaseMapper.GetOrders();
        }
    }
}
