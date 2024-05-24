using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NewsObject.Models;
using NewsService;

namespace PhamTuanAnhWPF
{
    /// <summary>
    /// Interaction logic for ManageStaffInformation.xaml
    /// </summary>
    public partial class ManageStaffInformation : Window
    {
        private IStaffAccountService accountService = null;
        private string staffEmail;

        public ManageStaffInformation(string email)
        {
            InitializeComponent();
            accountService = new StaffAccountService();
            staffEmail = email;
            LoadStaffAccount();
        }


        private void LoadStaffAccount()
        {
            var account = accountService.GetAccount(staffEmail);
            if (account != null)
            {
                txtAccountID.Text = account.AccountId.ToString();
                txtAccountID.IsEnabled = false;
                txtAccountName.Text = account.AccountName;
                txtAccountEmail.Text = account.AccountEmail;
                txtPassword.Text = account.AccountPassword;
                txtAccountRole.Text = account.AccountRole.ToString();
                txtAccountRole.IsEnabled = false;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemAccount account = accountService.GetAccount(staffEmail);

                if (account != null)
                {
                    account.AccountId = short.Parse(txtAccountID.Text.Trim());
                    account.AccountName = txtAccountName.Text.Trim();
                    account.AccountEmail = txtAccountEmail.Text.Trim();
                    account.AccountRole = int.Parse(txtAccountRole.Text.Trim());
                    account.AccountPassword = txtPassword.Text.Trim();

                    accountService.UpdateAccount(account);
                    MessageBox.Show("Update Account Successful!!");
                }
                else
                {
                    MessageBox.Show("Email isn't existed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong !! Please check again" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete your account?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    accountService.DeleteAccount(staffEmail);
                    MessageBox.Show("Delete Account Successful!!");
                    this.Close(); // Close the window after account is deleted
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong !! Please check again" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Hide();
        }
    }
}
