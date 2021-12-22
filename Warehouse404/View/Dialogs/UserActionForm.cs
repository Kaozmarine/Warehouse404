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
    public partial class UserActionForm : Form
    {
        public User User { get; }
        private bool canClose = true;

        public UserActionForm(ActionType actionType, User? user = null)
        {
            InitializeComponent();
            User = user ?? new User();

            Configure(actionType);
        }

        private void Configure(ActionType actionType)
        {
            Text = $"{actionType.ToFriendlyString()} użytkownika";
            addButton.Text = actionType == ActionType.Edit ? "Zapisz" : "Dodaj";

            nameTextBox.Text = User.Name;
            loginTextBox.Text = User.Login;
            passwordTextBox.Text = User.Password;
            repeatPasswordTextBox.Text = User.Password;
            roleComboBox.SelectedIndex = (int)User.Role - 1;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text != repeatPasswordTextBox.Text)
            {
                MessageBox.Show(this, "Powtórz hasło aby je zmienić!",
                           "Zmiana hasła",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Question);
                canClose = false;
            }
        }

        private void UserActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose && DialogResult != DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
