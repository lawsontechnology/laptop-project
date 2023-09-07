using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Implemenations
{
    public class StockManager : IStockInterface
    {
        List<Stock> stockDb = DataBase.StockDb;
        
        
        public bool Delete(string referenceNumber)
        {
           var stock = Get(referenceNumber);
           if(stock != null)
           {
             stockDb.Remove(stock);
             return true;
           }
           return false;
        }

        public Stock Get(string referenceNumber)
        {
               foreach (var stock in stockDb)
            {
                if(stock.ReferenceNumber == referenceNumber)
                {
                    return stock;
                }
            }
            return null;
        }
 
        public List<Stock> GetAll()
        {
          return stockDb;
        }

        public Stock Register(int quantity, DateTime dateOfStock, string referenceNumber, Dictionary<string,int> brands)
        {
            var exist = Check(referenceNumber);
           if(exist == false)
           {
             Console.WriteLine("Goods with This ReferenceNumber already exist");
             return null;
           }
           Stock stock = new Stock(stockDb.Count+1,quantity,DateTime.Now,referenceNumber,brands);
            stockDb.Add(stock);
           return stock;

        }

        public Stock Update(string referenceNumber)
        {
            throw new NotImplementedException();
        }

         public bool Check(string referenceNumber)
         {
            foreach (var stock in stockDb)
            {
                if(stock.ReferenceNumber == referenceNumber)
                {
                    return false;
                }
            }
            return true;
         }
       

      
    }
}