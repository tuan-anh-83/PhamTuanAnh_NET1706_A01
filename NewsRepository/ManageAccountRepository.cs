using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsDAO;
using NewsObject.Models;

namespace NewsRepository
{
    public class ManageAccountRepository : IManageAccountRepository
    {
        public void AddAccount(SystemAccount account) => ManageAccountDAO.Instance.AddAccount(account);
        public void DeleteAccount(string account) => ManageAccountDAO.Instance.DeleteAccount(account);

        public SystemAccount GetAccount(string account) => ManageAccountDAO.Instance.GetAccount(account);

        public List<SystemAccount> GetAccounts() => ManageAccountDAO.Instance.GetAccounts();

        public List<SystemAccount> SearchAccount(string account) => ManageAccountDAO.Instance.SearchAccount(account);

        public SystemAccount GetAccountById(short account) => ManageAccountDAO.Instance.GetAccountById(account);

        public void UpdateAccount(SystemAccount account) => ManageAccountDAO.Instance.UpdateAccount(account);

    }
}
