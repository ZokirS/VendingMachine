using Entities.Models;

namespace Contracts
{
    public interface IBeverageRepository
    {
        void CreateBeverage(Beverage beverage);
        void UpdateBeverage(Beverage beverage);
        void DeleteBeverage(Beverage beverage);
        ICollection<Beverage> GetBeverages();
        Beverage GetBeverageById(int id);
    }
}
