using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SqlLib
{
    public class DbUtil
    {
        public static bool Insert(Object obj)
        {
            string sql = SqlBuilder.BuildInsert(obj);
            if (sql == null || sql.Trim().Length == 0)
                return false;
            int ret = SQLHelper.ExecuteSql(sql);
            return ret > 0;
        }

        public static bool UpdateByWhere(Object obj,string where)
        {
            string sql = SqlBuilder.BuildUpdate(obj,where);
            if (sql == null || sql.Trim().Length == 0)
                return false;
            int ret = SQLHelper.ExecuteSql(sql);
            return ret > 0;
        }

        public static bool Update(Object obj)
        {
            string sql = SqlBuilder.BuildUpdate(obj);
            if (sql == null || sql.Trim().Length == 0)
                return false;
            int ret = SQLHelper.ExecuteSql(sql);
            return ret > 0;
        }

        public static bool DeleteByWhere<T>(string where) where T :class ,new()
        {
            T t = new T();
            string sql = SqlBuilder.BuildDelete(t,where);
            if (sql == null || sql.Trim().Length == 0)
                return false;
            int ret = SQLHelper.ExecuteSql(sql);
            return ret > 0;
        }

        public static bool Delete(Object obj)
        {
            string sql = SqlBuilder.BuildDelete(obj);
            if (sql == null || sql.Trim().Length == 0)
                return false;
            int ret = SQLHelper.ExecuteSql(sql);
            return ret > 0;
        }

        public static T GetModel<T>() where T : class, new()
        {
            return GetModel<T>(null);
        }

        public static T GetModelByWhere<T>(string where) where T : class, new()
        {
            string sql = string.Empty;
            TableInfo ti = new TableInfo(new T());
            if (where == null || where.Trim().Length == 0)
                sql = string.Format("select top 1 * from {0}", ti.TableName);
            else
                sql = string.Format("select * from {0} where {1}", ti.TableName, where);
            return GetModel<T>(sql);
        }

        public static T GetModel<T>(string sql) where T : class, new()
        {
            T t = new T();
            TableInfo ti = new TableInfo(t);
            if (sql == null || sql.Trim().Length == 0)
                sql = string.Format("select top 1 * from {0}", ti.TableName);

            OleDbDataReader reader = SQLHelper.ExecuteReader(sql);

            if (reader.Read())
            {
                int len = reader.FieldCount;
                for (int i = 0; i < len; i++)
                {
                    try
                    {
                        string colName = reader.GetName(i);
                        if (ti.ColInfo.PropertyInfos.ContainsKey(colName))
                            ti.ColInfo.PropertyInfos[colName].SetValue(t, reader.GetValue(i), null);
                        else
                            ti.ColInfo.KeyPropertyInfo.SetValue(t, reader.GetValue(i), null);
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                }
            }
            reader.Close();

            return t;
        }

        public static List<T> GetList<T>() where T : class, new()
        {
            return GetList<T>(null);
        }

        public static List<T> GetListByWhere<T>(string where) where T : class, new()
        {
            string sql=string.Empty;
            TableInfo ti = new TableInfo(new T());
            if (where == null || where.Trim().Length == 0)
                sql = string.Format("select * from {0}", ti.TableName);
            else 
                sql = string.Format("select * from {0} where {1}", ti.TableName,where);
            return GetList<T>(sql);
        }

        public static List<T> GetList<T>(string sql) where T : class, new()
        {
            List<T> tList = new List<T>();            
            TableInfo ti = new TableInfo(new T());
            if (sql == null || sql.Trim().Length == 0)
                sql = string.Format("select * from {0}", ti.TableName);

            OleDbDataReader reader = SQLHelper.ExecuteReader(sql);

            while (reader.Read())
            {
                T t = new T();
                int len = reader.FieldCount;
                for (int i = 0; i < len; i++)
                {
                    try
                    {
                        string colName = reader.GetName(i); 
                        if (ti.ColInfo.PropertyInfos.ContainsKey(colName))
                            ti.ColInfo.PropertyInfos[colName].SetValue(t, reader.GetValue(i), null);
                        else
                            ti.ColInfo.KeyPropertyInfo.SetValue(t, reader.GetValue(i), null);
                    }
                    catch (Exception)
                    {                        
                        
                    }
                    
                }
                tList.Add(t);
            }
            reader.Close();
            return tList;
        }
    }
}
