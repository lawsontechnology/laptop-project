using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Laptop_Project.Data;
using Laptop_Project.Enum;
using Laptop_Project.Implemenations;
using Laptop_Project.interfaces;
using Laptop_Project.Menu.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Menu
{
    public class Main
    {
        IUserInterface userManager = new UserManager();
        ICustomerInterface CustomerManager = new CustomerManager();


        public void MainMenu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 to Register\nEnter 2 to Login\nEnter 0 to Quit");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    RegisterMenu();
                }
                else if (opt == 2)
                {
                    LoginMenu();
                }

                else if (opt == 0)
                {
                    stop = true;
                }

            }


        }

        public void RegisterMenu()
        {
            Console.WriteLine("Enter your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Email");
            string UserEmail = Console.ReadLine();
            while (!UserEmail.Contains('@'))
            {
                Console.WriteLine("Invalid Email !!!!");
                Console.Write("Input Correct Email: ");
                UserEmail = Console.ReadLine();
            }

            Console.WriteLine("Enter your Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number");
            string phoneNumber = Console.ReadLine();
            while (!IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Invalid Phone Number !!!");
                Console.Write("input correct PhoneNumber: ");
                phoneNumber = Console.ReadLine();
            }
            Console.WriteLine("Enter 1 for Male\n Enter 2 for Female");
            int gender = int.Parse(Console.ReadLine());
            while (gender != 1 && gender != 2)
            {

                Console.WriteLine("Invalid Gender !!!");
                Console.Write("input either 1 0r 2: ");
                gender = int.Parse(Console.ReadLine());
            }
            var response = CustomerManager.Register(name, UserEmail, password, address, phoneNumber, (Gender)gender);
        }
        public void LoginMenu()
        {
            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your Password");
            string password = Console.ReadLine();

            var user = userManager.Login(email, password);

            if (user == null)
            {
                Console.WriteLine("Invalid Login Credentials!"); 
                bool stop = false;
                while (!stop)
                {
                    Console.WriteLine("Enter 1 To Register\nEnter 2 To Login Again\nEnter 0 To Quit");
                    int option = int.Parse(Console.ReadLine());


                    if (option == 1)
                    {
                        RegisterMenu();
                    }
                    else if (option == 2)
                    {
                        LoginMenu();
                    }
                    else if (option == 0)
                    {
                        stop = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        
                    }


                }
            }

            if (user.Role == "Manager")
            {
                Manager manage = new Manager();
                manage.ManagerMenu();
            }
            else if (user.Role == "Customer")
            {
                CustomerMenu custom = new CustomerMenu();
                custom.CustomerMiniMenu();
            }
            else if (user.Role == "SuperAdmin")
            {
                SuperAdmin super = new SuperAdmin();
                super.SuperMenu();
            }
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Define a regular expression pattern for a valid phone number
            string pattern = @"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            // Use Regex.IsMatch to check if the phoneNumber matches the pattern
            return Regex.IsMatch(phoneNumber, pattern);
        }

    }

}