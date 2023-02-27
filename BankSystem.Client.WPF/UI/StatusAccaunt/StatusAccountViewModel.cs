using System;
using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinessLogic.Model;

namespace BankSystem.Client.WPF.UI.StatusAccaunt
{
    public class StatusAccountViewModel : BaseViewModel
    {
        private string _сheckСash = "Остаток по счету: ";

        private Account _selectedAccount;

        private List<Account> _Accounts;

        private RelayCommand statusCommand;

        public StatusAccountViewModel(IRepository db)
        {
            _Accounts = db.GetAccountsList();
        }

        public RelayCommand StatusCommand
        {
            get
            {
                return statusCommand ??
                    (statusCommand = new RelayCommand(user =>
                    {
                            СheckAmount = Convert.ToString(SelectedAccount.Amount);
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

        public string СheckAmount
        {
            get { return _сheckСash; }
            set
            {
                _сheckСash = value;
                OnPropertyChanged("СheckСash");
            }
        }
    }
}
