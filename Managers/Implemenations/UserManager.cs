using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.Menu.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Implemenations
{
    public class UserManager : IUserInterface
    {
         List<User> userDb = DataBase.UserDb;


        public bool FundWallet(string email, double amount)
        {
            var user = Get(email);
            if (user != null)
            {
                user.Wallet+=amount;
                return true;
            }
            return false;
        }

        public User Get(string email)
        {
            foreach (var user in userDb)
            {
                if(user.UserEmail == email)    
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return userDb;
        }

        public User Login(string email, string password)
        {
            foreach (var user in userDb)
            {
                if(user.UserEmail == email && user.Password == password)    
                {
                    return user;
                }
            }
            return null;
        }
    }
}