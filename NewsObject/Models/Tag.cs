using System;
using System.Collections.Generic;

namespace NewsObject.Models
{
    public partial class Tag
    {
        public Tag()
        {
            NewsArticles = new HashSet<NewsArticle>();
        }

        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<NewsArticle> NewsArticles { get; set; }
    }
}
