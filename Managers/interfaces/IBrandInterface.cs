using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Model;

namespace Laptop_Project.interfaces
{
    public interface IBrandInterface
    {
        public Brand Register(string name,string ram,string rom,string generation,string serialNumber,double Price,int stockId);
        public Brand Get(int id);
        public List<Brand> GetAll();
        public Brand Update(string serialNumber);
        public bool Delete (int id);
       
    }
}