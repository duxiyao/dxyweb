using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IAL;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
    public class DaoArticle:IArticle
    {
        #region IArticle 成员

        public List<Article> SelectFirstTow()
        {
            string sql = "select top 2 * from Article order by AddDate desc";
            List<Article> l = Select(sql);
            return l;
        }

        public Article SelectOneById(string id)
        {
            if (id == null)
            {
                string sql = "select * from Article order by AddDate desc";
                return Select(sql)[0];
            }
            else
            {
                string sql = "select * from Article where Id=" + id;
                return Select(sql)[0];
            }
            return null;
        }

        public List<Article> Select(string sql)
        {            
            DataSet ds = SQLHelper.Query(sql);
            DataTable dt = ds.Tables[0];
            List<Article> l = new List<Article>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Article article = new Article();
                    article.Id = int.Parse(dr["Id"].ToString());
                    article.ArticlePath = dr["ArticlePath"].ToString();
                    article.ArticleName = dr["ArticleName"].ToString();
                    article.AddDate = DateTime.Parse(dr["AddDate"].ToString());
                    l.Add(article);
                }
            }
            return l;
        }

        public bool Insert(Article article)
        {
            string sql = "insert into Article (ArticleName,AddDate,ArticlePath) values(?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@ArticleName",article.ArticleName),
                                               new OleDbParameter("@AddDate",article.AddDate),
                                               new OleDbParameter("@ArticlePath",article.ArticlePath)}; 
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }

        public bool Update(Article article)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
