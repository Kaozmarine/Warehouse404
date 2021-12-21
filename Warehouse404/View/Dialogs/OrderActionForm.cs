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

namespace Warehouse404.View.Dialogs
{
    public partial class OrderActionForm : Form
    {
        public Order Order { get; set; }
        private List<Client> clients;
        private List<Product> products;
        private OrdersView parent;
        private DatabaseMapper databaseMapper;

        public OrderActionForm(
            DatabaseMapper db,
            ActionType actionType,
            Order? order = null, 
            List<Product>? productsIn = null, 
            List<Client>? clientsIn = null)
        {
            InitializeComponent();
            databaseMapper = db;
            Order ??= new Order();
            clients ??= new List<Client>();
            products ??= new List<Product>();
            parent = (OrdersView)Parent;
            Configure(actionType);
        }

        private void Configure(ActionType actionType)
        {
            var orderNumber = Order.Id > 0 ? Order.Id.ToString() : string.Empty;
            Text = $"{actionType.ToFriendlyString()} zamówienie {orderNumber}";
            addButton.Text = actionType == ActionType.Edit ? "Zapisz" : "Dodaj";

            clientsComboBox.DataSource = clients;
            clientsComboBox.DisplayMember = "Name";
            clientsComboBox.ValueMember = "Id";
            clientsComboBox.SelectedValue = Order.Client.Id;

            dateTextBox.Text = Order.Date.ToString();
            statusComboBox.SelectedIndex = (int)Order.Status - 1;
            totalTextBox.Text = Order.Total.ToString("C", CultureInfo.CurrentCulture);

            AddItemsToList();
        }

        private void AddItemsToList()
        {
            orderProductsListView.Items.Clear();
            var items = new List<ListViewItem>();
            foreach (var product in Order.Products)
            {
                var item =
                    new ListViewItem(new string[] {
                        product.Name,
                        product.OrderCount.ToString(),
                        (product.Price * product.OrderCount).ToString("C", CultureInfo.CurrentCulture)
                    })
                    { Tag = product.Id, Name = product.Name};
                items.Add(item);
            }

            orderProductsListView.Items.AddRange(items.ToArray());
            Helpers.AutoSizeColumnList(orderProductsListView);
        }

        private void OrderProductsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = orderProductsListView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            var orderProductDialog = new OrderProductActionForm(ActionType.Edit);

            if (item != null)
            { 
                var selectedProduct = Order.Products.First(p => p.Id == (int)item.Tag);
                var selectedProductIndex = Order.Products.IndexOf(selectedProduct);
                orderProductDialog.OrderProduct = selectedProduct;
                var dialogResult = orderProductDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    Order.Products[selectedProductIndex] = orderProductDialog.OrderProduct;
                }
            }
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            var actionDialog = new OrderProductActionForm(ActionType.Add);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.AddProductInOrder(Order.Id, actionDialog.OrderProduct);
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (orderProductsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var productId = (int)orderProductsListView.SelectedItems[0].Tag;
            var product = Order.Products.First(p => p.Id == productId);

            var dialogResult = MessageBox.Show(this, "Czy na pewno chcesz usunąć ten produkt z zamówienia?",
                            "Usuwanie produktu",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                databaseMapper.DeleteProductInOrder(Order.Id, product.Id);
            }
        }
    }
}
