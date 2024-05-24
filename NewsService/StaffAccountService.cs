using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;
using NewsRepository;

namespace NewsService
{
    public class StaffAccountService : IStaffAccountService
    {
        private IStaffAccountRepository accountRepository = null;

        public StaffAccountService()
        {
            accountRepository = new StaffAccountRepository();
        }

        public void AddAccount(SystemAccount account)
        {
            accountRepository.AddAccount(account);
        }

        public void DeleteAccount(string email)
        {
            accountRepository.DeleteAccount(email);
        }

        public SystemAccount GetAccount(string email)
        {
            return accountRepository.GetAccount(email);
        }

        public void UpdateAccount(SystemAccount account)
        {
            accountRepository.UpdateAccount(account);
        }
    }
}
