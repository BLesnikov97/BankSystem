using BankSystem.BusinesLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinesLogic.Services
{
    public interface IServiceDep
    {
        void Dep(UserAccount user);
    }
}
