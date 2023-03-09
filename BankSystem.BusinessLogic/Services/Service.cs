using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;
using BankSystem.BusinessLogic.Repositories;

namespace BankSystem.BusinesLogic.Services
{
    public class Service : IService
    {
        private List<User> _users;

        private IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
            _users = _repository.GetUsersList();
        }

        //public void CheckCash(Account account)
        //{
        //    if (account.Amount < 100)
        //    {
        //        throw new Exception("Cash not filled");
        //    }
        //}

        public void AddUser(string lastName, string firstName, string middleName, DateTime birthday, Gender gender)
        {
            User user = new User(lastName, firstName, middleName, birthday, gender);

            _repository.CreateUser(user);                        
        }

        public void AddAccount(User user, string description, double amount, string currency)
        {


            user.Accounts.Add(new Account(user, description, amount, currency));         

            _repository.Save();
        }
    }
}
