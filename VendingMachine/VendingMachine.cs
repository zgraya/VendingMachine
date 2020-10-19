using System;
using System.Collections.Generic;
using System.Threading;
using VendingMachine.Products;

namespace VendingMachine
{
    public class VendingMachine
    {
        private CoinReserve Reserve = new CoinReserve();
        private Inventory inventory = new Inventory();
        
        public int Credit = 0;
        public void InsertCoin()
        {
            Console.WriteLine($"Please insert coin(dime,quarter or nickel) and confirm it's value:");
            
            var coin = Console.ReadLine();
            
            CheckCoin(coin);
            
            Thread.Sleep(3000);
            Console.Clear();
            DisplayMenu();
            
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"AVAILABLE BALANCE: {Credit} cents." +
                              $"Press the button for:" +
                              $"1. INSERT COIN" +
                              $"2. CHOOSE ITEM" +
                              $"3. RETURN COIN" +
                              $"4. END");

        }
        


        public void CheckCoin(string coin)
        {
            bool countHelper = false;
            foreach (CoinReserve.CoinTypes Type in Enum.GetValues(typeof(CoinReserve.CoinTypes)))
            {
                if (Type.ToString() == coin)
                {
                    Credit += (int) Type;
                    countHelper = true;
                    break;
                }
            }

            if (!countHelper)
            {
             Console.WriteLine($"Invalid currency - please take your money from coin return.");
            }
            
        }

        public void ChooseProduct()
        {
            Console.WriteLine($"Choose an item:" +
                              $"1. COLA" +
                              $"2. CHIPS" +
                              $"3. CANDY");
            
            string choice = Console.ReadLine();
            int chosen;

            var checker = int.TryParse(choice, out chosen);

            if (checker)
            {
                if (inventory.itemsList.Count < chosen)
                {
                    Console.WriteLine("Choose correct number.");
                }
                else
                {
                    string item = Enum.GetName(typeof(Inventory.Product), chosen);
                    int quantity = inventory.ProductsInside[item];
                    if (quantity > 0)
                    {
                        int price = (int) Enum.Parse(typeof(Inventory.Product), item);
                        if (Credit < price)
                        {
                            Console.WriteLine($"Not enough credit.");
                        }
                        else
                        {
                            inventory.ProductsInside[item] = inventory.ProductsInside[item] - 1;
                            Credit = Credit - price;
                            Console.WriteLine($"Transaction complete. You can now collect your purchase.");
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ITEM OUT OF STOCK.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Choose correct number.");
            }

            

        }
        
        
    }
}