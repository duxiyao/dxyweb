using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLib
{
    /// <summary>
    /// 不对应到数据库的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Transient : Attribute
    {
        public Transient()
        {

        }
    }
}
