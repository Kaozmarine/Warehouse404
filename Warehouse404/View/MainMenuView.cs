using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Warehouse404.Model;

namespace Warehouse404.View
{
    public partial class MainMenuView : UserControl
    {
        public event EventHandler? OnMenuProductsClick;
        public event EventHandler? OnMenuClientsClick;
        public event EventHandler? OnMenuOrdersClick;
        public event EventHandler? OnMenuUsersClick;
        public event EventHandler? OnMenuLoginClick;

        public MainMenuView()
        {
            InitializeComponent();
        }

        public void ConfigureForRole(Role? role)
        {
            switch (role)
            {
                case Role.Store:
                    clientsButton.Visible = true;
                    ordersButton.Visible = true;
                    productsButton.Visible = true;
                    usersButton.Visible = false;
                    break;
                case Role.Warehoouse:
                    clientsButton.Visible = false;
                    ordersButton.Visible = true;
                    productsButton.Visible = true;
                    usersButton.Visible = false;
                    break;
                case Role.Owner:
                    clientsButton.Visible = true;
                    ordersButton.Visible = true;
                    productsButton.Visible = true;
                    usersButton.Visible = true;
                    break;
                default:
                    clientsButton.Visible = false;
                    ordersButton.Visible = false;
                    productsButton.Visible = false;
                    usersButton.Visible = false;
                    break;
            }
        }

        public void ChangeLoginButtonStatus(bool isLoggedIn)
        {
            loginButton.Text = isLoggedIn ? "Wylogowanie" : "Logowanie";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            OnMenuLoginClick?.Invoke(sender, e);   
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            OnMenuUsersClick?.Invoke(sender, e);
        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            OnMenuClientsClick?.Invoke(sender, e);
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            OnMenuProductsClick?.Invoke(sender, e);
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            OnMenuOrdersClick?.Invoke(sender, e);
        }
    }
}
