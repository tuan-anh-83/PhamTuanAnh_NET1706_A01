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

        // Chỉ lấy tài khoản của chính nhân viên dựa trên email
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

        public void DeleteAccount(string email)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                SystemAccount accountProfile = GetAccount(email);
                if (accountProfile != null)
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
    }
}

