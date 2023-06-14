using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class BeverageService : IBeverageService
    {
        private readonly IBeverageRepository _repository;
        private readonly IMapper _mapper;

        public BeverageService(IBeverageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Addbeverage(int beverageId, int count)
        {
            _repository.AddBeverage(beverageId, count);
            return true;
        }

        public bool DeleteBeverage(int beverageId)
        {
            var beverage = _repository.GetBeverageById(beverageId);
            _repository.DeleteBeverage(beverage);
            return true;
        }

        public IEnumerable<BeverageDto> GetAllBeverages()
        {
            var beverages = _repository.GetBeverages();
            var beveragesToReturn = _mapper.Map<IEnumerable<BeverageDto>>(beverages);
            return beveragesToReturn;
        }

        public IEnumerable<BeverageDto> GetAvailableBeverages()
        {
            var beverages = _repository.GetAvaliableBeverages();
            var beveragesToReturn = _mapper.Map<IEnumerable<BeverageDto>>(beverages);
            return beveragesToReturn;
        }

        public BeverageDto GetBeverageById(int beverageId)
        {
            var beverage = _repository.GetBeverageById(beverageId);
            var beverageToReturn = _mapper.Map<BeverageDto>(beverage);
            return beverageToReturn;
        }

        public bool SubtractBeverage(int beverageId)
        {
            _repository.SubtractBeverages(beverageId);
            return true;
        }

        public bool UpdateBeverage(BeverageDto beverageDto)
        {
            var beverage = _mapper.Map<Beverage>(beverageDto);
            _repository.UpdateBeverage(beverage);
            return true;
        }
    }
}
