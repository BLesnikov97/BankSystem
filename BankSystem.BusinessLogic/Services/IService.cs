﻿using BankSystem.BusinessLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public interface IService
    {
        void AddUser(string lastName, string firstName, string middleName, DateTime birthday, Gender gender);

        void AddAccount(User user, string description, double amount, string currency);

        void EditUser(User user, string lastName, string firstName, string middleName, DateTime birthday);

        void EditAccount(Account account, string description, double amount, string currency);
    }
}
