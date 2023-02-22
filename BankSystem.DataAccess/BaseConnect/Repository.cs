using BankSystem.BusinesLogic.Model;
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

        public void Create(User user)
        {
            _db.Users.Add(user);
            Save();
        }

        public void Delete(int id)
        {
            User userAccount = _db.Users.Find(id);

            if (userAccount != null)
            {
                _db.Remove(userAccount);
            }
        }

        public List<User> GetUsersAccountList()
        {
            return _db.Users.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }
    }
}
