﻿using System;
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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void btnManageAccount_Click(object sender, RoutedEventArgs e)
        {
            ManageAccount manageAccount = new ManageAccount();
            manageAccount.Show();
            this.Hide();
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
