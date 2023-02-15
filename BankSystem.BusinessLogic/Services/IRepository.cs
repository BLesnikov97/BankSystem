using BankSystem.BusinesLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinesLogic.BaseConnect
{
    public interface IRepository
    {
        List<UserAccount> GetUsersAccountList();
        void Create(UserAccount user);
        void Update(UserAccount user);
        void Delete(int id);
        void Save();
    }
}


