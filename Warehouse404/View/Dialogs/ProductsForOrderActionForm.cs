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
    public partial class ProductsForOrderActionForm : Form
    {
        public List<Product> productsInOrder { get; set; } = new List<Product>();
        private int orderId;
        private DatabaseMapper db;

        public ProductsForOrderActionForm(DatabaseMapper db, int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            this.db = db;
            RefreshList();
        }

        private void RefreshList()
        {
            productsInOrder = db.GetProductsInOrder(orderId);
            AddItemsToList(productsInOrder);
        }

        private void AddItemsToList(List<Product> products)
        {
            orderProductsListView.Items.Clear();
            var items = new List<ListViewItem>();
            foreach (var product in products)
            {
                var item =
                    new ListViewItem(new string[] {
                        product.Name,
                        product.OrderCount.ToString(),
                        (product.Price * product.OrderCount).ToString("C", CultureInfo.CurrentCulture)
                    })
                    { Tag = product.ProductInOrderId, Name = product.Name };
                items.Add(item);
            }

            orderProductsListView.Items.AddRange(items.ToArray());
            Helpers.AutoSizeColumnList(orderProductsListView);
        }

        private void OrderProductsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = orderProductsListView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                var selectedProduct = productsInOrder.First(p => p.ProductInOrderId == (int)item.Tag);
                var actionDialog = new OrderProductActionForm(ActionType.Edit, selectedProduct);
                var dialogResult = actionDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    db.UpdateProductInOrder(actionDialog.OrderProduct);
                }
                RefreshList();
            }
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            var actionDialog = new OrderProductActionForm(ActionType.Add);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                db.AddProductInOrder(orderId, actionDialog.OrderProduct);
                RefreshList();
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (orderProductsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var productInOrderId = (int)orderProductsListView.SelectedItems[0].Tag;
            var product = productsInOrder.First(p => p.ProductInOrderId == productInOrderId);

            var dialogResult = MessageBox.Show(this, "Czy na pewno chcesz usunąć ten produkt z zamówienia?",
                            "Usuwanie produktu",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                db.DeleteProductInOrder(product.ProductInOrderId);
                RefreshList();
            }
        }
    }
}
