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
using Warehouse404.Persistence;

namespace Warehouse404.View
{
    public partial class UsersView : UserControl
    {
        private DatabaseMapper databaseMapper;
        private List<User> users = new();

        public UsersView(DatabaseMapper db)
        {
            InitializeComponent();

            databaseMapper = db;
            RedownloadList();
        }

        public void RedownloadList()
        {
            users = databaseMapper.GetUsers();
        }
    }
}
