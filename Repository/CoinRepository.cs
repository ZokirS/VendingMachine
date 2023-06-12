using Contracts;
using Entities.Models;

namespace Repository
{
    public class CoinRepository : ICoinRepository
    {
        private readonly RepositoryContext _context;
        public CoinRepository(RepositoryContext context)
        => _context = context;

        public void AddCoinToMachine(int coinId, int count)
        {
            var coin = _context.Coins.FirstOrDefault(c=>c.Id == coinId) 
                ?? throw new Exception("Coin not found");
            coin.Count += count;
            SaveChanges();
        }

        public void CreateCoin(Coin coin)
        {
            var coinToAdd = _context.Coins.FirstOrDefault(c => c.Value == coin.Value);
            if (coinToAdd != null)
                throw new Exception($"Coin with {coin.Value} value is already exists in DB");
            _context.Coins.Add(coinToAdd);
            SaveChanges();
        }

        public IEnumerable<Coin> GeAvaliabletCoins()
        {
            var coins = _context.Coins.Where(c=>c.Available);
            return coins;
        }

        public IEnumerable<Coin> GetAllCoins()
            => _context.Coins.ToList();
        
        public Coin GetCoin(int coinId)
        {
            var coin = _context.Coins.FirstOrDefault(c => c.Id == coinId);
            if (coin is null) throw new Exception();
            return coin;
        }

        public void SubtractCointFromMachine(Coin coin)
        {
            var coinToSubtract = _context.Coins.FirstOrDefault(c => c.Id == coin.Id)
                ?? throw new Exception();

            coinToSubtract.Count = coinToSubtract.Count - coin.Count;
            _context.Coins.Update(coinToSubtract);
            SaveChanges();
        }

        public IEnumerable<Coin> Surrender(IEnumerable<Coin> inputCoins, IEnumerable<Beverage> beverages)
        {
            // Calculate the total value of the input coins
            int inputTotal = inputCoins.Sum(coin => coin.Value * coin.Count);

            // Calculate the total price of the selected beverages
            var beveragesTotal = beverages.Sum(beverage => beverage.Price);

            // Calculate the change to be returned
            int change = inputTotal - (int)beveragesTotal;

            if (change < 0)
            {
                // Insufficient funds, return an empty collection
                return new List<Coin>();
            }

            // Create a list to hold the surrendered coins
            List<Coin> surrenderedCoins = new List<Coin>();

            // Iterate through the input coins in descending order of Value
            foreach (Coin inputCoin in inputCoins.OrderByDescending(coin => coin.Value))
            {
                int quantityToSurrender = Math.Min(change / inputCoin.Value, inputCoin.Count);

                if (quantityToSurrender > 0)
                {
                    // Add the surrendered coins to the list
                    surrenderedCoins.Add(new Coin
                    {
                        Value = inputCoin.Value,
                        Count = quantityToSurrender
                    });

                    // Update the change amount
                    change -= quantityToSurrender * inputCoin.Value;
                }

                if (change == 0)
                {
                    // No more change to give, exit the loop
                    break;
                }
            }

            return surrenderedCoins;
        }

        public void UpdateCoin(Coin coin)
        {
            _context.Update(coin);
            SaveChanges();
        }

        private void SaveChanges() => _context.SaveChanges();
        
    }
}
