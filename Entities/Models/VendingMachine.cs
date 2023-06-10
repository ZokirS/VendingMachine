namespace Entities.Models
{
    public class VendingMachine
    {
        public List<Beverage> Beverages { get; set; }
        public int AmountInserted { get; set; }
        public List<Coin> CoinsInside { get; set; }
    }
}
