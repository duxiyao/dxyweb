using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ts
{
    [SqlLib.Table("tab_ts_student_info")]
    public class BStudentInfo
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
