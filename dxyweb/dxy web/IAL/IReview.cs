using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IAL
{
    public interface IReview
    {
        List<Review> Select(string sql);
        bool Insert(Review review);
    }
}
