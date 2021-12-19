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
            priceTextBox.Text = Product.Price.ToString("C", CultureInfo.CurrentCulture);
            countTextBox.Text = Product.Count.ToString();
            categoryTextBox.Text = Product.Category;
            catalogNumberTextBox.Text = Product.CatalogNumber;
            rackTextBox.Text = Product.Rack.ToString();
            shelfTextBox.Text = Product.Shelf.ToString();
        }
    }
}
