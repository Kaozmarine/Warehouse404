using Dapper;

using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Warehouse404.BusinessLogic;
using Warehouse404.Model;

namespace Warehouse404.Persistence
{
    public class DatabaseMapper
    {
        private string _connectionString;

        public DatabaseMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Login(string login, string password)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"SELECT
                    id_users AS Id,
                    users_name AS Name,
                    users_role AS Role,
                    users_login AS Login
                    FROM users 
                    WHERE users_login=@db_login AND users_password=@db_password
                    LIMIT 1";
                                
                var user = connection.Query<User>(sql, new { db_login = login, db_password = password }).FirstOrDefault();

                if (user is not null)
                {
                    StateManager.CurrentUser = user;
                    result = true;
                }    
            }

            return result;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"SELECT
                    id_users AS Id,
                    users_name AS Name,
                    users_role AS Role,
                    users_login AS Login
                    FROM users 
                    ";

                users = connection.Query<User>(sql).ToList();
            }

            return users;
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"SELECT
                    id_orders AS Id,
                    orders_status AS Status,
                    orders_date AS Date,
                    orders_total AS Total,
                    id_products AS Id,
                    products_name AS Name,
                    products_manufacturer AS Manufacturer,
                    products_catalog_number AS CatalogNumber,
                    products_category AS Category,
                    products_count AS Count,
                    products_price AS Price,
                    products_rack AS Rack,
                    products_shelf AS Shelf,
                    id_clients AS Id,
                    clients_is_company AS IsCompany,
                    clients_name AS Name,
                    clients_entity_number AS EntityNumber,
                    clients_phone_number AS PhoneNumber,
                    clients_email AS EmailAddress,
                    id_addresses AS Id,
                    addresses_town AS Town,
                    addresses_street AS Street,
                    addresses_building_number AS BuildingNumber,
                    addresses_apartment_number AS ApartmentNumber,
                    addresses_postal_code AS PostalCode
                    FROM orders_has_products
                    INNER JOIN orders ON orders_id_orders = id_orders
                    INNER JOIN products ON products_id_products = id_products
                    INNER JOIN clients ON clients_id_clients = id_clients
                    INNER JOIN addresses ON addresses_id_addresses = id_addresses
                    ";

                var orderDictionary = new Dictionary<int, Order>();

                var list = connection.Query<Order, Product, Client, Address, Order>(
                    sql,
                    (order, product, client, address) =>
                    {
                        if (!orderDictionary.TryGetValue(order.Id, out Order? orderEntry))
                        {
                            orderEntry = order;
                            client.Address = address;
                            orderEntry.Client = client;
                            orderEntry.Products = new List<Product>();
                            orderDictionary.Add(orderEntry.Id, orderEntry);
                        }
                        
                        orderEntry.Products.Add(product);
                        return orderEntry;
                    },
                    splitOn: "Id")
                .Distinct()
                .ToList();

                orders = connection.Query<Order>(sql).ToList();
            }

            return orders;
        }

        internal bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        internal bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        internal bool AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"SELECT
                    id_products AS Id,
                    products_name AS Name,
                    products_manufacturer AS Manufacturer,
                    products_catalog_number AS CatalogNumber,
                    products_category AS Category,
                    products_count AS Count,
                    products_price AS Price,
                    products_rack AS Rack,
                    products_shelf AS Shelf
                    FROM products 
                    ";

                products = connection.Query<Product>(sql).ToList();
            }

            return products;
        }

        public List<Client> GetClients()
        {
            var clients = new List<Client>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"SELECT
                    id_clients AS Id,
                    clients_is_company AS IsCompany,
                    clients_name AS Name,
                    clients_entity_number AS EntityNumber,
                    clients_phone_number AS PhoneNumber,
                    clients_email AS EmailAddress,
                    id_addresses AS Id,
                    addresses_town AS Town,
                    addresses_street AS Street,
                    addresses_building_number AS BuildingNumber,
                    addresses_apartment_number AS ApartmentNumber,
                    addresses_postal_code AS PostalCode                    
                    FROM clients
                    INNER JOIN addresses ON addresses_id_addresses = id_addresses
                    ";

                clients = connection.Query<Client, Address, Client>(sql,
                    (client, address) =>
                    {
                        client.Address = address;
                        return client;
                    },
                    splitOn: "Id")
                    .Distinct() 
                    .ToList();
            }

            return clients;
        }
    }
}
