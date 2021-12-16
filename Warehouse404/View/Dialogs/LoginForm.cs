using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse404.View.Dialogs
{
    public partial class LoginForm : Form
    {
        public string Login { get => loginTextBox.Text; }
        public string Password { get => passwordTextBox.Text; }

        public LoginForm()
        {
            InitializeComponent();
        }
    }
}
