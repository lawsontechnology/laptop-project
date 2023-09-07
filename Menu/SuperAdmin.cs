using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Enum;
using Laptop_Project.Implemenations;
using Laptop_Project.interfaces;

namespace Laptop_Project.Menu
{
    public class SuperAdmin
    {
        IManagerInterface managerManager = new ManagerManager();
        public void SuperMenu()
        {
            bool superLoop = false;
            while (!superLoop)
            {
                Console.WriteLine("Enter 1 to Register Manager\nEnter 2 To View All Manager Activities\nEnter 0 To LogOut");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                  RegisterManagerMenu();
                }
                else if (opt == 0)
                {
                    superLoop = true;
                   Main main = new Main();
                   main.MainMenu(); 
                }
                else if(opt == 2)
                {
                    Manager managerActivities = new Manager();
                    managerActivities.ManagerMenu();
                }
               
                else
                {
                    Console.WriteLine("Wrong Input");
                    
                }

            }
        }

        public void RegisterManagerMenu()
        {
             Console.WriteLine("Enter Your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Your Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Your Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter 1 for Male\n Enter 2 for Female");
            int gender = int.Parse(Console.ReadLine());
             var response = managerManager.Register( name, email, password, address, phoneNumber, (Gender)gender);
            if(response != null)
            {
                Console.WriteLine("Succesful");
            }
            SuperMenu();
        }
        
    }
}