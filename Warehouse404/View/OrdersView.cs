using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Warehouse404.Common;
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
            FillListView();
        }

        public void FillListView()
        {
            RedownloadList();
            AddItemsToList();
        }

        private void RedownloadList()
        {
            orders = databaseMapper.GetOrders();
        }

        private void AddItemsToList()
        {
            var items = new List<ListViewItem>();
            foreach (var order in orders)
            {
                var item =
                    new ListViewItem(new string[] {
                        order.Id.ToString(),
                        order.Date.ToString(),
                        order.Products.Count.ToString(),
                        order.Total.ToString("C", CultureInfo.CurrentCulture) 
                    })
                    { Tag = order.Id, Name = order.Id.ToString() };
                items.Add(item);
            }

            itemsListView.Items.AddRange(items.ToArray());
            Helpers.AutoSizeColumnList(itemsListView);
        }
    }
}
