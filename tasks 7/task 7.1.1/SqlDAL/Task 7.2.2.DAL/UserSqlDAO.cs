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
    public class UserSqlDAO : IUserSqlDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public void DeleteById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Users_DeleteByID", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Users_GetAll", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                connection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Guid guid = Guid.Parse(reader["ID"].ToString());
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];
                    DateTime date = DateTime.Parse(reader["BirthDay"].ToString());
                    List<Award> awards = new List<Award>();
                    awards = GetAwards(guid).ToList();
                    yield return new User(guid, name, date, age, awards);
                }
            }
        }


        public User GetById(Guid id)
        {
            return GetAll().FirstOrDefault(user => id == user.ID);

        }

        public void Save(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd;
                if (GetById(user.ID) != null)
                {
                    cmd = new SqlCommand("Users_Save", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    AddAward(user.ID, user.Awards);
                }
                else
                {
                    cmd = new SqlCommand("Users_Create", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                }
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@BirthDay", user.BirthDay);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private IEnumerable<Award> GetAwards(Guid guid)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Users_GetAwards", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", guid);
                connection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["ID"].ToString());
                    string title = (string)reader["Title"];
                    yield return new Award(id, title, new List<User>());
                }
            }
        }

        private void AddAward(Guid guid, List<Award> awards)
        {
            foreach (var item in awards)
            {
                if (!Contains(guid, item.ID))
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        var cmd = new SqlCommand("Users_AddAward")
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@UserID", guid);
                        cmd.Parameters.AddWithValue("@AwardID", item.ID);
                        cmd.Connection = connection;
                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private bool Contains(Guid userID, Guid awardID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("Users_CheckAwards")
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@AwardID", awardID);
                cmd.Connection = connection;
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }
    }
}
