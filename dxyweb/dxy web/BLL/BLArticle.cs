using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class BLArticle
    {
        public static string artPath = AppDomain.CurrentDomain.BaseDirectory + @"articles\";

        public bool Insert(string artName,string artPath,DateTime addDate)
        {
            Article article = new Article();
            article.AddDate = addDate;
            article.ArticleName = artName;
            article.ArticlePath = artPath;
            DaoArticle dao = new DaoArticle();
            return dao.Insert(article);
        }

        public Article SelectOne(string id)
        {
            DaoArticle dao = new DaoArticle();
            return dao.SelectOneById(id);
        }

        public List<Article> Select(string sql = "select * from Article order by AddDate desc")
        {
            DaoArticle dao = new DaoArticle();
            try
            {
                return dao.Select(sql);
            }
            catch 
            {
            }
            return new List<Article>();
        }
    }
}
