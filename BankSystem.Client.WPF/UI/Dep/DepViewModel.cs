using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using ControlzEx.Standard;

namespace BankSystem.Client.WPF.UI.Dep
{
    public class DepViewModel : BaseViewModel, IDataErrorInfo
    {
        private User _selectedUser;

        private List<User> _users;

        private ICollection<Account> _accounts;

        private Account _selectedAccount;

        private IServiceDep _dep;

        protected Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

        private RelayCommand depCommand;

        public DepViewModel(IRepository db, IServiceDep dep)
        {
            _dep = dep;
            _users = db.GetUsersList();
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

        public RelayCommand DepCommand
        {
            get
            {
                return depCommand ??
                    (depCommand = new RelayCommand(user =>
                    {
                        Validate();
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
                Validate();
                OnPropertyChanged("");
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
                Validate();
                OnPropertyChanged("");
            }
        }

        private void Validate()
        {
            ValidationErrors.Clear();

            if (SelectedAccount == null)
                ValidationErrors.Add(nameof(SelectedAccount), "Account cannot be empty.");
            if (SelectedUser == null)
                ValidationErrors.Add(nameof(SelectedUser), "User cannot be empty.");

            OnPropertyChanged("");
        }
    }
}
