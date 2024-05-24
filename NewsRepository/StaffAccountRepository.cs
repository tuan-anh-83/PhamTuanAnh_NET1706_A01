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
        public void AddAccount(SystemAccount account) => ManageAccountDAO.Instance.AddAccount(account);
        public void DeleteAccount(string email) => ManageAccountDAO.Instance.DeleteAccount(email);
        public SystemAccount GetAccount(string email) => ManageAccountDAO.Instance.GetAccount(email);
        public void UpdateAccount(SystemAccount account) => ManageAccountDAO.Instance.UpdateAccount(account);
    }
}
