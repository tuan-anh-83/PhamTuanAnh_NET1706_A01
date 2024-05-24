using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsDAO
{
    public class StaffAccountDAO
    {
        private static StaffAccountDAO instance = null;

        public StaffAccountDAO()
        {
        }

        public static StaffAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StaffAccountDAO();
                }
                return instance;
            }
        }

        
        public SystemAccount GetAccount(string email)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                return dbContent.SystemAccounts.SingleOrDefault(m => m.AccountEmail.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public SystemAccount GetAccountById(short accountId)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                return dbContent.SystemAccounts.SingleOrDefault(m => m.AccountId == accountId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAccount(SystemAccount account)
        {
            try
            {
                using (var dbContent = new FUNewsManagementDBContext())
                {
                    var existingAccount = dbContent.SystemAccounts.SingleOrDefault(a => a.AccountId == account.AccountId);

                    if (existingAccount != null)
                    {
                        existingAccount.AccountName = account.AccountName;
                        existingAccount.AccountEmail = account.AccountEmail;
                        existingAccount.AccountRole = account.AccountRole;
                        existingAccount.AccountPassword = account.AccountPassword;

                        dbContent.SystemAccounts.Update(existingAccount);
                        dbContent.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Account ID hasn't existed!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

