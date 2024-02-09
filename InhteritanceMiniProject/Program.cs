using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMiniProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<InventoryItemModel> inventory = new List<InventoryItemModel>();
            List<IRentable> rentables = new List<IRentable>();
            List<IPurchasable> purschasables = new List<IPurchasable>();

            var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Kia Optima" };
            var book = new BookModel { ProductName = "A tale of 2 cities", NumberOfPages = 350 };
            var excavator = new ExcavatorModel {ProductName = "Bulldozer", QuantityInStock = 2 };

            rentables.Add(vehicle);
            rentables.Add(excavator);

            purschasables.Add(book);
            purschasables.Add(vehicle);

            Console.Write("Do you want to rent or purchase something : (rent, purchase) ");
            string rentalDecision = Console.ReadLine();

            if (rentalDecision.ToLower() == "rent")
            {
                foreach (var item in rentables)
                {
                    Console.WriteLine($"Item: { item.ProductName }");
                    Console.Write("Do you want to rent this item (yes/no)  :  ");
                    string wantToRent = Console.ReadLine();

                    if (wantToRent.ToLower() == "yes")
                    {
                        item.Rent();
                    }
                    
                    Console.Write("Do you want to return this item (yes/no)  :  ");
                    string wantToReturn = Console.ReadLine();

                    if (wantToReturn.ToLower() == "yes")
                    {
                        item.ReturnRental();
                    }


                }
            }
            else
            {
                foreach (var item in purschasables)
                {
                    Console.WriteLine($"Item: {item.ProductName}");
                    Console.Write("Do you want to purchase this product (yes/no): ");
                    string wantToPurchase = Console.ReadLine();

                    if (wantToPurchase.ToLower() == "yes")
                    {
                        item.Purchase();
                    }

                }
            }

            Console.WriteLine("We are Done.");

            Console.ReadLine();
        }
    }

    public interface IInventoryitem
    {
         string ProductName { get; set; }
         int QuantityInStock { get; set; }
    }

    public interface IRentable : IInventoryitem 
    {
        void Rent();
        void ReturnRental();
    }

    public interface IPurchasable : IInventoryitem 
    {
        void Purchase();
     
    }

    public class InventoryItemModel
    {
        public string ProductName { get; set; }
        public int QuantityInStock { get; set; }

    }

    public class VehicleModel : InventoryItemModel, IPurchasable, IRentable
    {
        public decimal DealerFee { get; set; }

        public void Purchase()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This vehicle has been purchased") ;
        }

        public void Rent()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This vehicle has been rented");
        }

        public void ReturnRental()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This vehicle has been returned");
        }
    }

    public class BookModel : InventoryItemModel, IPurchasable
    {
        public int NumberOfPages { get; set; }

        public void Purchase()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This book has been purchased");

        }
    }


    public class ExcavatorModel : InventoryItemModel, IRentable
    {
        public void Dig()
        {
            Console.WriteLine("I am digging");
        }

        public void Rent()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This excavator has been rented");
        }

        public void ReturnRental()
        {
            QuantityInStock -= 1;
            Console.WriteLine("Excavator has been returned");
        }
    }
}
