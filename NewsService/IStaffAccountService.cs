using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsService
{
    public interface IStaffAccountService
    {
        void AddAccount(SystemAccount account);
        SystemAccount GetAccount(string email);
        void DeleteAccount(string email);
        void UpdateAccount(SystemAccount account);
    }
}
