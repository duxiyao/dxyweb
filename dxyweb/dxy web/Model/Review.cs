using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Review
    {
        private int id;
        private int articleId;
        private DateTime reviewDate; 
        private string reviewContentPath;

        public string ReviewContentPath
        {
            get { return reviewContentPath; }
            set { reviewContentPath = value; }
        }
                  
        public DateTime ReviewDate
        {
            get { return reviewDate; }
            set { reviewDate = value; }
        }

        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
