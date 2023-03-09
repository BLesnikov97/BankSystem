using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public interface IService
    {
        void CheckCash(Account account);

        void AddUser(string lastName, string firstName, string middleName, DateTime birthday, Gender gender);

        void AddAccount(User user, string description, double amount, string currency);
    }
}
