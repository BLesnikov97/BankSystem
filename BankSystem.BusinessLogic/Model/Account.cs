using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Model
{
    public class Account
    {   
        public int Id { get; set; }

        public int UserId { get; set; }

        public User Owner { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<DateTime> ModifiedDate { get; set; }

        public bool IsBlocked { get; set; }

        protected Account()
        {

        }



        public Account(User owner, string description, double amount, string currency)
        {
            UserId = owner.Id;

            Owner = owner;
            this.Description = description;
            this.Amount = amount;
            this.Currency = currency;
            this.CreatedDate = DateTime.Now.ToUniversalTime(); 
            this.ModifiedDate = null;
            this.IsBlocked = false;

            if (Description == "")
            {
                throw new Exception("Description not filled");
            }
            if (Amount == "")
            {
                throw new Exception("Amount not filled");
            }
            if (Currency == "")
            {
                throw new Exception("Currency not filled");
            }
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
