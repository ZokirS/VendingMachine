using Entities.Models;

namespace Contracts
{
    public interface ICoinRepository
    {
        void AddCoinToMachine(int coinId, int count);
        void SubtractCointFromMachine(int coinId, int count);
        void CreateCoin(Coin coin);
        IEnumerable<Coin> Surrender(int changeAmount);
        IEnumerable<Coin> GetAllCoins();
        IEnumerable<Coin> GeAvaliabletCoins();
        Coin GetCoin(int coinId);
        void UpdateCoin(Coin coin);

    }
}
