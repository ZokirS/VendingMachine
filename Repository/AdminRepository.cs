using Contracts;
using Entities.Models;

namespace Repository
{
    public class AdminRepository :  IAdminRepository
    {
        private readonly RepositoryContext _repository;
        public AdminRepository(RepositoryContext repository) 
            => _repository = repository;

        public void AddBeverage(Beverage beverage)
        {
            _repository.Beverages.Add(beverage);
            _repository.SaveChanges();
        }

        public int DeleteBeverage(int id)
        {
            var beverage = _repository.Beverages.FirstOrDefault(b=>b.Id == id);
            _repository.Beverages.Remove(beverage);
            return _repository.SaveChanges();
        }

        public List<Beverage> GetAllBeverages()
        {
            return _repository.Beverages.ToList();
        }

        public Beverage GetBeverageById(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBeverage(Beverage beverage)
        {
            throw new NotImplementedException();
        }
    }
}
