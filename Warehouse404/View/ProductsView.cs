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
    public partial class ProductsView : UserControl
    {
        private readonly DatabaseMapper databaseMapper;
        public List<Product> Products { get; private set; } = new();

        public ProductsView(DatabaseMapper db)
        {
            InitializeComponent();

            databaseMapper = db;
            FillListView();
        }

        public void FillListView()
        {
            itemsListView.Items.Clear();
            RedownloadList();
            AddItemsToList(Products);
        }

        private void RedownloadList()
        {
            Products = databaseMapper.GetProducts();
        }

        private void AddItemsToList(List<Product> products)
        {
            var items = new List<ListViewItem>();
            foreach (var product in products)
            {
                var item =
                    new ListViewItem(new string[] {
                        product.Name,
                        product.Manufacturer,
                        product.CatalogNumber,
                        product.Category,
                        product.Count.ToString(),
                        product.Price.ToString("C", CultureInfo.CurrentCulture),
                        product.Rack.ToString(),
                        product.Shelf.ToString() })
                    { Tag = product.Id, Name = product.Name };
                items.Add(item);
            }

            itemsListView.Items.AddRange(items.ToArray());
            Helpers.AutoSizeColumnList(itemsListView);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var actionDialog = new ProductActionForm(ActionType.Add);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.AddProduct(actionDialog.Product);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var productId = (int)itemsListView.SelectedItems[0].Tag;
            var product = Products.First(p => p.Id == productId);

            var actionDialog = new ProductActionForm(ActionType.Edit, product);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.UpdateProduct(actionDialog.Product);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var productId = (int)itemsListView.SelectedItems[0].Tag;
            var product = Products.First(p => p.Id == productId);

            var dialogResult = MessageBox.Show(this, "Czy na pewno chcesz usunąć ten produkt?",
                            "Usuwanie produktu",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                databaseMapper.DeleteProduct(product.Id);
            }
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = string.Empty;
            priceToTextBox.Text = string.Empty;
            priceToTextBox.Text = string.Empty;
            countFromTextBox.Text = string.Empty;
            countToTextBox.Text = string.Empty;

            if (itemsListView.Items.Count != Products.Count)
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
                if (itemsListView.Items.Count != Products.Count)
                {
                    FillListView();
                }
                return;
            }

            var searchResult = Products;
            if (!string.IsNullOrEmpty(nameCondition))
            {
                searchResult = searchResult
                    .Where(p => p.Name.Contains(nameCondition, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            searchResult = searchResult
                .Where(p => 
                    (p.Price >= priceFromCondition && p.Price <= priceToCondition)
                    && (p.Count >= countFromCondition && p.Count <= countToCondition))
                .ToList();

            itemsListView.Items.Clear();
            AddItemsToList(searchResult);
        }
    }
}
