using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Task_7._2._2.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Task_7._2._2.DAL
{
    public class AccountSqlDAO : IAccountSqlDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public Account GetByLogin(string login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Accounts_GetByLogin", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Account account = null;

                while (reader.Read())
                {
                    string log = (string)reader["Login"];
                    string password = (string)reader["Password"];
                    string role = (string)reader["Role"];
                    account = new Account(log, password, role);
                }
                return account;
            }
        }


        public void Save(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd;
                if (GetByLogin(account.Login) != null)
                {
                    cmd = new SqlCommand("Accounts_Save", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                }
                else
                {
                    cmd = new SqlCommand("Accounts_Create", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                }
                cmd.Parameters.AddWithValue("@Login", account.Login);
                cmd.Parameters.AddWithValue("@Password", account.Password);
                cmd.Parameters.AddWithValue("@Role", account.Role);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
