using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceTransfer : IServiceTransfer
    {
        private IRepository _repository;

        public ServiceTransfer(IRepository repository)
        {
            _repository = repository;
        }

        public void Transfer(Account forAccount, Account toAccount, double sum)
        {
            if (forAccount.Amount >= sum & toAccount.IsBlocked != true & forAccount.Id != toAccount.Id)
            {
                toAccount.Amount += sum;
                toAccount.ModifiedDate = DateTime.Now.ToUniversalTime();

                forAccount.Amount -= sum;
                forAccount.ModifiedDate = DateTime.Now.ToUniversalTime();

                _repository.Save();
            }
            else
            {
                throw new Exception("Insufficient funds or transfer to yourself");
            }
        }
    }
}
