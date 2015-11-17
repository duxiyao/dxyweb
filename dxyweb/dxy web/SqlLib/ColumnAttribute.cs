using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLib
{

    /// <summary>
    /// 描述列
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string columnName)
        {
            this._columnName = columnName;
        }
        private string _columnName;
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
    }
}
