using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ts
{
    [SqlLib.Table("tab_ts_teacher_info")]
    public class BTeacherInfo
    {
        public int Id { get; set; }
        public string PoiId { get; set; }
        public int UbId { get; set; }
        public DateTime DataBirthday { get; set; }
        public string Grade { get; set; }
        public string Subject { get; set; }
        public string ArtSubject { get; set; }
    }
}
