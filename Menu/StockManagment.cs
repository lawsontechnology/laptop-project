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
  public class StockManagment
  {
    IStockInterface stockManager = new StockManager();
    List<Stock> stockDb = DataBase.StockDb;
    Dictionary<string, int> stockValues = DataBase.AddToStock;

    public void StockMgt()
    {
      bool stopStock = false;
      while (!stopStock)
      {

        Console.WriteLine("Enter 1 To View Stock\nEnter 2 To Add Stock\nEnter 3 To Delete Stock\n Enter 0 To Quit StockProgram");
        int stockOption = int.Parse(Console.ReadLine());
        if (stockOption == 1)
        {
          ViewAllStock();

        }
        else if (stockOption == 2)
        {
          AddStock();
        }
        else if (stockOption == 3)
        {
          DeleteStock();
        }
        else if (stockOption == 0)
        {
          stopStock = true;
        }
        else
        {
          Console.WriteLine("Invaild Input");
        }
      }
    }
    // public void ReduceQuantity(Brand brand, int quantity)
    // {
    //   stockValues[brand.Name] -= quantity;
    // }
    
    

    public void ViewAllStock()
    {
      foreach (var AllStock in stockDb)
      {
        foreach(var item in AllStock.Brands)
        {
           Console.WriteLine($"AvaliableGoods: {item.Key}");
           Console.WriteLine($"QuantityOfGoods: {item.Value}");
        }
       Console.WriteLine($"Id: {AllStock.Id},\nDateOfStock: {AllStock.DateOfStock},\nStockReferenceNumber: {AllStock.ReferenceNumber}");
      }
    }

    public void DeleteStock()
    {
      Console.WriteLine("Enter The ReferenceNumber of Stock you wish to delete");
      string stockReferenceNumber = Console.ReadLine();
      var Delete = stockManager.Get(stockReferenceNumber);
      stockDb.Remove(Delete);
    }

    public void AddStock()
    {
      Console.WriteLine("Enter Quantity Of The Stock You Wish To Add");
      int quantityOfStock = int.Parse(Console.ReadLine());
      for (int i = 0; i < quantityOfStock; i++)
      {
        Console.WriteLine("Enter The Brand Name");
        string Brand = Console.ReadLine();
        Console.WriteLine("Enter The Pics Of Laptop for Each Brand Name");
        int picsOfBrand = int.Parse(Console.ReadLine());
        var stockRefNumber = OrderManager.GetRegNumber();
        stockValues.Add(Brand, picsOfBrand);
        var newStock = stockManager.Register(quantityOfStock, DateTime.Now, stockRefNumber, stockValues);
        stockDb.Add(newStock);
      }

    }


  }
}