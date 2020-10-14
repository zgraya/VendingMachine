using System.Collections.Generic;

namespace VendingMachine.Products
{
    public class Inventory
    {
        private Dictionary<Product, int> ProductsInside { get; set; }
    }
}