using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Model;

namespace Laptop_Project.Menu.interfaces
{
    public interface IUserInterface
    {
        public User Get(string email);
        public List<User> GetAll();
        public User Login(string email, string password);
        public bool FundWallet(string email, double amount);
        
    }
}