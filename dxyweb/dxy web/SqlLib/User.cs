using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLib
{
    [Table("tab_user")]
    public class User
    {
        [Key("")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dt { get; set; }
    }
}
