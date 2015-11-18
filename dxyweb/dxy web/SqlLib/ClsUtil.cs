using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SqlLib
{
    public class ClsUtil
    {
        public static bool IsKey(PropertyInfo proper,out string keyName)
        {
            keyName = string.Empty;
            Object[] objs = proper.GetCustomAttributes(typeof(KeyAttribute), true);
            if (objs.Length > 0)
            {
                KeyAttribute cAttribute = objs[0] as KeyAttribute;
                if (cAttribute != null)
                    keyName = cAttribute._Key;
                return true;
            }
            return false;
        }
        

        public static string GetTableName(object obj)
        {
            string tableName = string.Empty;
            Type type = obj.GetType();
            Object[] objs = type.GetCustomAttributes(typeof(TableAttribute), true);
            if (objs.Length > 0)
            {
                TableAttribute tAttribute = objs[0] as TableAttribute;
                tableName = tAttribute.TableName;
            }
            return tableName;
        }


        /// <summary>
        /// 获取表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetTableName<T>()
        {
            string tableName = string.Empty;
            Type type = typeof(T);
            Object[] objs = type.GetCustomAttributes(typeof(TableAttribute), true);
            if (objs.Length > 0)
            {
                TableAttribute tAttribute = objs[0] as TableAttribute;
                tableName = tAttribute.TableName;
            }
            return tableName;
        }
        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="proper"></param>
        /// <returns></returns>
        public static string GetColumnName(PropertyInfo proper)
        {
            string columnName = string.Empty;
            Object[] objs = proper.GetCustomAttributes(typeof(ColumnAttribute), true);
            if (objs.Length > 0)
            {
                ColumnAttribute cAttribute = objs[0] as ColumnAttribute;
                columnName = cAttribute.ColumnName;
            }
            return columnName;
        }

        public static bool IsHide(PropertyInfo proper)
        {
            Object[] objs = proper.GetCustomAttributes(typeof(Transient), true);
            if (objs.Length > 0)
            {
                Transient cAttribute = objs[0] as Transient;
                return true;
            }
            else
                return false;
        }
    }
}
