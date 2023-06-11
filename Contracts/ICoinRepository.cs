using Entities.Models;

namespace Contracts
{
    public interface ICoinRepository
    {
        void AddCoinToMachine(int coinId, int count);
        void SubtractCointFromMachine(Coin coin);
        void CreateCoin(Coin coin);
        ICollection<Coin> Surrender(ICollection<Coin> inputCoins, ICollection<Beverage> beverages);
        ICollection<Coin> GetAllCoins();
        Coin GetCoin(int coinId);
    }
}
