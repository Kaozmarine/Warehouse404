using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Warehouse404.BusinessLogic;
using Warehouse404.Model;
using Warehouse404.Persistence;
using Warehouse404.View.Dialogs;

namespace Warehouse404.View
{
    public partial class MainForm : Form
    {
        private DatabaseMapper databaseMapper = new DatabaseMapper(ConfigurationManager.ConnectionStrings["Warehouse"].ConnectionString);
        private MainMenuView menuView;
        private ClientsView clientsView;        
        private OrdersView ordersView;
        private ProductsView productsView;
        private UsersView usersView;

        public MainForm()
        {
            InitializeComponent();

            StateManager.MainForm = this;

            menuView = new MainMenuView();
            clientsView =   new ClientsView(databaseMapper);            
            productsView =  new ProductsView(databaseMapper);
            usersView =     new UsersView(databaseMapper);            
            ordersView = new OrdersView(databaseMapper);
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
            clientsView .Dock = DockStyle.Fill;
            ordersView  .Dock = DockStyle.Fill;
            productsView.Dock = DockStyle.Fill;
            usersView   .Dock = DockStyle.Fill;
        }

        public List<Product> GetProducts()
        {
            return productsView.Products;
        }

        public List<Client> GetClients()
        {
            return clientsView.Clients;
        }

        private void MenuView_OnMenuUsersClick(object? sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(usersView);
        }

        private void MenuView_OnMenuProductsClick(object? sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(productsView);
        }

        private void MenuView_OnMenuOrdersClick(object? sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(ordersView);
        }

        private void MenuView_OnMenuClientsClick(object? sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(clientsView);
        }

        private void MenuView_OnMenuLoginClick(object? sender, EventArgs e)
        {
            if (StateManager.CurrentUser is null)
            {
                // Login
                var loginDialog = new LoginForm();
                if (loginDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (databaseMapper.Login(loginDialog.Login, loginDialog.Password))
                    {                        
                        MessageBox.Show(this, $"Zalogowano poprawnie.\nWitaj {StateManager.CurrentUser?.Name}!", 
                            "Status logowania", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                        menuView.ChangeLoginButtonStatus(true);
                    }
                    else
                    {
                        MessageBox.Show(this, $"Logowanie nie udało się!.\nSprawdź czy wpisujesz poprawne dane!", 
                            "Status logowania", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }                                 
                }
            }
            else
            {         
                // Logout
                StateManager.CurrentUser = null;
                MessageBox.Show(this, "Wylogowano poprawnie.",
                            "Status logowania",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                menuView.ChangeLoginButtonStatus(false);
            }
            menuView.ConfigureForRole(StateManager.CurrentUser?.Role);
            splitContainer.Panel2.Controls.Clear();
        }
    }
}
