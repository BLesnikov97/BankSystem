using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.BusinesLogic.Repositories;
using System.ComponentModel;
using System;

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

        public TransferViewModel(IRepository repository, IServiceTransfer serviceTransfer)
        {
            _serviceTransfer = serviceTransfer;
            _users = repository.GetUsersList();
        }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(FromUser):
                        if (FromUser == null)
                            error = "From user cannot be empty.";
                        break;

                    case nameof(ToUser):
                        if (ToUser == null)
                            error = "To user cannot be empty.";
                        break;
                    case nameof(FromAccount):
                        if (FromAccount == null)
                            error = "From account cannot be empty.";
                        break;

                    case nameof(ToAccount):
                        if (ToAccount == null)
                            error = "To account cannot be empty.";
                        break;
                    case nameof(Sum):
                        if (Sum == 0 & Sum < 0)
                            error = "Must not be 0 or less than 0.";
                        break;
                }

                return error;
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
                OnPropertyChanged("FromUser");
                FromAccounts = FromUser.Accounts;
            }
        }

        public User ToUser
        {
            get { return _toUser; }
            set
            {
                _toUser = value;
                OnPropertyChanged("ToUser");
                ToAccounts = ToUser.Accounts;
            }
        }

        public Account FromAccount
        {
            get { return _fromAccount; }
            set
            {
                _fromAccount = value;
                OnPropertyChanged("FromAccount");
            }
        }

        public Account ToAccount
        {
            get { return _toAccount; }
            set
            {
                _toAccount = value;
                OnPropertyChanged("ToAccount");
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
                OnPropertyChanged("Sum");
            }

        }
    }
}
