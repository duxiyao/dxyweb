using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLib
{
    [Table("tab_user")]
    public class User
    {
        [Key("")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
