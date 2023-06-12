using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class CoinService : ICoinService
    {
        private readonly ICoinRepository _repository;
        private readonly IMapper _mapper;

        public CoinService(ICoinRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void AddCoin(int coinId, int count)
        {
            var coinEntity = _repository.GetCoin(coinId);
            _repository.AddCoinToMachine(coinEntity.Id, count);
        }

        public void SubtractCoin(int coinId, int count)
        => _repository.SubtractCointFromMachine(coinId, count);
        

        public IEnumerable<CoinDto> GetAllCoins()
        {
            var coinsEntity = _repository.GetAllCoins();
            var coinsDto = _mapper.Map<IEnumerable<CoinDto>>(coinsEntity);
            return coinsDto;
        }

        public IEnumerable<CoinDto> GetAvailableCoins()
        {
            var coins = _repository.GeAvaliabletCoins();
            var coinsDto = _mapper.Map<IEnumerable<CoinDto>>(coins);
            return coinsDto;
        }

        public CoinDto GetCoinById(int coinId)
        {
            var coin = _repository.GetCoin(coinId);
            return _mapper.Map<CoinDto>(coin);
        }

        public void UpdateCoin(int coinId)
        {
            var coinEntity = _repository.GetCoin(coinId);
            _repository.UpdateCoin(coinEntity);
        }

        public IEnumerable<CoinDto> Surrender(IEnumerable<CoinDto> coinList, IEnumerable<BeverageDto> beverages)
        {
            var coinsEntity = _mapper.Map<IEnumerable<Coin>>(coinList);
            var beveragesEntity = _mapper.Map<IEnumerable<Beverage>>(beverages);

            var coins = _repository.Surrender(coinsEntity, beveragesEntity);
            var coinsToReturn = _mapper.Map<IEnumerable<CoinDto>>(coins);
            return coinsToReturn;
        }
    }
}
