using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public interface IServiceRepository
    {
        void CheckCash(Account account);

        void AddUser(string LastName, string FirstName, string MiddleName, DateTime Birthday, Gender Gender);

        void AddAccount(User UserId, string Description, double Amount, string Currency);
    }
}
