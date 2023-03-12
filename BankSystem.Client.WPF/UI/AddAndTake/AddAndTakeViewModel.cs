using BankSystem.BusinesLogic.Repositories;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;
using System.Collections.Generic;

namespace BankSystem.Client.WPF.UI.AddAndTake
{
    public class AddAndTakeViewModel : BaseViewModel
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
