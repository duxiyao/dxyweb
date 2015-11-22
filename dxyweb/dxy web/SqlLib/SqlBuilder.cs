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
            TableInfo ti = new TableInfo(obj);
            string sqlValue = String.Empty;
            string sqlColumn = String.Empty;

            foreach (string keyName in ti.ColInfo.PropertyInfos.Keys)
            {
                PropertyInfo pi = ti.ColInfo.PropertyInfos[keyName];
                if (!ClsUtil.IsHide(pi))
                {
                    object value = pi.GetValue(obj, null);
                    if (value != null)
                    {
                        string sqlColName=string.Empty;
                        string sqlColValue=string.Empty;
                        ClsUtil.GetColSqlNameValue(obj, pi, out sqlColName, out sqlColValue);
                        if (sqlColValue == null)
                            continue;
                        sqlColumn += sqlColName + ",";

                        sqlValue += sqlColValue + ",";
                    }
                }
            }
            if (sqlValue != null && sqlValue.Length>0)
            {
                sqlValue = sqlValue.Substring(0, sqlValue.Length - 1);
                sqlColumn = sqlColumn.Substring(0, sqlColumn.Length - 1);
            }
            else
                return string.Empty;

            return string.Format("insert into {0}({1}) values({2})", ti.TableName,sqlColumn,sqlValue);
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

        public static string BuildUpdate(object obj, string where)
        {
            TableInfo ti = new TableInfo(obj);
            string sqlSet = String.Empty;

            foreach (string keyName in ti.ColInfo.PropertyInfos.Keys)
            {
                PropertyInfo pi = ti.ColInfo.PropertyInfos[keyName];
                if (!ClsUtil.IsHide(pi))
                {
                    object value = pi.GetValue(obj, null);
                    if (value != null)
                    {
                        string item = ClsUtil.GetSqlSet(obj, pi);
                        if (item==null)
                            continue;
                        sqlSet += item + ",";

                    }
                }
            }
            if (sqlSet != null && sqlSet.Length > 0)
            {
                sqlSet = sqlSet.Substring(0, sqlSet.Length - 1);
            }
            else
                return string.Empty;

            return string.Format("update {0} set {1} where {2}", ti.TableName, sqlSet, where);
        }

        public static string BuildDelete(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("delete from {0} where id={1}", obj.ToString().Replace("SqlLib.", ""), myPropertyInfo[0].GetValue(obj, null));
            return sql;
        }

        public static string BuildDelete(object obj, string where)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("delete from {0} where {1}", obj.ToString().Replace("SqlLib.", ""), where);
            return sql;
        }
    }
}
