using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsService
{
    public interface ICreateReportService
    {
        List<NewsArticle> GetNews();
        void AddNews(NewsArticle news);

        NewsArticle GetNewsByID(string news);

        void DeleteNews(string news);

        void UpdateNews(NewsArticle news);
    }
}
