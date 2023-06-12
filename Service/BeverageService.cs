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
        public void AddBeverages(IEnumerable<BeverageDto> beverageDto)
        {
            var beverageEntity = _mapper.Map<IEnumerable<Beverage>>(beverageDto);
            _repository.AddBeverages(beverageEntity);
        }

        public void DeleteBeverage(int beverageId)
        {
            var beverage = _repository.GetBeverageById(beverageId);
            _repository.DeleteBeverage(beverage);
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

        public void UpdateBeverage(BeverageDto beverageDto)
        {
            var beverage = _mapper.Map<Beverage>(beverageDto);
            _repository.UpdateBeverage(beverage);
        }
    }
}
