using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCGereedschap.DataLayer.MSSQLContext;
using ABCGereedschap.Models;

namespace ABCGereedschap.DataLayer.Repository
{
    public class UserRepository
    {
        IUserContext icontext = null;

        public UserRepository(IUserContext icontext)
        {
            this.icontext = icontext;
        }

        public List<User> GetBranchUsers(Branch branch)
        {
            return icontext.GetBranchUsers(branch);
        }
        public List<User> GetGlobalUsers()
        {
            return icontext.GetGlobalUsers();
        }
        public User GetUser(int ID)
        {
            return icontext.GetUser(ID);
        }
        public bool RemoveUser(int ID)
        {
            return icontext.RemoveUser(ID);
        }
        public bool UpdateUser(User user)
        {
            return icontext.UpdateUser(user);
        }

        public bool AddUser(User user)
        {
            return icontext.AddUser(user);
        }

        public bool LoginUser(string Username, string Password)
        {
            return icontext.LoginUser(Username, Password);
        }
    }
}
