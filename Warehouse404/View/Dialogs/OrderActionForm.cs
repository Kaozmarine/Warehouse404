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
        private readonly List<Client> clients;

        public OrderActionForm(
            ActionType actionType,
            List<Client> clients,
            Order? order = null)
        {
            InitializeComponent();
            Order = order ?? new Order();
            this.clients = clients;
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
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Order.Client = (Client)clientsComboBox.SelectedItem;
            Order.Status = (OrderStatus)(statusComboBox.SelectedIndex + 1);
        }
    }
}
