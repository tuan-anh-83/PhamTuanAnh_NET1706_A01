using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;
using NewsRepository;

namespace NewsService
{
    public class CreateReportService : ICreateReportService
    {
        private ICreateReportRepository createReportRepository = null;

        public CreateReportService()
        {
            createReportRepository = new CreateReportRepository();
        }
        public void AddNews(NewsArticle news)
        {
            createReportRepository.AddNews(news);
        }

        public void DeleteNews(string news)
        {
            createReportRepository.DeleteNews(news);
        }

        public List<NewsArticle> GetNews()
        {
            return createReportRepository.GetNews();
        }

        public NewsArticle GetNewsByID(string news)
        {
            return createReportRepository.GetNewsByID(news);
        }

        public void UpdateNews(NewsArticle news)
        {
            createReportRepository.UpdateNews(news);
        }
    }
}
