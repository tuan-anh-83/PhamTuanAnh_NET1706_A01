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

namespace PhamTuanAnhWPF
{
    /// <summary>
    /// Interaction logic for StaffMenu.xaml
    /// </summary>
    public partial class StaffMenu : Window
    {
        private string staffEmail;
        public StaffMenu(string email)
        {
            InitializeComponent();
            staffEmail = email;
        }

        private void btnManageAccount_Click(object sender, RoutedEventArgs e)
        {
            ManageStaffInformation manageAccount = new ManageStaffInformation(staffEmail);
            manageAccount.Show();
            this.Hide();
        }
    }
}
