using BankSystem.BusinesLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceDep : IServiceDep
    {
        private IServiceRepository _db;

        public ServiceDep(IServiceRepository db)
        {
            _db = db;
        }

        public void Dep(UserAccount user)
        {
            string depFullName = user.FullName + " / вклад 5%";
            string depCash = Convert.ToString(user.Cash / 100 * 5);

            _db.AddUser(depFullName, depCash);
        }
    }
}
