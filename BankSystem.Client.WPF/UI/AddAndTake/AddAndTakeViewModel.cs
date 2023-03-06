using BankSystem.BusinesLogic.BaseConnect;
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

        private IRepository _db;

        private IServiceRepository _service;

        public AddAndTakeViewModel(IRepository db, IServiceRepository service)
        {
            _db = db;
            _service = service;

            _users = db.GetUsersList();
        }

        private RelayCommand addCashCommand;

        public RelayCommand AddCashCommand
        {
            get
            {
                return addCashCommand ??
                    (addCashCommand = new RelayCommand(obj =>
                    {
                        SelectedAccount.AddAmount_100(SelectedAccount);

                        _db.Save();
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
                        _service.CheckCash(SelectedAccount);

                        SelectedAccount.TakeAmount_100(SelectedAccount);

                        _db.Save();
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
    }
}
