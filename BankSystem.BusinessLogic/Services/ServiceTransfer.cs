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
            if(repository != null)
                _repository = repository;

            else
                throw new Exception(ExceptionMessages.ExceptionRepository);
        }

        public void Transfer(Account forAccount, Account toAccount, double sum)
        {
                if (forAccount.Amount >= sum 
                && sum > 0.00D 
                && toAccount.IsBlocked != true && forAccount.Id != toAccount.Id && forAccount != null && toAccount != null)
                {
                    toAccount.AddAmount(sum);
                    forAccount.TakeAmount(sum);

                    _repository.Save();
                }
                else              
                    throw new Exception(ExceptionMessages.ExceptionInsufficientAmount);        
        }
    }
}
