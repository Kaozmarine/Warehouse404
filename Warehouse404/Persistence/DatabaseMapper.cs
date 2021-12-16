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
    internal class DatabaseMapper
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
                    users_role AS Role
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
    }
}
