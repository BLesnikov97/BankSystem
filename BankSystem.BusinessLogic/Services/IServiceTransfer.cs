using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public interface IServiceTransfer
    {
        void Transfer(Account forAccount, Account toAccount, double sum);
    }
}
