﻿using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private List<UserAccount> _userAccaunts;

        private IRepository _db;

        public ServiceRepository(IRepository repository)
        {
            _db = repository;
            _userAccaunts = _db.GetUsersAccountList();
        }

        public void CheckCash(UserAccount user)
        {
            if (user.Cash < 100)
            {
                throw new Exception("Cash not filled");
            }
        }

        private bool ExistsList(string user)
        {
            var resultSearch = _userAccaunts.Find(userList => userList.FullName == user);

            if (resultSearch != null)
            {
                throw new Exception("Cash not filled");
            }

            return true; 
        }

        public void AddUser(string fullName, string cash)
        {
            if (fullName == "" & ExistsList(fullName))
            {
                throw new Exception("Full name not filled");
            }

            UserAccount user = new UserAccount(fullName, Convert.ToInt32(cash));

            _db.Create(user);                        
        }
    }
}
