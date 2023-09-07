using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Enum;
using Laptop_Project.Model;

namespace Laptop_Project.Data
{
    public class DataBase
    {
      public static List<User> UserDb = new List<User>()
      {
        new User(1,"Lawson","Lawson@gmail.com","lawson","Ogun","09040029635",(Gender)1,0,"SuperAdmin") 
      };
      public static List<Stock> StockDb = new List<Stock>();
      public static List<Product> ProductDb = new List<Product>()
      {
        new Product(1,"HP",90000,"10% Discount"),
        new Product(2,"DELL",80000,"5% Discount"), 
        new Product(3,"LENOVO",65000,"5% Discount")
      };
      public static List<Order> OrderDb = new List<Order>();
      public static List<Manager> ManagerDb = new List<Manager>();
      public static List<Customer> CustomerDb = new List<Customer>();
      public static List<Brand> BrandDb = new List<Brand>()
      {
        new Brand(1,"HP840","8gb","500gb","4th","bang2020123",90000,1),
        new Brand(2,"HP15","16gb","1TB","7th","cnn20221234",150000,2),
        new Brand(3,"DellE6420","4gb","500gb","3th","de20224321ll",70000,3),
        new Brand(4,"Lenovo212","6gb","256","6th","5cn23456",120000,4)
      };
        public static Dictionary<string, int> AddToStock = new Dictionary<string, int>()
        {
            
        };

      
    }
}