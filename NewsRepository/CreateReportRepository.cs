using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsDAO;
using NewsObject.Models;

namespace NewsRepository
{
    public class CreateReportRepository : ICreateReportRepository
    {
        public void AddNews(NewsArticle news) => CreateReportDAO.Instance.AddNews(news);
        public void DeleteNews(string news) => CreateReportDAO.Instance.DeleteNews(news);

        public NewsArticle GetNewsByID(string news) => CreateReportDAO.Instance.GetNewsByID(news);

        public List<NewsArticle> GetNews() => CreateReportDAO.Instance.GetNews();

        public void UpdateNews(NewsArticle news) => CreateReportDAO.Instance.UpdateNews(news);
    }
}
