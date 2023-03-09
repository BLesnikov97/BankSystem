using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceTransfer : IServiceTransfer
    {
        private IRepository _repository;

        public ServiceTransfer(IRepository db)
        {
            _repository = db;
        }

        public void Transfer(Account forAccount, Account toAccount)
        {
            if (forAccount.Amount >= 100 & toAccount.IsBlocked != true & forAccount.Id != toAccount.Id)
            {
                toAccount.Amount = toAccount.Amount + 100;
                toAccount.ModifiedDate = DateTime.Now.ToUniversalTime();

                forAccount.Amount = forAccount.Amount - 100;
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
