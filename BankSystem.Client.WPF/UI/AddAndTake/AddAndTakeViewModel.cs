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

        public AddAndTakeViewModel(IRepository repository, IService service)
        {
            _repository = repository;

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
                    case nameof(Sum):
                        if (Sum == 0)
                            error = "Sum cannot be empty.";
                        break;
                    case nameof(SelectedUser):
                        if (SelectedUser == null)
                            error = "User cannot be empty.";
                        break;
                    case nameof(SelectedAccount):
                        if (SelectedAccount == null)
                            error = "Account cannot be empty.";
                        break;
                }                

                return error;
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
                OnPropertyChanged("SelectedAccount");
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
                OnPropertyChanged("SelectedUser");
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
                OnPropertyChanged("Sum");
            }

        }
    }
}
