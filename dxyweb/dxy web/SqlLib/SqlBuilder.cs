using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SqlLib
{
    public class SqlBuilder
    {


        public static string BuildInsert(object obj)
        {
            string tabName = ClsUtil.GetTableName(obj);
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("insert into {0} values(", tabName);
            foreach (PropertyInfo p in myPropertyInfo)
            {
                if (!Entity.GetColumnName(p).Equals("Id"))
                {
                    sql += "'" + p.GetValue(obj, null) + "',";
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            return sql;
        }

        public static string BuildUpdate(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("update {0} set ", obj.ToString().Replace("SqlLib.", ""));
            foreach (PropertyInfo p in myPropertyInfo)
            {
                //   Entity.GetColumnName(propertie[0])
                if (!Entity.GetColumnName(p).Equals("Id"))
                {
                    sql += Entity.GetColumnName(p) + "='" + p.GetValue(obj, null) + "',";
                    //     sql += "'" + p.GetValue(obj, null) + "',";
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " where id=" + myPropertyInfo[0].GetValue(obj, null);
            return sql;
        }

        public static string BuildUpdate(object obj,string where)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("update {0} set ", obj.ToString().Replace("SqlLib.", ""));
            foreach (PropertyInfo p in myPropertyInfo)
            {
                //   Entity.GetColumnName(propertie[0])
                if (!Entity.GetColumnName(p).Equals("Id"))
                {
                    sql += Entity.GetColumnName(p) + "='" + p.GetValue(obj, null) + "',";
                    //     sql += "'" + p.GetValue(obj, null) + "',";
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " where " + where;
            return sql;
        }

        public static string BuildDelete(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("delete from {0} where id={1}", obj.ToString().Replace("SqlLib.", ""), myPropertyInfo[0].GetValue(obj, null));
            return sql;
        }

        public static string BuildDelete(object obj,string where)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("delete from {0} where {1}", obj.ToString().Replace("SqlLib.", ""), where);
            return sql;
        }
    }
}
