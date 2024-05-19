using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsDAO
{
    public class ManageAccountDAO
    {
        private static ManageAccountDAO instance = null;

        public ManageAccountDAO()
        {
        }



        public static ManageAccountDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new ManageAccountDAO();
                }
                return instance;
            }

        }

        public List<SystemAccount> GetAccounts()
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                return dbContent.SystemAccounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public void AddAccount(SystemAccount account)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                SystemAccount accountProfile = GetAccount(account.AccountEmail.ToString());
                if (accountProfile == null)
                {
                    dbContent.SystemAccounts.Add(account);
                    dbContent.SaveChanges();
                }
                else
                {
                    throw new Exception("AccountID has existed !");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteAccount(string account)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                SystemAccount accountProfile = GetAccount(account);
                if (account != null)
                {
                    dbContent.SystemAccounts.Remove(accountProfile);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateAccount(SystemAccount account)
        {
            var dbContent = new FUNewsManagementDBContext();

            if (account != null)
            {
                dbContent.SystemAccounts.Update(account);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("Email hasn't existed !");
            }
        }

        public List<SystemAccount> SearchAccount(string account)
        {
            try
            {
                using (var dbContext = new FUNewsManagementDBContext())
                {
                    return dbContext.SystemAccounts.Where(p => p.AccountName.Contains(account)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
