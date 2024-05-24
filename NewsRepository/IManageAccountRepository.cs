using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsRepository
{
    public interface IManageAccountRepository
    {
        List<SystemAccount> GetAccounts();
        void AddAccount(SystemAccount account);

        SystemAccount GetAccount(string account);

        void DeleteAccount(string account);

        void UpdateAccount(SystemAccount account);

        SystemAccount GetAccountById(short account);

        List<SystemAccount> SearchAccount(string account);
    }
}
