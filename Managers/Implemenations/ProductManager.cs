using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.interfaces;
using Laptop_Project.Menu.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Implemenations
{
    public class ProductManager : IProductInterface
    {
        List<Product> productDb = DataBase.ProductDb;
        

        public bool Delete(string productName)
        {
            var product = Get(productName);
            if(product != null)
            {
                productDb.Remove(product);
                return true;
            }
            return false;
        }

        public Product Get(string productName)
        {
           foreach (var product in productDb)
           {
             if(product.ProductName == productName)
             {
                return product;
             }
           }
           return null;
        }

        public List<Product> GetAll()
        {
            return productDb;
        }

        public Product Register(string productName, double price, string serialNumber)
        {
           var exist = Check(serialNumber);
           if(exist == false)
           {
             Console.WriteLine("SerialNumber already exist");
             return null;
           }
           Product product = new Product(productDb.Count+1,productName,price,serialNumber);
           productDb.Add(product);
           return product;

        }

        public Product Update(double Price)
        {
            throw new NotImplementedException();
        }

        public bool Check(string productName)
        {
            foreach (var product in productDb)
            {
                if(product.ProductName == productName)
                {
                    return false;
                }
            }
            return true;
        }
    }
}