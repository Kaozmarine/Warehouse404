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
                    users_login AS Login,
                    users_password AS Password
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
                    users_login AS Login,
                    users_password AS Password
                    FROM users 
                    ";

                users = connection.Query<User>(sql).ToList();
            }

            return users;
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
                    WHERE products_deleted = 0
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

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"SELECT
                    id_orders AS Id,
                    orders_status AS Status,
                    orders_date AS Date,
                    id_products AS Id,
                    products_name AS Name,
                    products_manufacturer AS Manufacturer,
                    products_catalog_number AS CatalogNumber,
                    products_category AS Category,
                    products_count AS Count,
                    products_price AS Price,
                    products_rack AS Rack,
                    products_shelf AS Shelf,
                    orders_has_products_count AS OrderCount,
                    id_orders_has_products AS ProductInOrderId,
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
                    FROM orders
                    LEFT JOIN orders_has_products ON orders_id_orders = id_orders
                    LEFT JOIN products ON products_id_products = id_products
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

                        if (product is not null)
                        {
                            orderEntry.Products.Add(product);
                        } 

                        return orderEntry;
                    },
                    splitOn: "Id")
                .Distinct()
                .ToList();

                orders = list;
            }

            return orders;
        }

        internal List<Product> GetProductsInOrder(int orderId)
        {
            var result = new List<Product>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                SELECT 
                    id_orders_has_products AS ProductInOrderId,
                    orders_has_products_count AS OrderCount,    
                    id_products AS Id,
                    products_name AS Name,
                    products_manufacturer AS Manufacturer,
                    products_catalog_number AS CatalogNumber,
                    products_category AS Category,
                    products_count AS Count,
                    products_price AS Price,
                    products_rack AS Rack,
                    products_shelf AS Shelf
                FROM
                    orders_has_products
                    INNER JOIN products ON products_id_products = id_products
                WHERE
                    orders_id_orders = @order_id;";

                var products = connection.Query<Product>(sql, new { order_id = orderId}).ToList();

                if (products.Any())
                {
                    result = products;
                }
            }

            return result;
        }

        internal bool UpdateProductInOrder(Product orderProduct)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE orders_has_products
                SET
                    orders_has_products_count = @new_count
                WHERE id_orders_has_products = @id;";

                var rowsAffected = connection.Execute(sql, new { 
                    id = orderProduct.ProductInOrderId, 
                    new_count = orderProduct.OrderCount });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        internal bool DeleteProductInOrder(int id)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM orders_has_products
                WHERE id_orders_has_products = @delete_id;";

                var rowsAffected = connection.Execute(sql, new { delete_id = id });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        internal bool AddProductInOrder(int orderId, Product orderProduct)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO orders_has_products
                (orders_id_orders, products_id_products, orders_has_products_count)
                VALUES
                (@id_orders, @id_products, @count);";

                var rowsAffected = connection.Execute(sql, new {
                    id_orders = orderId,
                    id_products = orderProduct.Id,
                    count = orderProduct.OrderCount });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        internal bool AddOrder(Order order)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO orders
                (orders_status, clients_id_clients, orders_date, orders_total)
                VALUES
                (@status, @client_id, @date, 0);";

                var rowsAffected = connection.Execute(sql, new { status = (int)order.Status, client_id = order.Client.Id, date = order.Date });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        internal bool UpdateOrder(Order order)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE orders
                SET
                orders_status = @new_status,
                clients_id_clients = @new_client
                WHERE id_orders = @order_id;";

                var rowsAffected = connection.Execute(sql, new
                {
                    order_id = order.Id,
                    new_status = (int)order.Status,
                    new_client = order.Client.Id
                });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        internal bool DeleteOrder(int id)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM orders
                WHERE id_orders = @delete_id;";

                var rowsAffected = connection.Execute(sql, new { delete_id = id });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool AddUser(User user)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO users
                (users_login, users_password, users_role, users_name)
                VALUES
                (@login, @password, @role, @name);";

                var rowsAffected = connection.Execute(sql, new { login = user.Login, password = user.Password, role = (int)user.Role, name = user.Name});

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool UpdateUser(User user)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE users
                SET
                    users_login = @login,
                    users_password = @password, 
                    users_role = @role, 
                    users_name = @name
                WHERE id_users = @id;";

                var rowsAffected = connection.Execute(sql, new { 
                    id = user.Id,
                    login = user.Login, 
                    password = user.Password, 
                    role = (int)user.Role, 
                    name = user.Name });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool DeleteUser(int id)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM users
                WHERE id_users = @delete_id;";

                var rowsAffected = connection.Execute(sql, new { delete_id = id });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool AddClient(Client client)
        {
            var result = false;
            
            using (var connection = new MySqlConnection(_connectionString))
            {
                string addressSql = @"
                    INSERT INTO addresses
                    (addresses_town, addresses_street, addresses_building_number, addresses_apartment_number, addresses_postal_code)
                    VALUES
                    (@town, @street, @building_number, @apartment_number, @postal_code);
                    SELECT LAST_INSERT_ID();";

                var addressId = connection.QuerySingle<int>(addressSql, 
                    new { 
                        town = client.Address.Town, 
                        street = client.Address.Street, 
                        building_number = client.Address.BuildingNumber, 
                        apartment_number = client.Address.ApartmentNumber, 
                        postal_code = client.Address.PostalCode});

                    
                if (addressId > 0)
                {
                    string clientSql = @"
                    INSERT INTO clients
                    (clients_is_company, clients_name, clients_entity_number, clients_phone_number, clients_email, addresses_id_addresses)
                    VALUES
                    (@is_company, @name, @entity_number, @phone, @email, @id_address);";

                    var clientRowsAffected = connection.Execute(clientSql,
                        new
                        {
                            is_company = client.IsCompany,
                            name = client.Name,
                            entity_number = client.EntityNumber,
                            phone = client.PhoneNumber,
                            email = client.EmailAddress,
                            id_address = addressId
                        });

                    if (clientRowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public bool UpdateClient(Client client)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string clientSql = @"
                UPDATE clients
                SET
                    clients_is_company = @is_company,
                    clients_name = @name,
                    clients_entity_number = @entity_number,
                    clients_phone_number = @phone,
                    clients_email = @email
                WHERE id_clients = @client_id;";

                string addressSql = @"
                UPDATE addresses
                SET
                    addresses_town = @town,
                    addresses_street = @street,
                    addresses_building_number = @building,
                    addresses_apartment_number = @apartment,
                    addresses_postal_code = @postal_code
                WHERE id_addresses = @address_id;";

                var rowsClient = connection.Execute(clientSql, new
                {
                    client_id = client.Id,
                    is_company = client.IsCompany,
                    name = client.Name,
                    entity_number = client.EntityNumber,
                    phone = client.PhoneNumber,
                    email = client.EmailAddress
                });

                var rowsAddress = connection.Execute(addressSql, new
                {
                    address_id = client.Address.Id,
                    town = client.Address.Town,
                    street = client.Address.Street,
                    building = client.Address.BuildingNumber,
                    apartment = client.Address.ApartmentNumber,
                    postal_code = client.Address.PostalCode
                });

                if (rowsClient > 0 && rowsAddress > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool DeleteClient(int id)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                DELETE FROM clients
                WHERE id_clients = @delete_id;";

                var rowsAffected = connection.Execute(sql, new { delete_id = id });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool AddProduct(Product product)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO products
                (products_name, products_manufacturer, products_catalog_number, products_category, products_count, products_price, products_rack, products_shelf)
                VALUES
                (@name, @manufacturer, @catalog_number, @category, @count, @price, @rack, @shelf);";

                var rowsAffected = connection.Execute(sql, new { 
                    name = product.Name,
                    manufacturer = product.Manufacturer,
                    catalog_number = product.CatalogNumber,
                    category = product.Category,
                    count = product.OrderCount,
                    price = product.Price,
                    rack = product.Rack,
                    shelf = product.Shelf});

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool UpdateProduct(Product product)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE products
                SET
                    products_name = @name,
                    products_manufacturer = @manufacturer, 
                    products_catalog_number = @catalog_number, 
                    products_category = @category,
                    products_count = @count,
                    products_price = @price,
                    products_rack = @rack,
                    products_shelf = @shelf
                WHERE id_products = @product_id;";

                var rowsAffected = connection.Execute(sql, new
                {
                    product_id = product.Id,
                    name = product.Name,
                    manufacturer = product.Manufacturer,
                    catalog_number = product.CatalogNumber,
                    category = product.Category,
                    count = product.Count,
                    price = product.Price,
                    rack = product.Rack,
                    shelf = product.Shelf
                });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool DeleteProduct(int id)
        {
            var result = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                UPDATE products
                SET products_deleted = 1
                WHERE id_products = @delete_id;";

                var rowsAffected = connection.Execute(sql, new { delete_id = id });

                if (rowsAffected > 0)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
