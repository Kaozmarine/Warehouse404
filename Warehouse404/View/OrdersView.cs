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
using Warehouse404.View.Dialogs;

namespace Warehouse404.View
{
    public partial class OrdersView : UserControl
    {
        private DatabaseMapper databaseMapper;
        private List<Order> orders = new();
        private MainForm parent;

        public OrdersView(DatabaseMapper db)
        {
            InitializeComponent();

            parent = (MainForm)Parent;
            databaseMapper = db;
            FillListView();
        }

        public void FillListView()
        {
            itemsListView.Items.Clear();
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            var actionDialog = new OrderActionForm(ActionType.Add);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.AddOrder(actionDialog.Order);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var orderId = (int)itemsListView.SelectedItems[0].Tag;
            var order = orders.First(p => p.Id == orderId);

            var actionDialog = new OrderActionForm(ActionType.Edit, order);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.UpdateOrder(actionDialog.Order);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var orderId = (int)itemsListView.SelectedItems[0].Tag;
            var order = orders.First(p => p.Id == orderId);

            var dialogResult = MessageBox.Show(this, "Czy na pewno chcesz usunąć to zamówienie?",
                            "Usuwanie zamównienia",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                databaseMapper.DeleteOrder(order.Id);
            }
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
