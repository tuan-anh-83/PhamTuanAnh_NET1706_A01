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
    /// Interaction logic for CreateReport.xaml
    /// </summary>
    public partial class CreateReport : Window
    {
        private ICreateReportService createReportService = null;
        public CreateReport()
        {
            InitializeComponent();
            createReportService = new CreateReportService();
            var newsList = createReportService.GetNews();

            // Sắp xếp danh sách theo CreatedDate giảm dần
            var sortedNewsList = newsList.OrderByDescending(news => news.CreatedDate).ToList();

            dgNewsList.ItemsSource = sortedNewsList;
            dgNewsList.AddHandler(DataGridCell.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGrid_CellMouseLeftButtonDown), true);
        }

        private void DataGrid_CellMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null) return;

            // Lấy ra hàng được click
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null) return;

            // Lấy dữ liệu từ hàng được click và hiển thị lên các điều khiển TextBox và DatePicker
            var selectedBook = (NewsArticle)row.Item;
            txtNewsArticleID.Text = selectedBook.NewsArticleId;
            txtNewsTitle.Text = selectedBook.NewsTitle;
            txtNewsContent.Text = selectedBook.NewsContent;
            txtCategoryID.Text = selectedBook.CategoryId.ToString();
            txtCreatedByID.Text = selectedBook.CreatedById.ToString();
            txtNewsStatus.Text = selectedBook.NewsStatus.ToString();
            dtCreatedDate.SelectedDate = selectedBook.CreatedDate;
            dtModifiedDate.SelectedDate = selectedBook.ModifiedDate;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValidData = true;
            if (!AccountUltils.isNotEmpty(txtNewsArticleID.Text.Trim()))
            {
                isValidData = false;
                txtNewsArticleID.Focus();
                txtNewsArticleID.Background = Brushes.Red; ;
                MessageBox.Show("AccountID can not Empty !");
            }

            try
            {
                if (isValidData)
                {
                    NewsArticle news = new NewsArticle();
                    news.NewsArticleId = txtNewsArticleID.Text.Trim();
                    news.NewsTitle = txtNewsTitle.Text.Trim();
                    news.NewsContent = txtNewsContent.Text.Trim();
                    news.CategoryId = short.Parse(txtCategoryID.Text.Trim());
                    news.CreatedById = short.Parse(txtCreatedByID.Text.Trim());
                    news.NewsStatus = bool.Parse(txtNewsStatus.Text.Trim()); 
                    news.CreatedDate = DateTime.Parse(dtCreatedDate.Text.Trim());
                    news.ModifiedDate = DateTime.Parse(dtModifiedDate.Text.Trim());
                    createReportService.AddNews(news);
                    MessageBox.Show("Add Account Successfull !!");
                    var sortedNewsList = createReportService.GetNews().OrderByDescending(n => n.CreatedDate).ToList();
                    dgNewsList.ItemsSource = sortedNewsList;
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
                if (createReportService != null)
                {
                    NewsArticle news = createReportService.GetNewsByID(txtNewsArticleID.Text.Trim());

                    if (news != null)
                    {
                        news.NewsArticleId = txtNewsArticleID.Text.Trim();
                        news.NewsTitle = txtNewsTitle.Text.Trim();
                        news.NewsContent = txtNewsContent.Text.Trim();
                        news.CategoryId = short.Parse(txtCategoryID.Text.Trim());
                        news.CreatedById = short.Parse(txtCreatedByID.Text.Trim());
                        news.NewsStatus = bool.Parse(txtNewsStatus.Text.Trim());
                        news.CreatedDate = DateTime.Parse(dtCreatedDate.Text.Trim());
                        news.ModifiedDate = DateTime.Parse(dtModifiedDate.Text.Trim());
                        
                        createReportService.UpdateNews(news);
                        MessageBox.Show("Update Account Successful!!");
                        var sortedNewsList = createReportService.GetNews().OrderByDescending(n => n.CreatedDate).ToList();
                        dgNewsList.ItemsSource = sortedNewsList;
                    }
                    else
                    {
                        MessageBox.Show("Email isn't existed!");
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
                if (txtNewsArticleID.Text.Length > 0)
                {
                    createReportService.DeleteNews(txtNewsArticleID.Text.Trim());
                    MessageBox.Show("Delete Member Successfull !!");
                    var sortedNewsList = createReportService.GetNews().OrderByDescending(n => n.CreatedDate).ToList();
                    dgNewsList.ItemsSource = sortedNewsList;
                }
                else
                {
                    MessageBox.Show("MemberID isn't empty");
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
