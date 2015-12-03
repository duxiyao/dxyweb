using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ts
{
    [SqlLib.Table("tab_realtime_position")]
    public class RealPos
    {
        public int Id { get; set; }
        public int UbId { get; set; }
        public int UserType { get; set; }
        public string Latlng { get; set; }
        public DateTime DataBirthday { get; set; }
    }
}
