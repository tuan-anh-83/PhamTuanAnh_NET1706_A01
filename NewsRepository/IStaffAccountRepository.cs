using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsRepository
{
    public interface IStaffAccountRepository
    {
        SystemAccount GetAccount(string email);
        void UpdateAccount(SystemAccount account);
        SystemAccount GetAccountById(short account);
    }
}
