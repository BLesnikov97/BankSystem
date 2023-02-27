using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceTransfer : IServiceTransfer
    {
        private IRepository _db;

        public ServiceTransfer(IRepository db)
        {
            _db = db;
        }

        public void Transfer(Account forAccount, Account toAccount)
        {
            if (forAccount.Amount >= 100 & toAccount.IsBlocked != true & forAccount.Description != toAccount.Description)
            {
                toAccount.Amount = toAccount.Amount + 100;
                forAccount.Amount = forAccount.Amount - 100;

                _db.Save();
            }
            else
            {
                throw new Exception("Insufficient funds or transfer to yourself");
            }
        }
    }
}
