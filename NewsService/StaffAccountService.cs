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

        public SystemAccount GetAccount(string email)
        {
            return accountRepository.GetAccount(email);
        }

        public void UpdateAccount(SystemAccount account)
        {
            accountRepository.UpdateAccount(account);
        }

        public SystemAccount GetAccountById(short account)
        {
            return accountRepository.GetAccountById(account);
        }
    }
}
