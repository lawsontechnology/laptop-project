using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Enum;
using Laptop_Project.Model;

namespace Laptop_Project.interfaces
{
    public interface IManagerInterface
    {
        public Manager Register(string name, string email,string password,string address,string phoneNumber,Gender gender);
        public Manager Get(string staffNumber);
        public List<Manager> GetAll(); 
        public List<Brand> GetAllBrands();   
        public Manager Update(string staffNumber);
        public bool Delete(string staffNumber);
    } 
   
}