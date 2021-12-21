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
using Warehouse404.View.Dialogs;

namespace Warehouse404.View
{
    public partial class ClientsView : UserControl
    {
        private DatabaseMapper databaseMapper;
        public List<Client> Clients { get; private set; } = new();

        public ClientsView(DatabaseMapper db)
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
            Clients = databaseMapper.GetClients();
        }

        private void AddItemsToList()
        {
            var items = new List<ListViewItem>();
            foreach (var client in Clients)
            {
                var item =
                    new ListViewItem(new string[] {
                        client.Id.ToString(),
                        client.Name,
                        client.EntityNumber,
                        client.PhoneNumber,
                        client.EmailAddress,
                        client.Address.Town,
                        client.Address.PostalCode,
                        client.Address.Street,
                        client.Address.BuildingNumber,
                        client.Address.ApartmentNumber
                    })
                    { Tag = client.Id, Name = client.Name };
                items.Add(item);
            }

            itemsListView.Items.AddRange(items.ToArray());
            Helpers.AutoSizeColumnList(itemsListView);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var actionDialog = new ClientActionForm(ActionType.Add);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.AddClient(actionDialog.Client);
            }
            FillListView();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var clientId = (int)itemsListView.SelectedItems[0].Tag;
            var client = Clients.First(p => p.Id == clientId);

            var actionDialog = new ClientActionForm(ActionType.Edit, client);
            if (actionDialog.ShowDialog(this) == DialogResult.OK)
            {
                databaseMapper.UpdateClient(actionDialog.Client);
            }
            FillListView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count < 1)
            {
                return;
            }
            var clientId = (int)itemsListView.SelectedItems[0].Tag;
            var client = Clients.First(p => p.Id == clientId);

            var dialogResult = MessageBox.Show(this, "Czy na pewno chcesz usunąć tego klienta?",
                            "Usuwanie klienta",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                databaseMapper.DeleteClient(client.Id);
            }
            FillListView();
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
