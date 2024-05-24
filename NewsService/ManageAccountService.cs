using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;
using NewsRepository;

namespace NewsService
{
    public class ManageAccountService : IManageAccountService
    {
        private IManageAccountRepository accountRepository = null;

        public ManageAccountService()
        {
            accountRepository = new ManageAccountRepository();
        }
        public void AddAccount(SystemAccount account)
        {
            accountRepository.AddAccount(account);
        }

        public void DeleteAccount(string account)
        {
            accountRepository.DeleteAccount(account);
        }

        public SystemAccount GetAccount(string account)
        {
            return accountRepository.GetAccount(account);
        }

        public List<SystemAccount> GetAccounts()
        {
            return accountRepository.GetAccounts();
        }

        public List<SystemAccount> SearchAccount(string account)
        {
            return accountRepository.SearchAccount(account);
        }

        public SystemAccount GetAccountById(short account)
        {
            return accountRepository.GetAccountById(account);
        }

        public void UpdateAccount(SystemAccount account)
        {
            accountRepository.UpdateAccount(account);
        }
       
    }
}
