using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Implemenations
{
    public class BrandManager : IBrandInterface
    {
        IStockInterface stockInterface = new StockManager();
         List<Brand> brandDb = DataBase.BrandDb;
        public bool Delete(int id)
        {
           var brand = Get(id);
           if(brand != null)
           {
             brandDb.Remove(brand);
             return true;
           }
           return false;
        }


        public Brand Get(int id)
        {
            foreach (var brand in brandDb)
            {
                if(brand.Id == id)
                {
                    return brand;
                }
            }
            return null;
        }

        public List<Brand> GetAll()
        {
            return brandDb;
        }

        public Brand Register(string name, string ram, string rom, string generation, string serialNumber,double price,int stockId)
        {
            var BrandExist = Check(serialNumber);
            if(BrandExist == false)
            {
                Console.WriteLine("Brand Already Exist");
                return null;
            }
            Brand brand = new Brand(brandDb.Count+1,name,ram,rom,generation,serialNumber,price,stockInterface.Get(serialNumber).Id);
            brandDb.Add(brand);
            return brand;
        }

        public Brand Update(string serialNumber)
        {
            throw new NotImplementedException();
        }

        private bool Check(string serialNumber)
        {
            foreach (var brand in brandDb)
            {
                if(brand.SerialNumber == serialNumber)
                {
                    return false;
                }
            }
            return true;
        }


    }
}