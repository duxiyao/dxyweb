using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLib
{
    [TableAttribute("PE_Files")]
    public class PE_Files
    {
        [Transient()]
        public string TI { get; set; }
        [ColumnAttribute("ID")]
        public int ID { get; set; }
        [ColumnAttribute("Name")]
        public string Name { get; set; }
        [ColumnAttribute("Size")]
        public int Size { get; set; }
        [ColumnAttribute("Path")]
        public string Path { get; set; }
        [ColumnAttribute("UserName")]
        public string UserName { get; set; }
        [ColumnAttribute("FileType")]
        public string FileType { get; set; }
    }
}
