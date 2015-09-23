using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAL;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class DaoReview:IReview
    {
        #region IReview 成员
        public List<Review> SelectByArtcleId(string artId)
        {
            string sql = "select * from Review where ArticleId=" + artId + " order by ReviewDate desc";
            return Select(sql);
        }

        public List<Review> Select(string sql)
        {
            DataSet ds = SQLHelper.Query(sql);
            DataTable dt = ds.Tables[0];
            List<Review> l = new List<Review>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Review review = new Review();
                    review.Id = int.Parse(dr["Id"].ToString());
                    review.ArticleId = int.Parse(dr["ArticleId"].ToString()); 
                    review.ReviewDate = DateTime.Parse(dr["ReviewDate"].ToString());
                    review.ReviewContentPath = dr["ReviewContentPath"].ToString();
                    l.Add(review);
                }
            }
            return l;
        }

        public bool Insert(Review review)
        {
            string sql = "insert into Review (ArticleId,ReviewDate,ReviewContentPath) values(?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@ArticleId",review.ArticleId),
                                               new OleDbParameter("@ReviewDate",review.ReviewDate), 
                                               new OleDbParameter("@ReviewContentPath",review.ReviewContentPath)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }

        #endregion
    }
}
