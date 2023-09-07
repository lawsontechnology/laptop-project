using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Project.Model
{
    public class Manager
    {
        public int Id;
        public string UserEmail;
        public string StaffNumber;

         public Manager(int id, string userEmail, string staffNumber)
         {
            Id = id;
            UserEmail = userEmail;
            StaffNumber = staffNumber;
         }
    }
}