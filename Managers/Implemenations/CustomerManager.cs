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
    public class CustomerManager : ICustomerInterface
    {
        List<Customer> customerDb = DataBase.CustomerDb;
        List<User> userDb = DataBase.UserDb;
        IUserInterface userInterface = new UserManager();

        public bool Delete(string email)
        {
            var customer = Get(email);
            if(customer != null)
            {
                customerDb.Remove(customer);
                return true;
            }
            return false;
        }

        public Customer Get(string email)
        {
            foreach (var customer in customerDb)
            {
                if(customer.UserEmail == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return customerDb;
        }

        public Customer Register(string name, string userEmail, string password, string address, string phoneNumber, Gender gender)
        {
            var exist = userInterface.Get(userEmail);
            if (exist != null)
            {
                System.Console.WriteLine("email already exist");
            }
                var user = new User(userDb.Count+1,name,userEmail,password,address,phoneNumber,gender,0,"Customer");
                userDb.Add(user);

                var customer = new Customer(customerDb.Count+1,name,userEmail,0);
                customerDb.Add(customer);

                return customer;
        }

        public Customer Update(string email)
        {
           throw new NotImplementedException();
        }

        private bool check(string email)
        {
          foreach (var customer in customerDb)
          {
            if(customer.UserEmail == email)
            {
                return false;
            }
          }
          return true;
        }
    }
}