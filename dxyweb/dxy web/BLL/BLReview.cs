using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class BLReview
    {
        public bool Insert(int articleId, int leaveMsgId, DateTime reviewDate, string reviewContentPath)
        {
            Review rev = new Review();
            rev.ArticleId = articleId; 
            rev.ReviewDate = reviewDate;
            rev.ReviewContentPath = reviewContentPath;
            DaoReview dao = new DaoReview();
            return dao.Insert(rev);
        }

        public List<Review> SelectByArticleId(string artId)
        {
            DaoReview dao = new DaoReview();
            return dao.SelectByArtcleId(artId);
        }
    }
}
