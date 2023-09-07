using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.Implemenations;
using Laptop_Project.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Menu
{
    public class Manager
    {
        IBrandInterface brandManager = new BrandManager();
        IProductInterface productManager = new ProductManager();
        List<Brand> brandDb = DataBase.BrandDb;
        List<Product> productDb = DataBase.ProductDb;
        List<Stock> stockDb = DataBase.StockDb;
        public void ManagerMenu()
        {
            bool MenuLoop = false;
            while (!MenuLoop)
            {
                Console.WriteLine("Enter 1 for Brand Mgt\nEnter 2 for Customer Mgt\nEnter 3 for Order Mgt\nEnter 4 for Product Mgt\n Enter 5 for Stock Mgt \n Enter 0  to Quit Menu");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    BrandMgtMenu();

                }
                else if (input == 2)
                {
                  CustomerMenu customermgt = new CustomerMenu();
                   customermgt.ViewAllCustomer();
                }
                else if (input == 3)
                {
                    CustomerMenu ordermgt = new CustomerMenu();
                    ordermgt.ViewAllOrder();
                }
                else if (input == 4)
                { 
                    ProductMgtMenu();
                }
                else if (input == 5)
                {
                    StockManagment stockProgram = new StockManagment();
                    stockProgram.StockMgt();
                }
                else if (input == 0)
                {
                  MenuLoop = true;
                }
                
            }

        }

        public void BrandMgtMenu()
        {
            Console.WriteLine("Enter 1 to Register Brand\nEnter 2 to View All Brand\nEnter 3 to Delete a Brand");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                RegisterBrandMenu();



            }
            else if (opt == 2)
            {
                ViewAllBrandMenu();
            }
            else if (opt == 3)
            {
                DeleteBrandMenu();
            }

        }

        public void ProductMgtMenu()
        {
            Console.WriteLine("Enter 1 to Register Product\nEnter 2 to View All Product\nEnter 3 to Delete a Product");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                RegisterProductMenu();



            }
            else if (opt == 2)
            {
                ViewAllProductMenu();
            }
            else if (opt == 3)
            {
                DeleteProductMenu();
            }

        }

        public void RegisterBrandMenu()
        {

            Console.WriteLine("Enter Laptop Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Ram Size");
            string ram = Console.ReadLine();
            Console.WriteLine("Enter Rom Size");
            string rom = Console.ReadLine();
            Console.WriteLine("Enter Generation");
            string generation = Console.ReadLine();
            Console.WriteLine("Enter SerialNumber");
            string serialNumber = Console.ReadLine();
            Console.WriteLine("Enter Price ");
            double price = double.Parse(Console.ReadLine());

            var register = brandManager.Register(name, ram, rom, generation, serialNumber, price, stockDb.Count);
            brandDb.Add(register);
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 to register again\n Enter 0 to exist register");
                int invalue = int.Parse(Console.ReadLine());
                if (invalue == 1)
                {
                    RegisterBrandMenu();
                }
                else if (invalue == 0)
                {
                    stop = true;
                }
                else
                {
                    System.Console.WriteLine("invaild input ");
                }
            }

        }

        public void ViewAllBrandMenu()
        {
            foreach (var AllBrand in brandDb)
            {
                Console.WriteLine($"Id: {AllBrand.Id}, Name: {AllBrand.Name}, Ram: {AllBrand.Ram}, Rom: {AllBrand.Rom}, Generation: {AllBrand.Generation}, SerialNumber: {AllBrand.SerialNumber}, Price: {AllBrand.Price}");
            }
        }

        public void DeleteBrandMenu()
        {
            Console.WriteLine("Enter The Id number of Brand you wish to delete");
            int Id = int.Parse(Console.ReadLine());
            var Delete = brandManager.Get(Id);
            brandDb.Remove(Delete);
            Console.WriteLine("Successfully Delete");

        }

        public void RegisterProductMenu()
        {
            Console.WriteLine("Enter Product Name");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter Price");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter SerialNumber");
            string serialNumber = Console.ReadLine();

            var product = productManager.Register(productName, price, serialNumber);
            productDb.Add(product);
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 to register again\n Enter 0 to exist register");
                int invalue = int.Parse(Console.ReadLine());
                if (invalue == 1)
                {
                    RegisterProductMenu();
                }
                else if (invalue == 0)
                {
                    stop = true;
                }
                else
                {
                    System.Console.WriteLine("invaild input ");
                }
            }
        }

        public void ViewAllProductMenu()
        {
            foreach (var AllProduct in productDb)
            {
                Console.WriteLine($"Id: {AllProduct.Id}, ProductName: {AllProduct.ProductName} ,Price: {AllProduct.Price} ,Discount: {AllProduct.SerialNumber}");
            }
        }
        public void DeleteProductMenu()
        {
            Console.WriteLine("Enter The ProductName you wish to delete");
            string ProductName = Console.ReadLine();
            var Delete = productManager.Get(ProductName);
            productDb.Remove(Delete);
            System.Console.WriteLine("Sucessfully Delete");

        }





    }
}