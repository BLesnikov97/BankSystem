using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using System.Collections.Generic;
using System.ComponentModel;

namespace BankSystem.Client.WPF.UI.AddAndTake
{
    public class AddAndTakeViewModel : BaseViewModel, IDataErrorInfo
    {
        private Account _selectedAccount;
        private ICollection<Account> _accounts;

        private List<User> _users;
        private User _selectedUser;

        private double _sum;

        private IRepository _repository;

        protected Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

        public AddAndTakeViewModel(IRepository repository, IService service)
        {
            _repository = repository;

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

        private RelayCommand addCashCommand;

        public RelayCommand AddCashCommand
        {
            get
            {
                return addCashCommand ??
                    (addCashCommand = new RelayCommand(obj =>
                    {
                        Validate();

                        SelectedAccount.AddAmount(SelectedAccount, Sum);

                        _repository.Save();
                    }));
            }
        }

        private RelayCommand takeCashCommand;

        public RelayCommand TakeCashCommand
        {
            get
            {
                return takeCashCommand ??
                    (takeCashCommand = new RelayCommand(user =>
                    {
                        Validate();

                        SelectedAccount.TakeAmount(SelectedAccount, Sum);

                        _repository.Save();
                    }));
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

        public ICollection<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                OnPropertyChanged("Accounts");
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
                Accounts = SelectedUser.Accounts;
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

            if (SelectedAccount == null)
                ValidationErrors.Add(nameof(SelectedAccount), "Account cannot be empty.");
            if (Sum <= 0)
                ValidationErrors.Add(nameof(Sum), "Sum cannot be empty.");
            if (SelectedUser == null)
                ValidationErrors.Add(nameof(SelectedUser), "User cannot be empty.");

            OnPropertyChanged("");
        }
    }
}
