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

using Warehouse404.BusinessLogic;
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

        public OrdersView(DatabaseMapper db)
        {
            InitializeComponent();

            databaseMapper = db;
            FillListView();
        }

        public void FillListView()
        {
            itemsListView.Items.Clear();
            RedownloadList();
            AddItemsToList(orders);
        }

        private void RedownloadList()
        {
            orders = databaseMapper.GetOrders();
        }

        private void AddItemsToList(List<Order> ordersList)
        {
            var items = new List<ListViewItem>();
            foreach (var order in ordersList)
            {
                var item =
                    new ListViewItem(new string[] {
                        order.Id.ToString(),
                        order.Status.ToFriendlyString(),
                        order.Date.ToString(),
                        order.Products.Sum(x => x.OrderCount).ToString(),
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
            var actionDialog = new OrderActionForm(ActionType.Add, StateManager.MainForm.GetClients());
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.AddOrder(actionDialog.Order);
                FillListView();
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

            var actionDialog = new OrderActionForm(ActionType.Edit, StateManager.MainForm.GetClients(), order);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.UpdateOrder(actionDialog.Order);
                FillListView();
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
                FillListView();
            }
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var orderId = (int)itemsListView.SelectedItems[0].Tag;
            var order = orders.First(p => p.Id == orderId);

            var actionDialog = new ProductsForOrderActionForm(databaseMapper, order.Id);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                FillListView();
            }
        }

        // Search/filter functionality
        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = string.Empty;
            priceFromTextBox.Text = string.Empty;
            priceToTextBox.Text = string.Empty;
            countFromTextBox.Text = string.Empty;
            countToTextBox.Text = string.Empty;

            if (itemsListView.Items.Count != orders.Count)
            {
                FillListView();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var nameCondition = nameTextBox.Text;
            double priceFromCondition;
            double priceToCondition;
            int countFromCondition;
            int countToCondition;

            if (!double.TryParse(priceFromTextBox.Text, out priceFromCondition))
            {
                priceFromCondition = 0.0;
            }
            if (!double.TryParse(priceToTextBox.Text, out priceToCondition))
            {
                priceToCondition = double.MaxValue;
            }
            if (!int.TryParse(countFromTextBox.Text, out countFromCondition))
            {
                countFromCondition = 0;
            }
            if (!int.TryParse(countToTextBox.Text, out countToCondition))
            {
                countToCondition = int.MaxValue;
            }

            if (string.IsNullOrEmpty(nameCondition) && priceFromCondition == 0.0 && priceToCondition == double.MaxValue && countFromCondition == 0 && countToCondition == int.MaxValue)
            {
                if (itemsListView.Items.Count != orders.Count)
                {
                    FillListView();
                }
                return;
            }

            var searchResult = orders;
            if (!string.IsNullOrEmpty(nameCondition))
            {
                searchResult = searchResult
                    .Where(p => p.Id.ToString().Contains(nameCondition, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            searchResult = searchResult
                .Where(p =>
                    (p.Total >= priceFromCondition && p.Total <= priceToCondition)
                    && (p.Products.Sum(x => x.OrderCount) >= countFromCondition && p.Products.Sum(x => x.OrderCount) <= countToCondition))
                .ToList();

            itemsListView.Items.Clear();
            AddItemsToList(searchResult);
        }
    }
}
