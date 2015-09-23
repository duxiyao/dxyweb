using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAL
{ 
    interface ISelect<T>
    {
        List<T> Select(string sql);
    }

    interface IInsert<T>
    {
        bool Insert(T t);
    }

    interface IUpdate<T>
    {
        bool Update(T t);
    }

    interface IDelete
    {
        bool Delete(int id);
    }
}
