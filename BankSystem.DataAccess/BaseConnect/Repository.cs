using Microsoft.EntityFrameworkCore;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

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

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);

            if (user != null)
            {
                _db.Remove(user);
            }
        }

        public void DeleteAccount(User id)
        {
            Account account = _db.Accounts.Find(id);
            if (account != null)
            {
                _db.Remove(account);
            }
        }

        public List<Account> GetAccountsList()
        {
            return _db.Accounts.ToList();
        }

        public List<User> GetUsersList()
        {
            return _db.Users.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateAccount(Account account)
        {
            _db.Entry(account).State = EntityState.Modified;
        }

        public void UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }
    }
}
