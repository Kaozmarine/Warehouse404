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
            if (repeatPasswordTextBox.Text == repeatPasswordTextBox.Text)
            {
                MessageBox.Show(this, "TEST?",
                           "TEST",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);
            }
        }
    }
}
