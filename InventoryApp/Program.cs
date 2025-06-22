using System;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManagement inventory = new InventoryManagement();
            while (true)
            {
                Console.WriteLine("\n📋 Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Products");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option (1-5): ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Product ID: ");
                        int addId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Quantity: ");
                        int qty = int.Parse(Console.ReadLine());

                        Console.Write("Enter Price: ");
                        double price = double.Parse(Console.ReadLine());

                        Product newProduct = new Product(addId, name, qty, price);
                        inventory.AddProduct(newProduct);
                        break;

                    case "2":
                        Console.Write("Enter Product ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Quantity: ");
                        int newQty = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Price: ");
                        double newPrice = double.Parse(Console.ReadLine());

                        inventory.UpdateProduct(updateId, newQty, newPrice);
                        break;

                    case "3":
                        Console.Write("Enter Product ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        inventory.DeleteProduct(deleteId);
                        break;

                    case "4":
                        inventory.ViewAllProducts();
                        break;

                    case "5":
                        Console.WriteLine("👋 Exiting...");
                        return;

                    default:
                        Console.WriteLine("❌ Invalid choice.");
                        break;
                }
            }
        }
    }
}
