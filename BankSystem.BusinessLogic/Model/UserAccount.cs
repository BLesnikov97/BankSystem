using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinesLogic.Model
{
    public class UserAccount
    {
        public string FullName { get; set; }

        public int Cash { get; set; }

        public int Id { get; protected set; }

        public UserAccount()
        {

        }

        public UserAccount(string FullName, int Cash)
        {
            Random ID = new Random();

            int value = ID.Next(0, 99999);

            this.FullName = FullName;
            this.Cash = Cash;
            this.Id = value;

        }

        public void AddCash(UserAccount user)
        {
            user.Cash += 100;
        }

        public void TakeCash(UserAccount user)
        {
            user.Cash -= 100;
        }
    }
}
