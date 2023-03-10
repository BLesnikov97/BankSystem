using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Repositories
{
    public interface IRepository
    {
        List<User> GetUsersList();
        void CreateUser(User user);
        void Delete(int id);
        void Save();

        List<Account> GetAccountsList();
        void CreateAccount(Account account);
        void DeleteAccount(User id);
    }
}


