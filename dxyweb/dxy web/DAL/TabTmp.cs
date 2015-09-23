using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TabTmp
    {
        public bool Insert(string name,string num)
        {
            string sql = "insert into Tmp (Name,Num) values(?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@Name",name), 
                                               new OleDbParameter("@Num",num)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }
    }
}
