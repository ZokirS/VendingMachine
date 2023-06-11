using Entities.Models;

namespace Contracts
{
    public interface IAdminRepository
    {
        List<Beverage> GetAllBeverages();
        Beverage GetBeverageById(string id);
        void AddBeverage(Beverage beverage);
        void UpdateBeverage(Beverage beverage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>-1 if the id was not found, other number is for affected rows</returns>
        int DeleteBeverage(int id);
    }
}
