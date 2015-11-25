using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SqlLib
{
    public class ClsUtil
    {
        public static bool IsKey(PropertyInfo proper, out string keyName)
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

        public static bool IsKey(PropertyInfo proper)
        {
            Object[] objs = proper.GetCustomAttributes(typeof(KeyAttribute), true);
            if (objs.Length > 0)
            {
                return true;
            }
            if (proper.Name.ToLower().Equals("id"))
                return true;
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
            else
            {
                tableName = type.Name;
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
            Object[] objs = proper.GetCustomAttributes(typeof(FieldAttribute), true);
            if (objs.Length > 0)
            {
                FieldAttribute cAttribute = objs[0] as FieldAttribute;
                columnName = cAttribute.Fields;
            }
            else
            {
                columnName = proper.Name;
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

        public static void GetColSqlNameValue(object obj, PropertyInfo proper, out string colSqlName, out string colSqlValue)
        {
            Object[] objs = proper.GetCustomAttributes(typeof(FieldAttribute), true);
            if (objs.Length > 0)
            {
                FieldAttribute cAttribute = objs[0] as FieldAttribute;
                colSqlName = cAttribute.Fields;
            }
            else
            {
                colSqlName = proper.Name;
            }
            string ppName = proper.PropertyType.Name.ToLower();
            if (ppName.Equals("string"))
            {
                colSqlValue = "'" + proper.GetValue(obj, null) + "'";
            }
            else if (ppName.Contains("int"))
            {
                string strv = Convert.ToString(proper.GetValue(obj, null));
                int intv = int.Parse(strv);
                if (intv != 0)
                    colSqlValue = Convert.ToString(strv);
                else
                    colSqlValue = null;
            }
            else if (ppName.Contains("datetime"))
            {
                string strv = Convert.ToString(proper.GetValue(obj, null));
                if ("0001/1/1 0:00:00".Equals(strv))
                {
                    colSqlValue = null;
                }
                else
                    colSqlValue = "'" + strv + "'";
            }
            else
            {
                colSqlValue = Convert.ToString(proper.GetValue(obj, null));
            }
        }

        public static string GetSqlSet(object obj, PropertyInfo proper)
        {
            if (ClsUtil.IsKey(proper))
                return null;
            string colSqlName = string.Empty;
            string colSqlValue = string.Empty;
            Object[] objs = proper.GetCustomAttributes(typeof(FieldAttribute), true);
            if (objs.Length > 0)
            {
                FieldAttribute cAttribute = objs[0] as FieldAttribute;
                colSqlName = cAttribute.Fields;
            }
            else
            {
                colSqlName = proper.Name;
            }
            string ppName = proper.PropertyType.Name.ToLower();
            if (ppName.Equals("string"))
            {
                colSqlValue = "'" + proper.GetValue(obj, null) + "'";
            }
            else if (ppName.Contains("int"))
            {
                string strv = Convert.ToString(proper.GetValue(obj, null));
                int intv = int.Parse(strv);
                if (intv != 0)
                    colSqlValue = Convert.ToString(strv);
                else
                    colSqlValue = null;
            }
            else if (ppName.Contains("datetime"))
            {
                string strv = Convert.ToString(proper.GetValue(obj, null));
                if ("0001/1/1 0:00:00".Equals(strv))
                {
                    colSqlValue = null;
                }
                else
                    colSqlValue = "'" + strv + "'";
            }
            else
            {
                colSqlValue = Convert.ToString(proper.GetValue(obj, null));
            }
            if (colSqlValue == null)
                return null;
            else
                return colSqlName + "=" + colSqlValue;
        }

        public static string GetIdWhereSql(object obj)
        {
            PropertyInfo properKey = null;
            string keyName = string.Empty;
            string keyValue = string.Empty;
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();

            foreach (PropertyInfo p in myPropertyInfo)
            {
                if (ClsUtil.IsKey(p))
                {
                    properKey = p;
                    break;
                }
                else if (p.Name.ToLower().Equals("id") && properKey==null)
                    properKey = p;
                else
                    continue;
            }

            if (properKey == null)
            {
                return null;
            }
            Object[] ok = properKey.GetCustomAttributes(typeof(KeyAttribute), true);
            if (ok.Length > 0)
            {
                KeyAttribute cAttribute = ok[0] as KeyAttribute;
                if (cAttribute != null)
                {
                    keyName = cAttribute._Key;
                }
            }

            if (keyName.Equals(string.Empty))
            {
                keyName = properKey.Name;
            }

            string ppName = properKey.PropertyType.Name.ToLower();
            if (ppName.Equals("string"))
            {
                keyValue = "'" + properKey.GetValue(obj, null) + "'";
            }
            else if (ppName.Contains("int"))
            {
                string strv = Convert.ToString(properKey.GetValue(obj, null));
                int intv = int.Parse(strv);
                if (intv != 0)
                    keyValue = Convert.ToString(strv);
                else
                    keyValue = null;
            }
            else if (ppName.Contains("datetime"))
            {
                string strv = Convert.ToString(properKey.GetValue(obj, null));
                if ("0001/1/1 0:00:00".Equals(strv))
                {
                    keyValue = null;
                }
                else
                    keyValue = "'" + strv + "'";
            }
            else
            {
                keyValue = Convert.ToString(properKey.GetValue(obj, null));
            }
            if (keyValue != null)
                return keyName +"="+ keyValue;
            else
                return null;
        }

    }
}
