using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICoinService
    {
        IEnumerable<CoinDto> GetAllCoins();
        CoinDto GetCoinById(int coinId);
        void AddCoin(CoinDto coin);
        void UpdateCoin(CoinDto coin);
        void SubtractCoin(int coinId);
        IEnumerable<CoinDto> GetAvailableCoins();
        IEnumerable<CoinDto> Surrender(IEnumerable<CoinDto> coinList, IEnumerable<BeverageDto> beverages);
    }
}
