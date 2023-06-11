using Contracts;
using Entities.Models;

namespace Repository
{
    public class VendingMachineRepository : RepositoryBase<VendingMachine>, IVendingMachineRepository
    {
        public VendingMachineRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}

        public OperationResult GetChange()
        {
            throw new NotImplementedException();
        }

        public VendingMachine GetVendingMachineModel(bool trackChanges)
        => FindAll(trackChanges).FirstOrDefault();

        public void InsertCoin(int coin)
        {
        }

        public OperationResult SelectBeverage(string beverageId)
        {
            throw new NotImplementedException();
        }
    }
}
