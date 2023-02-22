using BankSystem.BusinesLogic.Model;
using BankSystem.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinesLogic.BaseConnect
{
    public interface IRepository
    {
        List<User> GetUsersAccountList();
        void Create(User user);
        void Update(User user);
        void Delete(int id);
        void Save();
    }
}


