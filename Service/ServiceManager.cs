using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICoinService> _coinService;
        private readonly Lazy<IBeverageService> _beverageService;

        public ServiceManager(ICoinRepository coinRepository, IBeverageRepository beverageRepository, IMapper mapper)
        {
            _coinService = new Lazy<ICoinService>(new CoinService(coinRepository, mapper));
            _beverageService = new Lazy<IBeverageService>(new BeverageService(beverageRepository, mapper));
        }

        public ICoinService CoinService => _coinService.Value;

        public IBeverageService BeverageService => _beverageService.Value;
    }
}
