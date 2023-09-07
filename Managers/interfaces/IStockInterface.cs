using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Model;

namespace Laptop_Project.interfaces
{
    public interface IStockInterface
    {
      public Stock Register( int quantity, DateTime dateOfStock, string referenceNumber, Dictionary<string,int> brands);
      public Stock Get(string referenceNumber);
      public List<Stock> GetAll();
      public Stock Update(string referenceNumber);
      public bool Delete(string referenceNumber);
    }
}