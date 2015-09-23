using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Article
    {
        private int id;
        private string articleName;
        private DateTime addDate;
        private string articlePath;

        public string ArticlePath
        {
            get { return articlePath; }
            set { articlePath = value; }
        }

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }

        public string ArticleName
        {
            get { return articleName; }
            set { articleName = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
