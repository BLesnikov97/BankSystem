using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private List<User> _users;

        private IRepository _db;

        public ServiceRepository(IRepository repository)
        {
            _db = repository;
            _users = _db.GetUsersList();
        }

        public void CheckCash(Account account)
        {
            if (account.Amount < 100)
            {
                throw new Exception("Cash not filled");
            }
        }

        private bool ExistsList(string FirstName)
        {
            var resultSearch = _users.Find(userList => userList.FirstName == FirstName);

            if (resultSearch != null)
            {
                throw new Exception("Cash not filled");
            }

            return true; 
        }

        public void AddUser(string LastName, string FirstName, string MiddleName, DateTime Birthday, Gender Gender)
        {
            if (FirstName == "" & ExistsList(FirstName))
            {
                throw new Exception("Full name not filled");
            }

            User user = new User(LastName, FirstName, MiddleName, Birthday, Gender);

            _db.CreateUser(user);                        
        }

        public void AddAccount(User UserId, string Description, double Amount, string Currency)
        {
            if (UserId == null)
            {
                throw new Exception("User not filled");
            }

            Account account = new Account(UserId, Description, Amount, Currency = "Рублевый");

            _db.CreateAccount(account);
        }
    }
}
