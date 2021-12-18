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
            FillListView();
        }

        public void FillListView()
        {
            RedownloadList();
            AddItemsToList();
        }

        private void RedownloadList()
        {
            users = databaseMapper.GetUsers();
        }

        private void AddItemsToList()
        {
            var items = new List<ListViewItem>();
            foreach (var user in users)
            {
                var item = new ListViewItem(new string[] { user.Login, user.Name, user.Role.ToFriendlyString() }) { Tag = user.Id, Name = user.Name };
                items.Add(item);
            }

            itemsListView.Items.AddRange(items.ToArray());
            Helpers.AutoSizeColumnList(itemsListView);
        }
    }
}
