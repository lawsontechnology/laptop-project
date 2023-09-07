using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Project.Model
{
    public class Stock
    {
      public int Id;

      public int Quantity;

      public DateTime DateOfStock;  

      public string ReferenceNumber;

     public Dictionary<string,int> Brands = new Dictionary<string, int>();

        public Stock(int id, int quantity, DateTime dateOfStock, string referenceNumber, Dictionary<string,int> brands)
        {
            Id = id;
            Quantity = quantity;
            DateOfStock = dateOfStock;
            ReferenceNumber = referenceNumber;
            Brands = brands;
        }
    }
}