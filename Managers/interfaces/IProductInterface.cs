using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Model;

namespace Laptop_Project.interfaces
{
    public interface IProductInterface
    {
      public Product Register(string productName,double price,string serialNumber);
      public Product Get(string productName);
      public List<Product> GetAll();
      public Product Update(double price);
      public bool Delete(string serialNumber);
    }
}