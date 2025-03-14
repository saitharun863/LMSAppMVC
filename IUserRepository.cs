using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebAppMVC.Models
{
    public interface IUserRepository
    {
        IEnumerable<Actor> GetAllUsers();
        Actor GetUserById(int id);
        void AddUser(Actor user);
        string Login(string username, string password);
    }
}
