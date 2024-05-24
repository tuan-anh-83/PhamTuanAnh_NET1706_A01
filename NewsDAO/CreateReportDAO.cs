using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsObject.Models;

namespace NewsDAO
{
    public class CreateReportDAO
    {
        private static CreateReportDAO instance = null;

        public CreateReportDAO()
        {
        }



        public static CreateReportDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CreateReportDAO();
                }
                return instance;
            }

        }

        public List<NewsArticle> GetNews()
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                return dbContent.NewsArticles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NewsArticle GetNewsByID(string news)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                return dbContent.NewsArticles.SingleOrDefault(m => m.NewsArticleId.Equals(news));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNews(NewsArticle news)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                NewsArticle newsInfo = GetNewsByID(news.NewsArticleId);
                if (newsInfo == null)
                {
                    dbContent.NewsArticles.Add(news);
                    dbContent.SaveChanges();
                }
                else
                {
                    throw new Exception("NewsArticleId has existed !");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteNews(string news)
        {
            try
            {
                var dbContent = new FUNewsManagementDBContext();
                NewsArticle newsInfo = GetNewsByID(news);
                if (newsInfo != null)
                {
                    dbContent.NewsArticles.Remove(newsInfo);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateNews(NewsArticle news)
        {
            var dbContent = new FUNewsManagementDBContext();

            if (news != null)
            {
                dbContent.NewsArticles.Update(news);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("NewsArticleId hasn't existed !");
            }
        }

    }
}
