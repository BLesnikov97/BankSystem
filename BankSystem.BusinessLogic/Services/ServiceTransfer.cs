using BankSystem.BusinesLogic.BaseConnect;
using BankSystem.BusinesLogic.Model;

namespace BankSystem.BusinesLogic.Services
{
    public class ServiceTransfer : IServiceTransfer
    {
        private IRepository _db;

        public ServiceTransfer(IRepository db)
        {
            _db = db;
        }

        public void Transfer(UserAccount user1, UserAccount user2)
        {
            if (user1.Cash >= 100 & user1.FullName != user2.FullName)
            {
                user2.AddCash(user2);
                user1.TakeCash(user1);

                _db.Save();
            }
            else
            {
                throw new Exception("Insufficient funds or transfer to yourself");
            }
        }
    }
}
