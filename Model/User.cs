using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Project.Enum;

namespace Laptop_Project.Model
{
     public class User
    {
        public int Id;
        public string Name;
        public string UserEmail;
        public string Password;
        public string Address;
        public string PhoneNumber;
        public Gender Gender;
        public double Wallet;
        public string Role;
      
        
        public User(int id, string name, string userEmail,string password,string address,string phoneNumber,Gender gender,double wallet,string role)
        {
           Id = id;
           Name = name;
           UserEmail = userEmail;
           Password = password;
           Address = address;
           PhoneNumber = phoneNumber;
           Gender = gender;
           Wallet = wallet;
           Role = role;
        }
    }

    
}