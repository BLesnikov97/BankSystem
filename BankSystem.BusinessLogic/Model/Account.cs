using BankSystem.BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Model
{
    public class Account
    {   
        public int Id { get; protected set; }

        public int UserId { get; protected set; }

        public User Owner { get; protected set; }

        public string Description { get; protected set; }

        public double Amount { get; protected set; }

        public string Currency { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public Nullable<DateTime> ModifiedDate { get; protected set; }

        public bool IsBlocked { get; protected set; }

        protected Account()
        {

        }



        public Account(User owner, string description, double amount, string currency)
        {
            if (owner == null)
            {
                throw new Exception(ExceptionMessages.ExceptionOwner);
            }
            if (Description == "")
            {
                throw new Exception(ExceptionMessages.ExceptionDescription);
            }
            if (Amount == null & Amount > 0)
            {
                throw new Exception(ExceptionMessages.ExceptionAmount);
            }
            if (Currency == "")
            {
                throw new Exception(ExceptionMessages.ExceptionCurrency);
            }

            UserId = owner.Id;

            Owner = owner;
            this.Description = description;
            this.Amount = amount;
            this.Currency = currency;
            this.CreatedDate = DateTime.Now.ToUniversalTime(); 
            this.ModifiedDate = DateTime.Now.ToUniversalTime();
            this.IsBlocked = false;               
        }

        public void AddAmount(Account account, double sum)
        {
            account.Amount += sum;
            account.ModifiedDate = DateTime.Now.ToUniversalTime();
        }

        public void TakeAmount(Account account, double sum)
        {
            if (account.Amount < sum)
            {
                throw new Exception("Amount not filled");
            }

            account.Amount -= sum;
            account.ModifiedDate = DateTime.Now.ToUniversalTime();
        }
    }
}
