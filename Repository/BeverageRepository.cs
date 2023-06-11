using Contracts;
using Entities.Models;

namespace Repository
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly RepositoryContext _context;
        public BeverageRepository(RepositoryContext context) 
            => _context = context;
        public void CreateBeverage(Beverage beverage)
        {
            _context.Beverages.Add(beverage);
            SaveChanges();
        }

        public void DeleteBeverage(Beverage beverage)
        {
            _context.Beverages.Remove(beverage);
            SaveChanges();
        }

        public Beverage GetBeverageById(int id)
        {
            var beverage = _context.Beverages.FirstOrDefault(b=>b.Id == id);
            return beverage ?? throw new Exception();
        }

        public ICollection<Beverage> GetBeverages()
        {
            var beverages = _context.Beverages.ToList();
            return beverages;
        }

        public void UpdateBeverage(Beverage beverage)
        {
            _context.Beverages.Update(beverage);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
