using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Project.Model
{
    public class Customer
    {
        public int Id;
        public string UserName;
        public string UserEmail;
        public double Wallet;
       
         public  Customer(int id, string userName, string userEmail,double wallet)
         {
            Id = id;   
            UserName = userName;
            UserEmail = userEmail;
            Wallet = wallet;
            
         }
    }
}