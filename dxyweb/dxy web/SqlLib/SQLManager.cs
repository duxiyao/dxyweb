using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;

namespace SqlLib
{
    public class SQLManager
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class, new()
        {
            List<T> tList = new List<T>();
            Type type = typeof(T);
            string sql = string.Format("select * from {0}", Entity.GetTableName<T>());

            //SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            //while (reader.Read())
            //{
            //    T t = new T();
            //    PropertyInfo[] properties = type.GetProperties();
            //    foreach (PropertyInfo p in properties)
            //    {
            //        string columnName = Entity.GetColumnName(p);
            //        p.SetValue(t, reader[columnName], null);
            //    }
            //    tList.Add(t);
            //}
            //reader.Close();
            return tList;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public object GetModel<T>(string id) where T : class, new()
        {
            T t = new T();
            Type type = typeof(T);
            PropertyInfo[] propertie = type.GetProperties();
            string sql = string.Format("select * from {0} where " + Entity.GetColumnName(propertie[0]) + "='{1}'", Entity.GetTableName<T>(), id);
            //SqlDataReader reader = DbHelperSQL.ExecuteReader(sql);
            //while (reader.Read())
            //{
            //    PropertyInfo[] properties = type.GetProperties();
            //    foreach (PropertyInfo p in properties)
            //    {
            //        string columnName = Entity.GetColumnName(p);
            //        p.SetValue(t, reader[columnName], null);
            //    }
            //}
            //reader.Close();
            return t;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public void Insert(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("insert into {0} values(", obj.ToString().Replace("SqlLib.", ""));
            foreach (PropertyInfo p in myPropertyInfo)
            {
                if (!Entity.GetColumnName(p).Equals("Id"))
                {
                    sql += "'" + p.GetValue(obj, null) + "',";
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            //DbHelperSQL.ExecuteSql(sql);
        }
        public void Edit(object obj)
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
            //     new Logger().Write("d:/text.txt", sql);
            //DbHelperSQL.ExecuteSql(sql);
        }
        public void Delete(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            string sql = string.Format("delete from {0} where id={1}", obj.ToString().Replace("SqlLib.", ""), myPropertyInfo[0].GetValue(obj, null));

            //DbHelperSQL.ExecuteSql(sql);
        }
    }
}
