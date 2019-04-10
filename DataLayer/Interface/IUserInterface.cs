using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.DataLayer.Interface
{
    interface IUserInterface
    {
        List<User> GetBranchUsers(Branch branch);
        List<User> GetGlobalUsers();
        User GetUsers(int UserID);
        bool RemoveUser(int UserID);
        bool UpdateUser(int UserID);
        bool AddUser(User user);
    }
}
