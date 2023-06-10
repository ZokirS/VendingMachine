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

        public VendingMachine GetVendingMachineModel()
        {
            throw new NotImplementedException();
        }

        public void InsertCoin(int coin)
        {
            throw new NotImplementedException();
        }

        public OperationResult SelectBeverage(string beverageId)
        {
            throw new NotImplementedException();
        }
    }
}
