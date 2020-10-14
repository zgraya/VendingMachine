namespace VendingMachine
{
    public class Coin
    {
        public int value { get; set; }
        public int weight { get; set; }
        public int diameter { get; set; }

        public Coin(int _weight, int _diameter, int _value)
        {
            value = _value;
            weight = _weight;
            diameter = _diameter;
        }
    }
}