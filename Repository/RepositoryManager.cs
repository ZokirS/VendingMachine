using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IVendingMachineRepository> _vendingMachine;
        private readonly Lazy<IAdminRepository> _adminRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _vendingMachine = new Lazy<IVendingMachineRepository>(() => new VendingMachineRepository(context));
            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(context));
        }
        public IVendingMachineRepository VendingMachine => _vendingMachine.Value;
        public IAdminRepository Admin => _adminRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
