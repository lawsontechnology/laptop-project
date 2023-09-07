using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Project.Model
{
    public class Product
    {
        public int Id;
        public string ProductName;
        public string SerialNumber;
        public double Price;

        public Product(int id, string productName,double price,string serialNumber)
        {
            Id = id;
            ProductName = productName;
            SerialNumber = serialNumber;
            Price = price;
        }
    }
}