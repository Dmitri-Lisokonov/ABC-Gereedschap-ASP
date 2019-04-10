using ABCGereedschap.DataLayer.MSSQLContext;
using ABCGereedschap.DataLayer.Repository;
using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.Logic.Controllers
{
    public class UserController
    {
        UserRepository userRepository = new UserRepository(new IUserContext());

        public bool UserLogin(string username, string password)
        {
            return userRepository.LoginUser(username, password);
        }

        public bool UserEdit(User user)
        {
            userRepository.UpdateUser(user);
            return false;
        }

        public bool UserCreate(User user)
        {
            return userRepository.AddUser(user);
        }

        public bool UserRemove(int UserID)
        {
            userRepository.RemoveUser(UserID);
            return false;
        }

        public bool ChangeUserRole()
        {
            return false;
        }
    }
}
