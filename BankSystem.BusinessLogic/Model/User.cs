using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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


        protected User()
        {
            Accounts = new List<Account>();
        }

        public User(string lastName, string firstName, string middleName, DateTime birthday, Gender gender) : this()
        {
            Random Id = new Random();

            int value = Id.Next(0, 99999);

            this.Id = value;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Birthday = birthday.ToUniversalTime();
            this.Gender = gender;
            this.CreatedDate = DateTime.Now.ToUniversalTime();
            this.ModifiedDate = DateTime.Now.ToUniversalTime();
            this.IsBlocked = false;

            if (LastName == "")
            {
                throw new Exception("LastName not filled");
            }
            if (FirstName == "")
            {
                throw new Exception("FirstName not filled");
            }
            if (MiddleName == "")
            {
                throw new Exception("MiddleName not filled");
            }
        }

        public void AddAccount()
        {

        }
    }
}
