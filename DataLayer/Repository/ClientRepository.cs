using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCGereedschap.DataLayer.MSSQLContext;
using ABCGereedschap.Models;

namespace ABCGereedschap.DataLayer.Repository
{
    class ClientRepository
    {
        IClientContext icontext = null;

        public ClientRepository(IClientContext icontext)
        {
            this.icontext = icontext;
        }

        public List<Client> GetBranchClients(Branch branch)
        {
            return icontext.GetBranchClients(branch);
        }
        public List<Client> GetGlobalClients()
        {
            return icontext.GetGlobalClients();
        }
        public Client GetClient(int clientID)
        {
            return icontext.GetClient(clientID);
        }
        public bool RemoveClient(int ID)
        {
            return icontext.RemoveClient(ID);
        }
        public bool UpdateClient(int clientID)
        {
            return icontext.UpdateClient(clientID);
        }

        public bool AddClient(Client client)
        {
            return icontext.AddClient(client);
        }
    }
}
