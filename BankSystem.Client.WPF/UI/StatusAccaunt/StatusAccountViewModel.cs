using System;
using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.Client.WPF.UI.StatusAccaunt
{
    public class StatusAccountViewModel : BaseViewModel
    {
        private string _сheckСash;

        private Account _selectedAccount;
        private ICollection<Account> _accounts;

        private List<User> _users;
        private User _selectedUser;

        private RelayCommand statusCommand;

        public StatusAccountViewModel(IRepository db)
        {
            //_accounts = db.GetAccountsList();
            _users = db.GetUsersList();
            Accounts = SelectedUser.Accounts;
        }

        public RelayCommand StatusCommand
        {
            get
            {
                return statusCommand ??
                    (statusCommand = new RelayCommand(user =>
                    {
                            СheckAmount = Convert.ToString(SelectedAccount.Amount);
                    }));
            }
        }
        public ICollection<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                OnPropertyChanged("Accounts");
            }
        }

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged("SelectedAccount");
            }
        }

        public string СheckAmount
        {
            get { return _сheckСash; }
            set
            {
                _сheckСash = value;
                OnPropertyChanged("СheckСash");
            }
        }

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Accounts");
            }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedAccount");
            }
        }
    }
}
