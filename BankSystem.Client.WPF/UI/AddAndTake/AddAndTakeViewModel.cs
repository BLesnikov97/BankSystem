using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Model;
using BankSystem.BusinesLogic.Services;
using BankSystem.Client.WPF.Util;
using System.Collections.Generic;

namespace BankSystem.Client.WPF.UI.AddAndTake
{
    public class AddAndTakeViewModel : BaseViewModel
    {
        private UserAccount _selectedAccaunt;

        private List<UserAccount> _usersAccount;

        private IRepository _db;

        private IServiceRepository _service;

        public AddAndTakeViewModel(IRepository db, IServiceRepository service)
        {
            _db = db;
            _service = service;

            _usersAccount = db.GetUsersAccountList();
        }

        private RelayCommand addCashCommand;

        public RelayCommand AddCashCommand
        {
            get
            {
                return addCashCommand ??
                    (addCashCommand = new RelayCommand(obj =>
                    {
                        SelectedAccaunt.AddCash(SelectedAccaunt);

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
                        _service.CheckCash(SelectedAccaunt);

                        SelectedAccaunt.TakeCash(SelectedAccaunt);

                        _db.Save();
                    }));
            }
        }

        public UserAccount SelectedAccaunt
        {
            get { return _selectedAccaunt; }
            set
            {
                _selectedAccaunt = value;
                OnPropertyChanged("SelectedAccaunt");
            }
        }

        public List<UserAccount> UsersAccount
        {
            get { return _usersAccount; }
            set
            {
                _usersAccount = value;
                OnPropertyChanged("UsersAccount");
            }

        }
    }
}
