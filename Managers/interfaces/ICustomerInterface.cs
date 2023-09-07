using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Enum;
using Laptop_Project.Model;

namespace Laptop_Project.interfaces
{
    public interface ICustomerInterface
    {
        public Customer Register(string name, string UserEmail,string password,string address,string phoneNumber,Gender gender);
        public Customer Get(string email);
        public List<Customer> GetAll();    
        public Customer Update(string email);
        public bool Delete(string email);
    }
}