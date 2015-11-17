using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLib
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]  
    public class TableAttribute : Attribute  
    {  
        private string _TableName;  
        /// <summary>  
        /// 映射的表名  
        /// </summary>  
        public string TableName  
        {  
            get { return _TableName; }  
        }  
        /// <summary>  
        /// 定位函数映射表名；  
        /// </summary>  
        /// <param name="table"></param>  
        public TableAttribute(string table)  
        {  
            _TableName = table;  
        }  
    }  
}
