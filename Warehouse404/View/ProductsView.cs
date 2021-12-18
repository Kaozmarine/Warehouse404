using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Warehouse404.Common;
using Warehouse404.Model;
using Warehouse404.Persistence;

namespace Warehouse404.View
{
    public partial class ProductsView : UserControl
    {
        private DatabaseMapper databaseMapper;
        private List<Product> products = new();

        public ProductsView(DatabaseMapper db)
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
            products = databaseMapper.GetProducts();
        }

        private void AddItemsToList()
        {
            var items = new List<ListViewItem>();
            foreach (var product in products)
            {
                var item = 
                    new ListViewItem(new string[] { 
                        product.Name, 
                        product.Manufacturer, 
                        product.CatalogNumber, 
                        product.Category, 
                        product.Count.ToString(), 
                        product.Price.ToString("C", CultureInfo.CurrentCulture), 
                        product.Rack.ToString(), 
                        product.Shelf.ToString() }) 
                    { Tag = product.Id, Name = product.Name };
                items.Add(item);
            }

            itemsListView.Items.AddRange(items.ToArray());
            Helpers.AutoSizeColumnList(itemsListView);
        }
    }
}
