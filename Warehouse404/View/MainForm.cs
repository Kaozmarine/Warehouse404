using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Warehouse404.BusinessLogic;
using Warehouse404.View.Dialogs;

namespace Warehouse404.View
{
    public partial class MainForm : Form
    {
        private ClientsView clientsView = new ClientsView();
        private MainMenuView menuView = new MainMenuView();
        private OrdersView ordersView = new OrdersView();
        private ProductsView productsView = new ProductsView();
        private UsersView usersView = new UsersView();

        public MainForm()
        {
            InitializeComponent();
        }

        public void Configure()
        {
            // Menu
            splitContainer.Panel1.Controls.Add(menuView);

            // Menu controls
            menuView.OnMenuLoginClick += MenuView_OnMenuLoginClick;
            menuView.OnMenuClientsClick += MenuView_OnMenuClientsClick;
            menuView.OnMenuOrdersClick += MenuView_OnMenuOrdersClick;
            menuView.OnMenuProductsClick += MenuView_OnMenuProductsClick;
            menuView.OnMenuUsersClick += MenuView_OnMenuUsersClick;

            menuView.ConfigureForRole(StateManager.CurrentUser?.Role);

            // View

        }

        private void MenuView_OnMenuUsersClick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuView_OnMenuProductsClick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuView_OnMenuOrdersClick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuView_OnMenuClientsClick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuView_OnMenuLoginClick(object? sender, EventArgs e)
        {
            if (StateManager.CurrentUser is null)
            {
                var loginDialog = new LoginForm();
                if (loginDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Try to login
                }
            }
            else
            {
                // logout
            }
            
        }
    }
}
