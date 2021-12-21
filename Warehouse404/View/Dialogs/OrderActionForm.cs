using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Warehouse404.Common;
using Warehouse404.Model;

namespace Warehouse404.View.Dialogs
{
    public partial class OrderActionForm : Form
    {
        public Order Order { get; set; }
        private List<Client> clients;
        private List<Product> products;
        
        public OrderActionForm(
            ActionType actionType,
            Order? order = null, 
            List<Product>? productsIn = null, 
            List<Client>? clientsIn = null)
        {
            InitializeComponent();
            Order ??= new Order();
            clients ??= new List<Client>();
            products ??= new List<Product>();
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
        }

    }
}
