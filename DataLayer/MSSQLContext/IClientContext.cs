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
    class IClientContext : IClientInterface
    {
        public bool AddClient(Client client)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.AddCustomer @Description = @GivenDescription, " +
                        "@Name = @GivenName, " +
                        "@Adress = @GivenAdress, " +
                        "@Phonenumber = @GivenPhonenumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenDescription", client.description);
                    command.Parameters.AddWithValue("@GivenName", client.name);
                    command.Parameters.AddWithValue("@GivenAdress", client.adress);
                    command.Parameters.AddWithValue("@GivenPhonenumber", client.phonenumber);

                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        Console.WriteLine("Client added.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Client could not be added.");
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

        public List<Client> GetBranchClients(Branch branch)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int clientID)
        {
            Client client = new Client();
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                {
                    string query = "EXEC dbo.GetClientByID @ClientID = @GivenClientID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GivenClientID", clientID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            client.description = reader["Description"].ToString();
                            client.name = reader["CompanyName"].ToString();
                            client.adress = reader["Adress"].ToString();
                            client.phonenumber = reader["Phonenumber"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            return client;
        }

        public List<Client> GetGlobalClients()
        {
            throw new NotImplementedException();
        }

        public bool RemoveClient(int clientID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClient(int clientID)
        {
            throw new NotImplementedException();
        }
    }
}
