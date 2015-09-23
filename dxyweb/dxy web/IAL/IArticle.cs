using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IAL
{
    public interface IArticle
    {
        List<Article> Select(string sql);
        bool Insert(Article article);
        bool Update(Article article);
        bool Delete(int id);
    }
}
