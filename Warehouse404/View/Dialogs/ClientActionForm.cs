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
    public partial class ClientActionForm : Form
    {
        public Client Client { get; set; }

        public ClientActionForm(ActionType actionType, Client? client = null)
        {
            InitializeComponent();

            Client = client ?? new Client();
            Configure(actionType);
        }

        private void Configure(ActionType actionType)
        {
            Text = $"{actionType.ToFriendlyString()} klienta";
            addButton.Text = actionType == ActionType.Edit ? "Zapisz" : "Dodaj";

            nameTextBox.Text = Client.Name;
            isCompanyCheckBox.Checked = Client.IsCompany;
            entityNumberTextBox.Text = Client.EntityNumber;
            phoneTextBox.Text = Client.PhoneNumber;
            emailTextBox.Text = Client.EmailAddress;

            townTextBox.Text = Client.Address.Town;
            postalCodeTextBox.Text = Client.Address.PostalCode;
            streetTextBox.Text = Client.Address.Street;
            buildingTextBox.Text = Client.Address.BuildingNumber;
            apartmentTextBox.Text = Client.Address.ApartmentNumber;
        }

        private void PostalCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '-') && (((TextBox)sender).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void EntityNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '+') && (((TextBox)sender).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
