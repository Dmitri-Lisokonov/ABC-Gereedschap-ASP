using ABCGereedschap.DataLayer.Interface;
using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.DataLayer.MSSQLContext
{
    class IOrderContext : IOrderInterface
    {
        //Get all Orders within a given branch.

        public List<Order> GetBranchOrders(Branch branch)
        {
            List<Order> OrderList = new List<Order>();
            try
            {

                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.ReadBranchOrders Location = @Branch";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Branch", branch);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order Order =
                            new Order(
                                Convert.ToInt32(reader["SerialNumber"]),
                                Convert.ToInt32(reader["Quantity"]),
                                Convert.ToInt32(reader["ClientID"]),
                                Convert.ToDateTime(reader["date"])
                                );
                            OrderList.Add(Order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);

            }
            return OrderList;
        }

        //Get all Orders of all branches.
        public List<Order> GetGlobalOrders()
        {
            List<Order> OrderList = new List<Order>();
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.ReadGlobalOrders";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order Order =
                            new Order(
                                Convert.ToInt32(reader["SerialNumber"]),
                                Convert.ToInt32(reader["Quantity"]),
                                Convert.ToInt32(reader["ClientID"]),
                                Convert.ToDateTime(reader["date"])
                                );
                            OrderList.Add(Order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            return OrderList;
        }

        //Add a new Order.
        public bool AddOrder(Order order)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.AddOrder " +
                        "SerialNumber = @SerialNumber, " +
                        "Quantity = @Quantity, " +
                        "Email = @GivenEmail, " +
                        "ClientID = @ClientID, " +
                        "Date = @Date, ";                                               //@ before both vars.
                    SqlCommand command = new SqlCommand(query, connection);

                    new Order(Convert.ToInt32(command.Parameters.AddWithValue("@SerialNumber", order.serialNumber)),
                        Convert.ToInt32(command.Parameters.AddWithValue("@Quantity", order.quantity)),
                        Convert.ToInt32(command.Parameters.AddWithValue("@ClientID", order.clientID)),
                        Convert.ToDateTime(command.Parameters.AddWithValue("@Date", order.date)));

                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Order added.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Order could not be added.");
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

        //Get 1 Order by ID.
        public Order GetOrder(int OrderID)
        {

            Order Order = new Order();
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.GetOrderByID OrderID = @GivenOrderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenOrderID", OrderID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order.quantity = Convert.ToInt32(reader["Quantity"]);
                            Order.clientID = Convert.ToInt32(reader["ClientID"]);
                            Order.date = Convert.ToDateTime(reader["Date"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            return Order;
        }

        public bool RemoveOrder(int OrderID)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.DeleteOrderByID OrderID = @GivenOrderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenOrderID", OrderID);
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Order removed.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Order could not be removed.");
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

        public bool UpdateOrder(int OrderID)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.UpdateOrder " +
                        "Quantity = @Quantity, " +
                        "ClientID = @ClientID, " +
                        "Date = @Date ";
                    SqlCommand command = new SqlCommand(query, connection);
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Order updated.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to update Order.");
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
    }
}
