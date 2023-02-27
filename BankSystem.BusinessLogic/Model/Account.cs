using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Model
{
    public class Account
    {
        public User UserId { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<DateTime> ModifiedDate { get; set; }

        public bool IsBlocked { get; set; }

        public Account()
        {

        }



        public Account(User UserId, string Description, double Amount, string Currency)
        {
            this.UserId = UserId;
            this.Description = Description;
            this.Amount = Amount;
            this.Currency = Currency;
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = null;
            this.IsBlocked = false;
        }

        public void AddAmount_100(Account account)
        {
            account.Amount = account.Amount + 100;
        }

        public void TakeAmount_100(Account account)
        {
            account.Amount = account.Amount - 100;
        }
    }
}
