using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class CoinReserve
    {
        public enum CoinTypes
        {
            nickle = 5, dime = 10, quarter = 25
        }

        public int[] changeGiven = new int[3];

        private int Quantity = 100;

        private Dictionary<CoinTypes, int> Coin { get; set; }
        
        public void GiveChange(int _change)
        {
            int change = _change;
            
            if (change / (int) CoinTypes.quarter > Coin[CoinTypes.quarter])
            {
                int rest = change - Coin[CoinTypes.quarter] * (int) CoinTypes.quarter;
                changeGiven[2] = Coin[CoinTypes.quarter];
                Coin[CoinTypes.quarter] = 0;
                change = rest;
            }
            else
            {
                int rest = change % (int) CoinTypes.quarter;
            }
            
        }

        public CoinReserve()
        {
            foreach (CoinTypes Type in Enum.GetValues(typeof(CoinTypes)))
            {
                Coin.Add(Type, Quantity);
            }
        }

    }
}