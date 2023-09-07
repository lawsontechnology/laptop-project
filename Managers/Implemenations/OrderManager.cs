using Laptop_Project.Data;
using Laptop_Project.interfaces;
using Laptop_Project.Menu.interfaces;
using Laptop_Project.Model;

namespace Laptop_Project.Implemenations
{

    public class OrderManager : IOrderInterface
    {
        IStockInterface stockInterface = new StockManager();
        ICustomerInterface customerInterface= new CustomerManager();
        List<Order> orderDb = DataBase.OrderDb;
        public bool Delete(string referenceNumber)
        {
            throw new NotImplementedException();
        }

        public Order Get(string referenceNumber)
        {
            foreach (var item in orderDb)
            {
                if (item.ReferenceNumber == referenceNumber)
                {
                    return item;
                }


            }
            return null;
        }

        public List<Order> GetAll()
        {
            return orderDb;
        }

        public Order Make(string email, string referenceNumber,int brandId)
        {
                var exist = Check(referenceNumber);
                if (exist == false)
                {
                    Console.WriteLine("Order already exist");
                    return null;
                }
                var status = "pending";
                
                var order = new Order(orderDb.Count + 1, email,customerInterface.Get(email).Id , status,brandId, GetRegNumber(), null);
                orderDb.Add(order);
                return order;
        }

        public Order Update(string referenceNumber)
        {
            throw new NotImplementedException();
        }

        private bool Check(string referenceNumber)
        {
            foreach (var order in orderDb)
            {
                if (order.ReferenceNumber == referenceNumber)
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetRegNumber()
        {
            Random Rd = new Random();

            int num = Rd.Next(10, 10000);
            char[] alphebet = new char[] { 'A', 'B', 'c', 'D', 'e', 'f', 'g', 'H', 'I', 'J', 'k', 'l', 'm', 'n', 'O', 'p', 'Q' };
            var rx = Rd.Next(0, alphebet.Length);
            var rz = Rd.Next(0, alphebet.Length);
            var result = $"{alphebet[rx]}{alphebet[rz]}";

            return $"clh{result}{num}";
        }
    }
}