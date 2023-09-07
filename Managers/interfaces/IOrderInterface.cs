using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Model;

namespace Laptop_Project.interfaces
{
    public interface IOrderInterface
    {
      public Order Make(string email, string referenceNumber, int brandId);
      public Order Get(string referenceNumber);
      public List<Order> GetAll();
      public Order Update(string referenceNumber);
      public bool Delete(string referenceNumber);
    }
}