using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.DataLayer.Interface
{
    interface IClientInterface
    {
        List<Client> GetBranchClients(Branch branch);
        List<Client> GetGlobalClients();
        Client GetClient(int clientID);
        bool RemoveClient(int clientID);
        bool UpdateClient(int clientID);
        bool AddClient(Client client);
    }
}
