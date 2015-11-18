using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
        public string _Key{get;set;}
        public KeyAttribute(string key)
        {
            _Key = key;
        }
    }
}
