using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.Enum;
using Laptop_Project.interfaces;
using Laptop_Project.Menu.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Implemenations
{
    public class ManagerManager : IManagerInterface
    {
        List<Manager> managerDb = DataBase.ManagerDb;
        List<User> userDb = DataBase.UserDb;
        List<Brand> brandDb = DataBase.BrandDb;
        IUserInterface userInterface = new UserManager();
        public bool Delete(string staffNumber)
        {
           var manager = Get(staffNumber);
           if (manager != null)
           {
                managerDb.Remove(manager);
                return true;
           }
           return false;
        }

        public Manager Get(string staffNumber)
        {
             foreach (var manager in managerDb)
            {
                if (manager.StaffNumber == staffNumber)
                {
                    return manager;
                }
            }
            return null;
        }

        public List<Manager> GetAll()
        {
            return managerDb;
        }

        public List<Brand> GetAllBrands()
        {
            return brandDb;
        }
 
        public Manager Register(string name, string email, string password, string address, string phoneNumber, Gender gender)
        {
             var exists = userInterface.Get(email);
            if (exists != null)
            {
                System.Console.WriteLine("email already exists");
            }
            var user = new User(userDb.Count+1,name,email,password,address,phoneNumber,gender,0,"Manager");
            userDb.Add(user);

            var manager = new Manager(managerDb.Count+1,email,"law/09/0000");
            managerDb.Add(manager);

            return manager;
        }

        public Manager Update(string staffNumber)
        {
            throw new NotImplementedException();
        }

        private bool check(string staffNumber)
        {
            foreach (var manager in managerDb)
            {
                if(manager.StaffNumber == staffNumber)
                {
                    return false;
                }
            }
            return true;
        }
    }

  
}