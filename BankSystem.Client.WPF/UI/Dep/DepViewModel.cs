using System.Collections.Generic;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Model;
using BankSystem.BusinesLogic.Services;
using BankSystem.Client.WPF.Util;

namespace BankSystem.Client.WPF.UI.Dep
{
    public class DepViewModel : BaseViewModel
    {
        private UserAccount _selectedUser;

        private List<UserAccount> _userAccaunts;

        private IServiceDep _dep;

        private RelayCommand depCommand;

        public DepViewModel(IRepository db, IServiceRepository serviceRepository, IServiceDep dep)
        {
            _dep = dep;
            _userAccaunts = db.GetUsersAccountList();
        }

        public RelayCommand DepCommand
        {
            get
            {
                return depCommand ??
                    (depCommand = new RelayCommand(user =>
                    {
                        _dep.Dep(SelectedUser);
                    }));
            }
        }

        public List<UserAccount> UserAccaunts
        {
            get { return _userAccaunts; }
            set
            {
                _userAccaunts = value;
                OnPropertyChanged("UserAccaunts");
            }
        }

        public UserAccount SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
    }
}
