using System;
using System.Collections.Generic;
using BankSystem.Client.WPF.Util;
using BankSystem.BusinesLogic.Model;
using BankSystem.BusinesLogic.BaseConnect;

namespace BankSystem.Client.WPF.UI.StatusAccaunt
{
    public class StatusAccountViewModel : BaseViewModel
    {
        private string _сheckСash = "Остаток по счету: ";

        private UserAccount _selectedUserAccaunt;

        private List<UserAccount> _userAccaunts;

        private RelayCommand statusCommand;

        public StatusAccountViewModel(IRepository db)
        {
            _userAccaunts = db.GetUsersAccountList();
        }

        public RelayCommand StatusCommand
        {
            get
            {
                return statusCommand ??
                    (statusCommand = new RelayCommand(user =>
                    {
                            СheckСash = Convert.ToString(SelectedUserAccaunt.Cash);
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

        public UserAccount SelectedUserAccaunt
        {
            get { return _selectedUserAccaunt; }
            set
            {
                _selectedUserAccaunt = value;
                OnPropertyChanged("SelectedUserAccaunt");
            }
        }

        public string СheckСash
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
