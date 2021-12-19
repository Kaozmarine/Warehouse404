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

        public OrderActionForm(ActionType actionType, Order? order = null)
        {
            InitializeComponent();
            Order = order ?? new Order();
            Configure(actionType);
        }

        private void Configure(ActionType actionType)
        {
            Text = $"{actionType.ToFriendlyString()} zamówienie";
            addButton.Text = actionType == ActionType.Edit ? "Zapisz" : "Dodaj";
        }
    }
}
