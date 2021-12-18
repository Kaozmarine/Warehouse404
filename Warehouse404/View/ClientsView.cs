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
    public partial class ClientsView : UserControl
    {
        private DatabaseMapper databaseMapper;
        private List<Client> clients = new();

        public ClientsView(DatabaseMapper db)
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
            clients = databaseMapper.GetClients();
        }

        private void AddItemsToList()
        {
            var items = new List<ListViewItem>();
            foreach (var client in clients)
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
            //itemsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Helpers.AutoSizeColumnList(itemsListView);
        }
    }
}
