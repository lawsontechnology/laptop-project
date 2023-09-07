using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Project.Model
{
    public class Order
    {
        public int Id;

        public string Email;

        public int CustomerId;

        public string Status;

        public int  BrandId;
        public string ReferenceNumber;

        public List<string> Orders = new List<string>();

        

        public Order(int id, string email, int customerId, string status, int brandId, string referenceNumber, List<string> orders)
        {
            Id = id;
            Email = email;
            CustomerId = customerId;
            Status = status;
            BrandId = brandId;
            ReferenceNumber = referenceNumber;
            Orders = orders;
        }
    }
}