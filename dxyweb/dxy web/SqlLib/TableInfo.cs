using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SqlLib
{
    public class TableInfo
    {
        private object obj;
        public string TableName { get; set; }
        public ColumnInfo ColInfo { get; set; }
        public TableInfo(object obj)
        {
            this.obj = obj;
            ColInfo = new ColumnInfo(obj);
            TableName = ClsUtil.GetTableName(obj);
        }
    }

    public class ColumnInfo
    {
        private object obj;
        public string KeyName;
        public PropertyInfo KeyPropertyInfo { get; set; }
        public Dictionary<string, PropertyInfo> PropertyInfos = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);

        public ColumnInfo(object obj)
        {
            this.obj = obj;
            Type type = obj.GetType();
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            
            foreach (PropertyInfo p in myPropertyInfo)
            {
                string _KeyName = String.Empty;
                if (ClsUtil.IsKey(p, out _KeyName))
                {
                    if (KeyName == null || KeyName.Length == 0)
                        this.KeyName = "id";
                    else
                        this.KeyName = _KeyName;
                    KeyPropertyInfo = p;
                    continue;
                }

                if (ClsUtil.IsHide(p))
                    continue;

                string colName = ClsUtil.GetColumnName(p);
                if (colName == null || colName.Length == 0)
                {
                    colName = p.Name;
                }
                PropertyInfos.Add(colName, p);
            }

        }


    }
}
