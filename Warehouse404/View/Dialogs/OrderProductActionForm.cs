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

namespace Warehouse404.View.Dialogs
{
    public partial class OrderProductActionForm : Form
    {
        public Product OrderProduct { get;set ; } = new Product();

        public OrderProductActionForm(ActionType actionType)
        {
            InitializeComponent();

            Configure(actionType);
        }

        private void Configure(ActionType actionType)
        {
            Text = $"{actionType.ToFriendlyString()} produkt w zamówieniu";
            addButton.Text = actionType == ActionType.Edit ? "Zapisz" : "Dodaj";

            addOrderProduct.productComboBox.Enabled = actionType == ActionType.Add;

            editOrderProduct.productTextBox.Text = OrderProduct.Name;
            editOrderProduct.orderCountNumeric.Value = OrderProduct.OrderCount > 0 ? OrderProduct.OrderCount : 1;
            editOrderProduct.productTotalTextBox.Text = (OrderProduct.OrderCount * OrderProduct.Price).ToString("C", CultureInfo.CurrentCulture);

            editOrderProduct.orderCountNumeric.ValueChanged += 
                (s, e) => editOrderProduct.productTotalTextBox.Text = ((int)editOrderProduct.orderCountNumeric.Value * OrderProduct.Price).ToString("C", CultureInfo.CurrentCulture);

            if (actionType == ActionType.Add)
            {
                AddItemsToList();
                addOrderProduct.productComboBox.SelectedValueChanged += ProductComboBox_SelectedValueChanged;
                addOrderProduct.productComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                addOrderProduct.productComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                
            }

            AddItemsToList();
        }

        private void ProductComboBox_SelectedValueChanged(object? sender, EventArgs e)
        {
            OrderProduct = (Product)addOrderProduct.productComboBox.SelectedItem;
            editOrderProduct.productTextBox.Text = OrderProduct.Name + " :: " + OrderProduct.Price.ToString("C", CultureInfo.CurrentCulture);
            editOrderProduct.orderCountNumeric.Value = 1;
            editOrderProduct.productTotalTextBox.Text = OrderProduct.Price.ToString("C", CultureInfo.CurrentCulture);
        }

        private void AddItemsToList()
        {
            var products = StateManager.MainForm?.GetProducts();

            addOrderProduct.productComboBox.ValueMember = "Id";
            addOrderProduct.productComboBox.DisplayMember = "Description";
            addOrderProduct.productComboBox.DataSource = products;
        }

    }
}
