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
using NewsObject;
using NewsObject.Models;
using NewsService;

namespace PhamTuanAnhWPF
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : Window
    {
        private IManageAccountService accountService = null;

        public ManageAccount()
        {
            InitializeComponent();
            accountService = new ManageAccountService();
            dgAccountList.ItemsSource = accountService.GetAccounts();
            dgAccountList.AddHandler(DataGridCell.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGrid_CellMouseLeftButtonDown), true);
        }

        private void DataGrid_CellMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null) return;

            // Lấy ra hàng được click
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null) return;

            // Lấy dữ liệu từ hàng được click và hiển thị lên các điều khiển TextBox và DatePicker
            var selectedBook = (SystemAccount)row.Item;
            txtAccountID.Text = selectedBook.AccountId.ToString();
            txtAccountID.IsEnabled = false;
            txtAccountName.Text = selectedBook.AccountName;
            txtAccountEmail.Text = selectedBook.AccountEmail;
            txtPassword.Text = selectedBook.AccountPassword;
            txtAccountRole.Text = selectedBook.AccountRole.ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValidData = true;
            if (!AccountUltils.isNotEmpty(txtAccountID.Text.Trim()))
            {
                isValidData = false;
                txtAccountID.Focus();
                MessageBox.Show("AccountID can not Empty !");
            }

            try
            {
                if (isValidData)
                {
                    SystemAccount account = new SystemAccount();
                    account.AccountId = short.Parse(txtAccountID.Text.Trim());
                    account.AccountName = txtAccountName.Text.Trim();
                    account.AccountEmail = txtAccountEmail.Text.Trim();
                    account.AccountRole = int.Parse(txtAccountRole.Text.Trim());
                    account.AccountPassword = txtPassword.Text.Trim();
                    accountService.AddAccount(account);
                    MessageBox.Show("Add Account Successfull !!");
                    dgAccountList.ItemsSource = accountService.GetAccounts();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong !! Please check again " + ex.Message);
            }


        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (accountService != null)
                {
                    short accountId = short.Parse(txtAccountID.Text.Trim());
                    SystemAccount account = accountService.GetAccountById(accountId);

                    if (account != null)
                    {
                        account.AccountName = txtAccountName.Text.Trim();
                        account.AccountEmail = txtAccountEmail.Text.Trim();
                        account.AccountRole = int.Parse(txtAccountRole.Text.Trim());
                        account.AccountPassword = txtPassword.Text.Trim();

                        accountService.UpdateAccount(account);
                        MessageBox.Show("Update Account Successful!!");
                        dgAccountList.ItemsSource = accountService.GetAccounts();
                    }
                    else
                    {
                        MessageBox.Show("Account ID isn't existed!");
                    }
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
                if (txtAccountEmail.Text.Length > 0)
                {
                    accountService.DeleteAccount(txtAccountEmail.Text.Trim());
                    MessageBox.Show("Delete Member Successfull !!");
                    dgAccountList.ItemsSource = accountService.GetAccounts();
                }
                else
                {
                    MessageBox.Show("AccountsID isn't empty");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong !! Please check again" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);

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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text.Trim();
            List<SystemAccount> account = accountService.SearchAccount(search);

            dgAccountList.ItemsSource = account;
        }
    }
}
