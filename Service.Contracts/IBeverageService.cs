using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IBeverageService
    {
        IEnumerable<BeverageDto> GetAllBeverages();
        BeverageDto GetBeverageById(int beverageId);
        void AddBeverages(IEnumerable<BeverageDto> beverageDto);
        void UpdateBeverage(BeverageDto beverageDto);
        void DeleteBeverage(int beverageId);
        IEnumerable<BeverageDto> GetAvailableBeverages();
    }
}
