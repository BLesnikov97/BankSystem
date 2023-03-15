using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.BusinesLogic.Repositories;
using System.ComponentModel;
using System;
using ControlzEx.Standard;
using System.Security.Principal;
using System.Windows.Input;

namespace BankSystem.Client.WPF.UI.Transfer
{
    public class TransferViewModel : BaseViewModel, IDataErrorInfo
    {
        private double _sum;

        private List<User> _users;
        private User _fromUser;
        private User _toUser;

        private ICollection<Account> _fromAccounts;
        private ICollection<Account> _toAccounts;

        private Account _fromAccount;
        private Account _toAccount;

        private IServiceTransfer _serviceTransfer;

        protected Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

        public TransferViewModel(IRepository repository, IServiceTransfer serviceTransfer)
        {
            _serviceTransfer = serviceTransfer;
            _users = repository.GetUsersList();
        }
        public string Error
        {
            get
            {
                if (ValidationErrors.Count > 0)
                {
                    return string.Empty;
                }

                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (ValidationErrors.ContainsKey(columnName))
                {
                    return ValidationErrors[columnName];
                }

                return null;
            }
        }

        private RelayCommand transferCommand;

        public RelayCommand TransferCommand
        {
            get
            {
                return transferCommand ??
                    (transferCommand = new RelayCommand(obj =>
                    {
                        Validate();

                        _serviceTransfer.Transfer(FromAccount, ToAccount, Sum);
                    }));
            }
        }

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        public User FromUser
        {
            get { return _fromUser; }
            set
            {
                _fromUser = value;
                Validate();
                OnPropertyChanged("");
                FromAccounts = FromUser.Accounts;
            }
        }

        public User ToUser
        {
            get { return _toUser; }
            set
            {
                _toUser = value;
                Validate();
                OnPropertyChanged("");
                ToAccounts = ToUser.Accounts;
            }
        }

        public Account FromAccount
        {
            get { return _fromAccount; }
            set
            {
                _fromAccount = value;
                Validate();
                OnPropertyChanged("");
            }
        }

        public Account ToAccount
        {
            get { return _toAccount; }
            set
            {
                _toAccount = value;
                Validate();
                OnPropertyChanged("");
            }
        }

        public ICollection<Account> FromAccounts
        {
            get { return _fromAccounts; }
            set
            {
                _fromAccounts = value;
                OnPropertyChanged("FromAccounts");
            }
        }

        public ICollection<Account> ToAccounts
        {
            get { return _toAccounts; }
            set
            {
                _toAccounts = value;
                OnPropertyChanged("ToAccounts");
            }
        }

        public double Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                Validate();
                OnPropertyChanged("");
            }

        }

        private void Validate()
        {
            ValidationErrors.Clear();

            DateTime currentDate = DateTime.Now;

            if (FromUser == null)
                ValidationErrors.Add(nameof(FromUser), "From user cannot be empty.");
            if (ToUser == null)
                ValidationErrors.Add(nameof(ToUser), "To user cannot be empty.");
            if (FromAccount == null)
                ValidationErrors.Add(nameof(FromAccount), "From account cannot be empty.");
            if (ToAccount == null)
                ValidationErrors.Add(nameof(ToAccount), "To account cannot be empty.");
            if (Sum == 0 && Sum < 0)
                ValidationErrors.Add(nameof(Sum), "Must not be 0 or less than 0.");

            OnPropertyChanged("");
        }
    }
}
