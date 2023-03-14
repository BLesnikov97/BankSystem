using System;
using System.Collections.Generic;
using System.ComponentModel;
using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;

namespace BankSystem.Client.WPF.UI.Dep
{
    public class DepViewModel : BaseViewModel, IDataErrorInfo
    {
        private User _selectedUser;

        private List<User> _users;

        private ICollection<Account> _accounts;

        private Account _selectedAccount;

        private IServiceDep _dep;

        private RelayCommand depCommand;

        public DepViewModel(IRepository db, IServiceDep dep)
        {
            _dep = dep;
            _users = db.GetUsersList();
        }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(SelectedUser):
                        if (SelectedUser == null)
                            error = "Selected user cannot be empty.";
                        break;

                    case nameof(SelectedAccount):
                        if (SelectedAccount == null)
                            error = "Selected account cannot be empty.";
                        break;
                }

                return error;
            }
        }

        public RelayCommand DepCommand
        {
            get
            {
                return depCommand ??
                    (depCommand = new RelayCommand(user =>
                    {
                        _dep.Dep(SelectedUser, SelectedAccount);
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

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
                Accounts = _selectedUser.Accounts;
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
    }
}
