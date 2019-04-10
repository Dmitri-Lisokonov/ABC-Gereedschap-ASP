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
    class IProductContext 
    {
        //Get all Products within a given branch.

        public List<Product> GetBranchProducts(Branch branch)
        {
            List<Product> ProductList = new List<Product>();
            try
            {

                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.ReadBranchProducts Location = @Branch";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Branch", branch);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product Product =
                            new Product(
                                reader["Type"].ToString(),
                                reader["Discription"].ToString(),
                                reader["Branch"].ToString(),
                                reader["Name"].ToString(),
                                Convert.ToInt32(reader["SerialNumber"])
                            );
                            ProductList.Add(Product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);

            }
            return ProductList;
        }

        //Get all Products of all branches.
        public List<Product> GetGlobalProducts()
        {
            List<Product> ProductList = new List<Product>();
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.ReadGlobalProducts";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product Product =
                            new Product(
                                reader["Type"].ToString(),
                                reader["Discription"].ToString(),
                                reader["Branch"].ToString(),
                                reader["Name"].ToString(),
                                Convert.ToInt32(reader["SerialNumber"])
                            );
                            ProductList.Add(Product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            return ProductList;
        }

        //Add a new Product.
        public bool AddProduct(Product Product)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.CreateProduct @Name = @GivenName, " +
                        "@Type = @GivenType, " +
                        "@Description = @GivenDescription, " +
                        "@Location = @GivenBranch, " +
                        "@GlobalStock = 1, " +
                        "@LocalStock = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenType", Product.type);
                    command.Parameters.AddWithValue("@GivenDescription", Product.description);
                    command.Parameters.AddWithValue("@GivenBranch", Product.branch);
                    command.Parameters.AddWithValue("@GivenName", Product.name);
                    
                    

                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Product added.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Product could not be added.");
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

        //Get 1 Product by ID.
        public Product GetProduct(int ProductID)
        {

            Product Product = new Product();
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.GetProductByID ProductID = @GivenProductID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product.type = reader["Type"].ToString();
                            Product.description = reader["Discription"].ToString();
                            Product.branch = reader["Branch"].ToString();
                            Product.name = reader["Name"].ToString();
                            Product.serialNumber = Convert.ToInt32(reader["SerialNumber"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            return Product;
        }

        public bool RemoveProduct(int ProductID)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.DeleteProductByID ProductID = @GivenProductID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenProductID", ProductID);
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Product removed.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Product could not be removed.");
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

        public bool UpdateProduct(int ProductID)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.UpdateProduct " +
                        "Type = @Type, " +
                        "Discription = @Discription, " +
                        "Branch = @Branch, " +
                        "Name = @Name," +
                        "SerialNumber = @SerialNumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Product updated.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to update Product.");

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
