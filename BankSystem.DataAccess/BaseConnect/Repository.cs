using BankSystem.BusinesLogic.Model;
using BankSystem.BusinesLogic.Services;
using Microsoft.EntityFrameworkCore;
using BankSystem.DataAccess.BaseConnect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BusinesLogic.BaseConnect;

namespace BankSystem.DataAccess.BaseConnect
{
    public class Repository : IRepository
    {
        private ApplicationContext _db;

        public Repository(ApplicationContext db)
        {
            _db = db;
        }

        public void Create(UserAccount user)
        {
            _db.UserAccaunts.Add(user);
            Save();
        }

        public void Delete(int id)
        {
            UserAccount userAccount = _db.UserAccaunts.Find(id);

            if (userAccount != null)
            {
                _db.Remove(userAccount);
            }
        }

        public List<UserAccount> GetUsersAccountList()
        {
            return _db.UserAccaunts.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(UserAccount user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }
    }
}
