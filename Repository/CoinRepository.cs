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

        public void SubtractCointFromMachine(int coinId, int count)
        {
            var coinToSubtract = _context.Coins.FirstOrDefault(c => c.Id == coinId)
                ?? throw new Exception();

            coinToSubtract.Count = coinToSubtract.Count - count;
            _context.Coins.Update(coinToSubtract);
            SaveChanges();
        }

        public IEnumerable<Coin> Surrender(int changeAmount)
        {
            var coins = new List<Coin>();
            while(changeAmount != 0)
            {
                var coin = _context.Coins.OrderByDescending(x => x.Value).FirstOrDefault(x=>x.Value <= changeAmount && x.Count>0);
                coins.Add(new Coin
                {
                    Value = coin.Value,
                    Count = 1
                });
                changeAmount -= coin.Value;
                coin.Count--;
                UpdateCoin(coin);
            }
            return coins;
        }

        public void UpdateCoin(Coin coin)
        {
            _context.Update(coin);
            SaveChanges();
        }

        private void SaveChanges() => _context.SaveChanges();
        
    }
}
