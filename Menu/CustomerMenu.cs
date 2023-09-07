using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.Implemenations;
using Laptop_Project.interfaces;
using Laptop_Project.Menu.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Menu
{
    public class CustomerMenu
    {
        IBrandInterface brandManager = new BrandManager();
        ICustomerInterface customerManager = new CustomerManager();
        IOrderInterface orderManager = new OrderManager();
        //StockManagment stockManagment = new StockManagment();
        List<Brand> brandDb = DataBase.BrandDb;
        List<Product> productDb = DataBase.ProductDb;
        List<Order> orderDb = DataBase.OrderDb;
        List<User> userDb = DataBase.UserDb;
        List<Stock> stockDb = DataBase.StockDb;




        public void CustomerMiniMenu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 To View All Laptops Of Your choice\nEnter 2 To View All Product\nEnter 3 To Add To Wallet\n Enter 0 To Quit");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    foreach (var AllBrand in brandDb)
                    {
                        Console.WriteLine($" Id: {AllBrand.Id} , Name: {AllBrand.Name}, Ram: {AllBrand.Ram}, Rom: {AllBrand.Rom}, Generation: {AllBrand.Generation}, SerialNumber: {AllBrand.SerialNumber}, Price: {AllBrand.Price}");
                    }

                    bool ask = false;
                    while (!ask)
                    {
                        Console.WriteLine("Enter 1 To Make An Order\nEnter 0 To Quit ");
                        int make = int.Parse(Console.ReadLine());
                        if (make == 1)
                        {
                           ask = true;
                            OrderMenu();

                        }
                        else if (make == 0)
                        {
                            ask = true;
                        }
                        else
                        {
                            Console.WriteLine("Invaild Input");
                            CustomerMiniMenu();
                        }

                    }
                }
                else if (option == 2)
                {
                    foreach (var AllProduct in productDb)
                    {
                        Console.WriteLine($"ProductName: {AllProduct.ProductName}, Price: {AllProduct.Price}, Range: {AllProduct.SerialNumber}");
                    }
                    Console.WriteLine("Enter 1 for HP Laptop Only\nEnter 2 for DELL Laptop Only\nEnter 3 for LENOVO Laptop Only");
                    int display = int.Parse(Console.ReadLine());
                    if (display == 1)
                    {
                        foreach (var checking in productDb)
                        {
                            if (checking.ProductName == "HP")
                            {
                                foreach (var check in brandDb)
                                {
                                    var contain = check.Name.Contains("HP");
                                    if (contain || check.Name.Contains("Hp"))
                                    {
                                        Console.WriteLine($" Id: {check.Id}, Name: {check.Name}, Ram: {check.Ram}, Rom: {check.Rom}, Generation: {check.Generation}, SerialNumber: {check.SerialNumber}, Price: {check.Price}");
                                        OrderMenu();
                                    }
                                }
                            }
                        }
                    }
                    else if (display == 2)
                    {
                        foreach (var checking in productDb)
                        {
                            if (checking.ProductName == "DELL")
                            {
                                foreach (var check in brandDb)
                                {
                                    var contain = check.Name.Contains("DELL");
                                    if (contain || check.Name.Contains("Dell"))
                                    {
                                        Console.WriteLine($"Id: {check.Id},Name: {check.Name}, Ram: {check.Ram}, Rom: {check.Rom}, Generation: {check.Generation}, SerialNumber: {check.SerialNumber}, Price: {check.Price}");
                                        OrderMenu();
                                    }
                                }
                            }
                        }
                    }
                    else if (display == 3)
                    {
                        foreach (var checking in productDb)
                        {
                            if (checking.ProductName == "LENOVO")
                            {
                                foreach (var check in brandDb)
                                {
                                    var contain = check.Name.Contains("LENOVO");
                                    if (contain || check.Name.Contains("Lenovo"))
                                    {
                                        Console.WriteLine($"Id: {check.Id},Name: {check.Name}, Ram: {check.Ram}, Rom: {check.Rom}, Generation: {check.Generation}, SerialNumber: {check.SerialNumber}, Price: {check.Price}");
                                        OrderMenu();
                                    }
                                }
                            }
                        }
                    }

                }
                else if (option == 3)
                {
                    Deposit();

                }
                else if (option == 0)
                {
                    stop = true;
                }
                else
                {
                    Console.WriteLine("Invaild Input Perform");
                }

            }


        }

        public void Deposit()
        {

            Console.WriteLine("Enter the Amount You Want To Add Wallet");
            double Amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Email ");
            string Email = Console.ReadLine();
            customerManager.Get(Email).Wallet += Amount;
            Console.WriteLine($"----{Amount} is SucessFully Added To Wallet---");

        }

        public void OrderMenu()
        {
            var Quantity = 0;
            Brand brand;
            double totalPrice = 0;
            Console.WriteLine("How many Laptop did you wish to purchase");
            int purchase = int.Parse(Console.ReadLine());
            for (int i = 0; i < purchase; i++)
            {
                Console.WriteLine("Please select your desired Laptop using the Id number");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the quantity of your desired Laptops");
                Quantity = int.Parse(Console.ReadLine());
                brand =brandManager.Get(Id);

                totalPrice += brand.Price * Quantity;
                
            }

            // foreach (var AllStock in stockDb)
            // {
            //     foreach (var item in AllStock.Brands)
            //     {
            //         if (Quantity > AllStock.Brands.Values.Count)
            //         {
            //             Console.WriteLine("The Product Is Out Of Stock !!!");

            //         }
            //         else
            //         {
                        Console.WriteLine($"The Total Price Of The Laptop Is: {totalPrice}");
                        Console.WriteLine("Enter 1 To Contiue or Enter 2 To Quit Order");
                        int suggestion = int.Parse(Console.ReadLine());
                        if (suggestion == 1)
                        {
                            Console.WriteLine("Enter your Email");
                            string UserEmail = Console.ReadLine();
                            var walletBalc = customerManager.Get(UserEmail).Wallet;
                            if (walletBalc >= totalPrice)
                            {
                                var refNumber = OrderManager.GetRegNumber();
                                var newOrder = orderManager.Make(UserEmail, refNumber,brandDb.Count);
                                orderDb.Add(newOrder);
                                //var stock = stockDb.Where(x => x.Id == brand.Id).FirstOrDefault();
                               
                                // stockManagment.ReduceQuantity(brand,Quantity);
                                Console.WriteLine("----------Order Successful---------");
                                Console.WriteLine($">>>>>>>----Your ID Recepit Number Is {refNumber}------<<<<<<<<");
                                Console.WriteLine("   Thank You For Dealing With Us !!!!  ");


                            }
                            else
                            {
                                Console.WriteLine("insufficent balance");
                                Console.WriteLine("Enter 1 To Fund Wallet\n Enter 0 To Exsit Order");
                                int funds = int.Parse(Console.ReadLine());
                                if (funds == 1)
                                {
                                    Deposit();
                                    OrderMenu();
                                }
                                else if (funds == 0)
                                {
                                    CustomerMiniMenu();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    CustomerMiniMenu();
                                }

                            }
                            Console.WriteLine("Enter 1 To Purchase Products \nEnter 0 Key To Exist");
                            int purchaseAgain = int.Parse(Console.ReadLine());
                            if (purchaseAgain == 1)
                            {
                                CustomerMiniMenu();
                            }
                            else if(purchaseAgain == 0)
                            {
                                Main backToMain = new Main();
                                backToMain.MainMenu();
                                return;
                            }
                            else
                            {
                                Console.WriteLine(">>>>>>>>----ThankYou For Buying From Us !!!!!---<<<<<<<");
                            }


                        }
                        else if (suggestion == 2)
                        {
                            CustomerMiniMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invaild Input");
                            CustomerMiniMenu();
                        }
                   // }
               // }  
          //  }

        }

        public void ViewAllOrder()
        {
            foreach (var viewOrder in orderDb)
            {
                Console.WriteLine($" Id: {viewOrder.Id}, Email: {viewOrder.Email}, CustomerId: {viewOrder.CustomerId}, Status: {viewOrder.Status}, OrderReferenceNumber: {viewOrder.ReferenceNumber}");
            }
        }

        public void ViewAllCustomer()
        {
            foreach (var viewCustomer in userDb)
            {
                Console.WriteLine($"Id: {viewCustomer.Id}, Email: {viewCustomer.UserEmail}, Address: {viewCustomer.Address}, PhoneNumber: {viewCustomer.PhoneNumber}, Gender: {viewCustomer.Gender}");
            }
        }


    }

}