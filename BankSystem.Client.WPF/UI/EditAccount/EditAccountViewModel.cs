using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using System.Collections.Generic;
using System.ComponentModel;

namespace BankSystem.Client.WPF.UI.EditAccount
{
    public class EditAccountViewModel : BaseViewModel, IDataErrorInfo
    {
        private List<User> _users;

        private List<Account> _accounts;

        private Account _selectedAccount;

        private User _selectedUser;

        private string _description;

        private double _amount;

        private string _currency;

        private IService _service;

        public EditAccountViewModel(IRepository repository, IService service)
        {
            _service = service;

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
                    case nameof(SelectedUser):
                        if (SelectedUser == null)
                            error = "Selected user cannot be empty.";
                        break;

                    case nameof(SelectedAccount):
                        if (SelectedAccount == null)
                            error = "Selected account cannot be empty.";
                        break;
                    case nameof(Description):
                        if (string.IsNullOrWhiteSpace(Description))
                            error = "Description cannot be empty.";
                        if (Description?.Length > 50)
                            error = "Description than 50 characters.";
                        break;

                    case nameof(Currency):
                        if (string.IsNullOrWhiteSpace(Currency))
                            error = "Currency cannot be empty.";
                        break;
                    case nameof(Amount):
                        if (Amount == 0 & Amount < 0)
                            error = "Amount cannot be empty.";
                        break;
                }

                return error;
            }
        }


        private RelayCommand editAccount;

        public RelayCommand EditAccount
        {
            get
            {
                return editAccount ??
                    (editAccount = new RelayCommand(obj =>
                    {
                        _service.EditAccount(SelectedAccount, Description, Amount, Currency);   
                    }));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                OnPropertyChanged("Currency");
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
            }
        }

        public List<Account> Accounts
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
