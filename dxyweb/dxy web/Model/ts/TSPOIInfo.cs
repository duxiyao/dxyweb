using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ts
{
    [SqlLib.Table("tab_ts_poi_info")]
    public class TSPOIInfo
    {
        public int Id
        {
            get;
            set;
        }

        public string PoiId
        { get; set; }

        public string Tags
        {
            get;
            set;
        }

        public string Latitude
        {
            get;
            set;
        }

        public string Longitude
        {
            get;
            set;
        }

        public string Radius
        {
            get;
            set;
        }

        public string Addr
        {
            get;
            set;
        }

        public string LocType
        {
            get;
            set;
        }

        public string LocationDescribe
        {
            get;
            set;
        }

        public string poiInfo
        {
            get;
            set;
        }
    }
}
