using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.BusinessLogic.Model
{
    public class User
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<DateTime> ModifiedDate { get; set; }

        public bool IsBlocked { get; set; }

        public ICollection<Account> Accounts { get; set; }


        public User()
        {

        }

        public User(string LastName, string FirstName, string MiddleName, DateTime Birthday, Gender Gender)
        {
            Random Id = new Random();

            int value = Id.Next(0, 99999);

            this.Id = value;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.Birthday = Birthday.ToUniversalTime();
            this.Gender = Gender;
            this.CreatedDate = DateTime.Now.ToUniversalTime();
            this.ModifiedDate = null;
            this.IsBlocked = false;

            Accounts = new List<Account>();



        }
    }
}
