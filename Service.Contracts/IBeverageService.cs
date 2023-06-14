using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IBeverageService
    {
        IEnumerable<BeverageDto> GetAllBeverages();
        IEnumerable<BeverageDto> GetAvailableBeverages();
        BeverageDto GetBeverageById(int beverageId);
        bool UpdateBeverage(BeverageDto beverageDto);
        bool DeleteBeverage(int beverageId);
        bool SubtractBeverage(int beverageId);
        bool Addbeverage(int beverageId, int count);
    }
}
