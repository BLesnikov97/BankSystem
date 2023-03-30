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
            if(repository == null)
                throw new Exception(ExceptionMessages.ExceptionRepository);

            _repository = repository;

        }

        public void Transfer(Account forAccount, Account toAccount, double sum)
        {

            if (forAccount == null)
                throw new Exception(ExceptionMessages.ExceptionWithdrawal);

            if (toAccount == null)
                throw new Exception(ExceptionMessages.ExceptionUp);

            if (forAccount.Id == toAccount.Id)
                throw new Exception(ExceptionMessages.ExceptionAccounts);

            if (forAccount.Amount < sum)
                throw new Exception(ExceptionMessages.ExceptionMinAmount);

            if (sum <= 0.00D)
                throw new Exception(ExceptionMessages.ExceptionAmount);

            if (toAccount.IsBlocked == true)
                throw new Exception(ExceptionMessages.ExceptionAccountIsBlocked);

            toAccount.AddAmount(sum);
            forAccount.TakeAmount(sum);

            _repository.Save();
        }
    }
}
