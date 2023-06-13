using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBeverageRepository> _beverageRepository;
        private readonly Lazy<ICoinRepository> _coinRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _beverageRepository = new Lazy<IBeverageRepository>(() => new BeverageRepository(context));
            _coinRepository = new Lazy<ICoinRepository>(() => new CoinRepository(context));
        }
        public IBeverageRepository Beverage => _beverageRepository.Value;
        public ICoinRepository Coin => _coinRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
