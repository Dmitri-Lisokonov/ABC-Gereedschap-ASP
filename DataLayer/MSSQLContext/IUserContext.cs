using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCGereedschap.DataLayer;
using ABCGereedschap.Logic;

namespace ABCGereedschap.DataLayer.MSSQLContext
{
    public class IUserContext
    {
        private string dbUsername;
        private string dbPassword;

        //Get all users within a given branch.

        public List<User> GetBranchUsers(Branch branch)
        {
            List<User> userList = new List<User>();
            try
            {

                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.ReadBranchUsers @Location = @Branch";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Branch", branch);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user =
                            new User(
                                reader["Name"].ToString(),
                                reader["Email"].ToString(),
                                reader["PhoneNumber"].ToString(),
                                reader["Location"].ToString(),
                                Convert.ToInt32(reader["userID"]),
                                Convert.ToBoolean(reader["Status"]),
                                reader["FunctionName"].ToString(),
                                reader["Password"].ToString()
                            );
                            userList.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);

            }
            return userList;
        }

        //Get all users of all branches.
        public List<User> GetGlobalUsers()
        {
            List<User> userList = new List<User>();
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.ReadGlobalUsers";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user =
                            new User(
                                reader["Name"].ToString(),
                                reader["Email"].ToString(),
                                reader["PhoneNumber"].ToString(),
                                reader["Location"].ToString(),
                                Convert.ToInt32(reader["userID"]),
                                Convert.ToBoolean(reader["Status"]),
                                reader["FunctionName"].ToString(),
                                reader["Password"].ToString()
                            );
                            userList.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            return userList;
        }

        //Add a new user.
        public bool AddUser(User user)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.AddEmployee @Name = @GivenName, " +
                        "@Location = @GivenLocation, " +
                        "@Email = @GivenEmail, " +
                        "@FunctionName = @GivenFunctionName, " +
                        "@PhoneNumber = @GivenPhoneNumber, " +
                        "@Password = @GivenPassword";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenName", user.name);
                    command.Parameters.AddWithValue("@GivenLocation", user.branch);
                    command.Parameters.AddWithValue("@GivenEmail", user.email);
                    command.Parameters.AddWithValue("@GivenFunctionName", user.functionName);
                    command.Parameters.AddWithValue("@GivenPhoneNumber", user.phone);
                    command.Parameters.AddWithValue("@GivenPassword", "password");

                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Employee added.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Employee could not be added.");
                        return false;
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                return false;
            }
        }

        //Get 1 user by ID.
        public User GetUser(int userID)
        {

            User user = new User();
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.GetUserByID UserID = @GivenUserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenUserID", userID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.name = reader["Name"].ToString();
                            user.email = reader["Email"].ToString();
                            user.phone = reader["PhoneNumber"].ToString();
                            user.status = Convert.ToBoolean(reader["Status"]);
                            user.branch = reader["Location"].ToString();
                            user.userID = Convert.ToInt32(reader["userID"]);
                            user.functionName = reader["FunctionName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            return user;
        }

        public bool RemoveUser(int userID)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.DeleteUserByID UserID = @GivenUserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenUserID", userID);
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("User removed.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("User could not be removed.");
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.UpdateUser " +
                        "Name = @GivenName, " +
                        "Location = @GivenLocation, " +
                        "Email = @GivenEmail, " +
                        "FunctionName = @GivenFunctionName," +
                        "PhoneNumber = @GivenPhoneNumber," +
                        "Password = @GivenPassword," +
                        "UserID = @GivenUserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("GivenName", user.name);
                    command.Parameters.AddWithValue("GivenLocation", user.branch);
                    command.Parameters.AddWithValue("GivenEmail", user.email);
                    command.Parameters.AddWithValue("GivenFunctionName", user.functionName);
                    command.Parameters.AddWithValue("GivenPhoneNumber", user.phone);
                    command.Parameters.AddWithValue("GivenPassword", user.password);
                    command.Parameters.AddWithValue("GivenUserID", user.userID);
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("User updated.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to update user.");
                        return false;
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                return false;
            }
        }
        public bool LoginUser(string Username, string Password)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.Login Name = @Username;";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", Username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dbUsername = reader["Name"].ToString();
                            dbPassword = reader["Password"].ToString();
                        }
                    }
                }

                if (dbUsername == Username && dbPassword == Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
