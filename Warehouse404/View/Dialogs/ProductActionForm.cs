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

namespace Warehouse404.View.Dialogs
{
    public partial class ProductActionForm : Form
    {
        public Product Product { get; set; }

        public ProductActionForm(ActionType actionType, Product? product = null)
        {
            InitializeComponent();

            Product = product ?? new Product ();
            Configure(actionType);
        }

        private void Configure(ActionType actionType)
        {
            Text = $"{actionType.ToFriendlyString()} produkt";
            addButton.Text = actionType == ActionType.Edit ? "Zapisz" : "Dodaj";

            nameTextBox.Text = Product.Name;
            priceTextBox.Text = Product.Price.ToString("N", CultureInfo.CurrentCulture);
            countTextBox.Text = Product.Count.ToString();
            categoryTextBox.Text = Product.Category;
            catalogNumberTextBox.Text = Product.CatalogNumber;
            rackTextBox.Text = Product.Rack.ToString();
            shelfTextBox.Text = Product.Shelf.ToString();
        }

        private void CountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void RackTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ShelfTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Product.Name = nameTextBox.Text;
            Product.Price = float.TryParse(priceTextBox.Text, out float price) ? price : 0;
            Product.Count = int.TryParse(countTextBox.Text, out int count) ? count : 0;
            Product.CatalogNumber = catalogNumberTextBox.Text;
            Product.Rack = int.TryParse(rackTextBox.Text, out int rack) ? rack : 0;
            Product.Shelf = int.TryParse(shelfTextBox.Text, out int shelf) ? shelf : 0;
        }
    }
}
