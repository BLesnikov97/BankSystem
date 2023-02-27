using System.Collections.Generic;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Services;
using BankSystem.BusinessLogic.Model;
using BankSystem.Client.WPF.Util;

namespace BankSystem.Client.WPF.UI.Dep
{
    public class DepViewModel : BaseViewModel
    {
        private Account _selectedAccount;

        private List<Account> _Accounts;

        private IServiceDep _dep;

        private RelayCommand depCommand;

        public DepViewModel(IRepository db, IServiceRepository serviceRepository, IServiceDep dep)
        {
            _dep = dep;
            _Accounts = db.GetAccountsList();
        }

        public RelayCommand DepCommand
        {
            get
            {
                return depCommand ??
                    (depCommand = new RelayCommand(user =>
                    {
                        _dep.Dep(SelectedAccount);
                    }));
            }
        }

        public List<Account> Accounts
        {
            get { return _Accounts; }
            set
            {
                _Accounts = value;
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
