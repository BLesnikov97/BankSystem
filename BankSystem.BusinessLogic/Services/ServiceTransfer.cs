using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinessLogic.Exceptions;
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
            if (forAccount.Amount >= sum && toAccount.IsBlocked != true && forAccount.Id != toAccount.Id)
            {   
                toAccount.AddAmount(toAccount, sum);
                forAccount.TakeAmount(forAccount, sum);

                _repository.Save();
            }
            else
                throw new Exception(ExceptionMessages.ExceptionInsufficientAmount);
        }
    }
}
