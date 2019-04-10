using ABCGereedschap.DataLayer.MSSQLContext;
using ABCGereedschap.DataLayer.Repository;
using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.Logic.Controller
{
    class ClientController
    {
        ClientRepository clientRepository = new ClientRepository(new IClientContext());

        public bool ClientRemove(int clientID)
        {
            clientRepository.RemoveClient(clientID);
            return false;
        }
        
        public bool ClientEdit(int clientID)
        {
            clientRepository.UpdateClient(clientID);
            return false;
        }

        public bool ClientCreate(Client client)
        {
            clientRepository.AddClient(client);
            return false;
        }
    }
}
