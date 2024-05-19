using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsService
{
    public interface IManageAccountService
    {
        List<SystemAccount> GetAccounts();
        void AddAccount(SystemAccount account);

        SystemAccount GetAccount(string account);

        void DeleteAccount(string account);

        void UpdateAccount(SystemAccount account);

        List<SystemAccount> SearchAccount(string account);
    }
}
