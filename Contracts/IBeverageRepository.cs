using Entities.Models;

namespace Contracts
{
    public interface IBeverageRepository
    {
        void CreateBeverage(Beverage beverage);
        void UpdateBeverage(Beverage beverage);
        void DeleteBeverage(Beverage beverage);
        void AddBeverages(IEnumerable<Beverage> beverages);
        void SubtractBeverages(IEnumerable<Beverage> beverages);
        IEnumerable<Beverage> GetBeverages();
        Beverage GetBeverageById(int id);
        IEnumerable<Beverage> GetAvaliableBeverages();
    }
}
