using Microsoft.EntityFrameworkCore;
using BankSystem.BusinessLogic.Model;
using BankSystem.BusinesLogic.Repositories;

namespace BankSystem.DataAccess.BaseConnect
{
    public class Repository : IRepository
    {
        private ApplicationContext _db;

        public Repository(ApplicationContext db)
        {
            _db = db;
        }

        public void CreateAccount(Account account)
        {
            _db.Accounts.Add(account);
            Save();
        }

        public void CreateUser(User user)
        {
            _db.Users.Add(user);
            Save();
        }

        public void DeleteUser(User user)
        {
            Account userSearch = _db.Accounts.FirstOrDefault(x => x.Id == user.Id);

            if (userSearch != null)
            {
                _db.Remove(userSearch);
            }
            Save();
        }

        public void DeleteAccount(User user)
        {
            Account accountSearch = _db.Accounts.FirstOrDefault(x => x.Id == user.Id);
            if (accountSearch != null)
            {
                _db.Remove(accountSearch);
            }
            Save();
        }

        public List<Account> GetAccountsList()
        {
            return _db.Accounts.ToList();
        }

        public List<User> GetUsersList()
        {
            return _db.Users.Include(x => x.Accounts).ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public bool CheckUser(User user)
        {
            var _users = GetUsersList();
            var resultSearch = _users.Find(userList => userList.Id == user.Id);

            if (resultSearch != null)
            {
                throw new Exception("Existing user");
            }

            return true;
        }
    }
}
