using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICoinService
    {
        IEnumerable<CoinDto> GetAllCoins();
        CoinDto GetCoinById(int coinId);
        void AddCoin(int coinId, int count);
        void UpdateCoin(int coinId);
        void SubtractCoin(int coinId, int count);
        IEnumerable<CoinDto> GetAvailableCoins();
        IEnumerable<CoinDto> Surrender(int changeAmount);
    }
}
