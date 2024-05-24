using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsDAO;
using NewsObject.Models;

namespace NewsRepository
{
    public class StaffAccountRepository : IStaffAccountRepository
    {
        public SystemAccount GetAccount(string email) => ManageAccountDAO.Instance.GetAccount(email);
        public void UpdateAccount(SystemAccount account) => ManageAccountDAO.Instance.UpdateAccount(account);
        public SystemAccount GetAccountById(short account) => ManageAccountDAO.Instance.GetAccountById(account);
    }
}
