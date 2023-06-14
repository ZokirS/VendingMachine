using Entities.Models;

namespace Contracts
{
    public interface IBeverageRepository
    {
        void CreateBeverage(Beverage beverage);
        void UpdateBeverage(Beverage beverage);
        void DeleteBeverage(Beverage beverage);
        void AddBeverage(int Id, int count);
        void SubtractBeverages(int beverageId);
        IEnumerable<Beverage> GetBeverages();
        Beverage GetBeverageById(int id);
        IEnumerable<Beverage> GetAvaliableBeverages();
    }
}
