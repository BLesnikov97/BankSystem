using BankSystem.BusinesLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public interface IServiceRepository
    {
        void CheckCash(UserAccount user);

        void AddUser(string fullName, string cash);
    }
}
