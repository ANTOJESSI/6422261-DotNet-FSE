using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryApp
{
    public class Inventory
    {
        private static Inventory _instance;
        private static readonly object _lock = new object(); // For thread safety

        private Dictionary<int, Product> products = new Dictionary<int, Product>();
        private string filePath = "products.json";

        // Constructor is private 
        private Inventory()
        {
            LoadFromFile();
        }

        //  Singleton accessor
        public static Inventory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock) 
                    {
                        if (_instance == null)
                        {
                            _instance = new Inventory();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddProduct(Product product)
        {
            if (!products.ContainsKey(product.ProductId))
            {
                products.Add(product.ProductId, product);
                SaveToFile();
                Console.WriteLine(" Product added.");
            }
            else
            {
                Console.WriteLine("Product ID already exists.");
            }
        }

        public void UpdateProduct(int productId, int quantity, double price)
        {
            if (products.ContainsKey(productId))
            {
                products[productId].Quantity = quantity;
                products[productId].Price = price;
                SaveToFile();
                Console.WriteLine("Product updated.");
            }
            else
            {
                Console.WriteLine(" Product not found.");
            }
        }

        public void DeleteProduct(int productId)
        {
            if (products.Remove(productId))
            {
                SaveToFile();
                Console.WriteLine("Product deleted.");
            }
            else
            {
                Console.WriteLine(" Product not found.");
            }
        }

        public void ViewAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine(" No products in inventory.");
                return;
            }

            Console.WriteLine("\n Inventory List:");
            foreach (var product in products.Values)
            {
                Console.WriteLine(product);
            }
        }

        private void SaveToFile()
        {
            string jsonString = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, jsonString);
        }

        private void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                products = JsonSerializer.Deserialize<Dictionary<int, Product>>(jsonString);
            }
        }
    }
}
