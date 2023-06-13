using Contracts;
using Entities.Models;

namespace Repository
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly RepositoryContext _context;
        public BeverageRepository(RepositoryContext context) 
            => _context = context;

        public void AddBeverages(IEnumerable<Beverage> beverages)
        {
            foreach (var newBeverage in beverages)
            {
                var beverage = _context.Beverages.FirstOrDefault(b=>b.Id == newBeverage.Id);
                if (beverage != null)
                {
                    beverage.Count += newBeverage.Count; 
                }
            }
            SaveChanges();
        }

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

        public IEnumerable<Beverage> GetAvaliableBeverages()
        => _context.Beverages.Where(b => b.Count > 0);

        public Beverage GetBeverageById(int id)
        {
            var beverage = _context.Beverages.FirstOrDefault(b=>b.Id == id);
            return beverage ?? throw new Exception();
        }

        public IEnumerable<Beverage> GetBeverages()
             => _context.Beverages.ToList();

        public void SubtractBeverages(IEnumerable<Beverage> beverages)
        {
            foreach (var newBeverage in beverages)
            {
                var beverage = _context.Beverages.FirstOrDefault(b => b.Id == newBeverage.Id);
                if (beverage != null)
                {
                    beverage.Count -= newBeverage.Count;
                }
            }
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
