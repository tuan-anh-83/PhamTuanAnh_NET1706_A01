using System;
using System.Collections.Generic;

namespace NewsObject.Models
{
    public partial class Category
    {
        public Category()
        {
            NewsArticles = new HashSet<NewsArticle>();
        }

        public short CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string CategoryDesciption { get; set; } = null!;

        public virtual ICollection<NewsArticle> NewsArticles { get; set; }
    }
}
