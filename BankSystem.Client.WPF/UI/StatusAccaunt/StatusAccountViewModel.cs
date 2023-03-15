using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinessLogic.Model;
using BankSystem.BusinesLogic.Repositories;
using System.ComponentModel;
using ControlzEx.Standard;

namespace BankSystem.Client.WPF.UI.StatusAccaunt
{
    public class StatusAccountViewModel : BaseViewModel, IDataErrorInfo
    {
        private double _сheckСash;

        private Account _selectedAccount;
        private ICollection<Account> _accounts;

        private List<User> _users;
        private User _selectedUser;

        protected Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

        private RelayCommand statusCommand;

        public StatusAccountViewModel(IRepository repository)
        {
            _users = repository.GetUsersList();
        }

        public RelayCommand StatusCommand
        {
            get
            {
                return statusCommand ??
                    (statusCommand = new RelayCommand(user =>
                    {
                        Validate();

                        СheckAmount = SelectedAccount.Amount;
                    }));
            }

            set
            {              
            }
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

        public double СheckAmount
        {
            get { return _сheckСash; }
            set
            {
                _сheckСash = value;
                OnPropertyChanged("СheckAmount");
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
            get 
            {   
                return _selectedUser; 
            }
            set
            {
                _selectedUser = value;
                Validate();
                OnPropertyChanged("");

                Accounts = SelectedUser.Accounts;
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
