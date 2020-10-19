using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendingMachine.Products
{
    public class Inventory
    {
        public Dictionary<string, int> ProductsInside { get; set; }

        public List<string> itemsList { get; set; }

        private int Capacity = 10;

        public enum Product
        {
            Cola = 100,
            Chips = 50,
            Candy = 65
        }

        public Inventory()
        {
            foreach (Product product in Enum.GetValues(typeof(Product)))
            {
                ProductsInside.Add(product.ToString(), Capacity);
                itemsList.Add(product.ToString());

            }
        }

    }

}