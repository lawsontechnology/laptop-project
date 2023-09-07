using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Project.Model
{
    public class Brand
    {
        public int Id;
        public string Name;
        public string Ram;
        public string Rom;
        public string Generation;
        public string SerialNumber;
        public double Price;
        public int StockId;
         
        public Brand(int id,string name, string ram, string rom, string generation,string serialNumber,double price,int stockId)
        {
            Id = id;
            Name = name;
            Ram = ram;
            Rom = rom;
            Generation = generation;
            SerialNumber = serialNumber;
            Price = price;
            StockId = stockId;
        }
    }
     
}