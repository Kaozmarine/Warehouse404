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
using Warehouse404.Common;
using Warehouse404.Model;
using Warehouse404.Persistence;
using Warehouse404.View.Dialogs;

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
            itemsListView.Items.Clear();
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            var actionDialog = new UserActionForm(ActionType.Add);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.AddUser(actionDialog.User);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var userId = (int)itemsListView.SelectedItems[0].Tag;
            var user = users.First(p => p.Id == userId);

            var actionDialog = new UserActionForm(ActionType.Edit, user);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.UpdateUser(actionDialog.User);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var userId = (int)itemsListView.SelectedItems[0].Tag;
            var user = users.First(p => p.Id == userId);

            // Check if we dont want to delete ourselfs...
            if (StateManager.CurrentUser?.Id == user.Id)
            {
                MessageBox.Show(this, "Nie możesz usunąć sam siebie!",
                            "Usuwanie użytkownika",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                return;
            }

            var dialogResult = MessageBox.Show(this, "Czy na pewno chcesz usunąć tego użytkownika?",
                            "Usuwanie użytkownika",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                databaseMapper.DeleteUser(user.Id);
            }
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
