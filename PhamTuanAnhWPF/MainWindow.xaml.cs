using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewsObject.Models;
using NewsService;

namespace PhamTuanAnhWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IManageAccountService accountService;
        public MainWindow()
        {
            InitializeComponent();
            accountService = new ManageAccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string password = txtPassword.Password;
            try
            {
                SystemAccount account = accountService.GetAccount(txtEmail.Text.Trim());
                if (account != null && password.Trim().Equals(account.AccountPassword))
                {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Show();
                    this.Hide();

                    
                }
                else
                {
                    MessageBox.Show("Please check your email or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
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
    }
}