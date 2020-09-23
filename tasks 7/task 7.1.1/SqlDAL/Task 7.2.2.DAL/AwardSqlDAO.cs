using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_7._2._2.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Task_7._2._2.DAL
{
    public class AwardSqlDAO : IAwardSqlDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public void DeleteById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Awards_DeleteByID", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Award> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Awards_GetAll", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                connection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Guid guid = Guid.Parse(reader["ID"].ToString());
                    string title = (string)reader["Title"];
                    List<User> users = new List<User>();
                    users = GetUsers(guid).ToList();
                    yield return new Award(guid, title, users);
                }
            }
        }

        public Award GetById(Guid id)
        {
            return GetAll().FirstOrDefault(award => id == award.ID);
        }

        public void Save(Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd;
                if (GetById(award.ID) != null)
                {
                    cmd = new SqlCommand("Awards_Save", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                }
                else
                {
                    cmd = new SqlCommand("Awards_Create", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                }
                cmd.Parameters.AddWithValue("@ID", award.ID);
                cmd.Parameters.AddWithValue("@Title", award.Title);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private IEnumerable<User> GetUsers(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Awards_GetUsers", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Guid guid = Guid.Parse(reader["ID"].ToString());
                    string name = (string)reader["Name"];
                    DateTime date = DateTime.Parse(reader["BirthDay"].ToString());
                    int age = (int)reader["Age"];
                    yield return new User(guid, name, date, age, new List<Award>());
                }
            }
        }
    }
}
