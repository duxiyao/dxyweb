using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.ts;
using BDMapLib;

namespace BLL.ts
{
    public class BLPOIInfo
    {
        public bool insert(string ubId, string identity, string price, string praise, string title, string tags, string latitude, string longitude, string radius, string addr, string locType, string locationDescribe, string poiInfo)
        {
            if (ubId == null || ubId.Trim().Length == 0)
                return false;



            Dictionary<string, string> dic = new Dictionary<string, string>();
            add("title", title, dic);
            add("address", addr, dic);
            add("tags", tags, dic);
            add("latitude", latitude, dic);
            add("longitude", longitude, dic);

            add("identity", identity, dic);
            add("price", price, dic);
            add("praise", praise, dic);
            EnCreatePOI en = POI.CreatePOI(dic);

            if (en.Status == 0)
            {
                TSPOIInfo poi = new TSPOIInfo();
                poi.Tags = tags;
                poi.Latitude = latitude;
                poi.Longitude = longitude;
                poi.Radius = radius;
                poi.Addr = addr;
                poi.LocType = locType;
                poi.LocationDescribe = locationDescribe;
                poi.poiInfo = poiInfo;
                poi.PoiId = en.Id;
                if (SqlLib.DbUtil.Insert(poi))
                {
                    if ("student".Equals(identity))
                    {
                        Model.ts.BStudentInfo sinfo = SqlLib.DbUtil.GetModelByWhere<Model.ts.BStudentInfo>("ubid=" + ubId);
                        if (sinfo != null && sinfo.PoiId != null && sinfo.PoiId.Trim().Length > 0)
                        {
                            //SqlLib.DbUtil.DeleteByWhere<Model.ts.TSPOIInfo>("")
                            BDMapLib.POI.DeletePOI(sinfo.PoiId);
                        }

                        Model.ts.BStudentInfo info = new BStudentInfo();
                        info.PoiId = en.Id;
                        if (SqlLib.DbUtil.UpdateByWhere(info, "ubid=" + ubId ))
                            return true;
                    }
                    else if ("teacher".Equals(identity))
                    {
                        Model.ts.BTeacherInfo sinfo = SqlLib.DbUtil.GetModelByWhere<Model.ts.BTeacherInfo>("ubid=" + ubId);
                        if (sinfo != null && sinfo.PoiId != null && sinfo.PoiId.Trim().Length > 0)
                        {
                            //SqlLib.DbUtil.DeleteByWhere<Model.ts.TSPOIInfo>("")
                            BDMapLib.POI.DeletePOI(sinfo.PoiId);
                        }

                        Model.ts.BTeacherInfo info = new BTeacherInfo();
                        info.PoiId = en.Id;
                        if (SqlLib.DbUtil.UpdateByWhere(info, "ubid='" + ubId + "'"))
                            return true;
                    }
                }
            }
            return false;
        }

        private void add(string k, string v, Dictionary<string, string> dic)
        {
            if (v != null && v.Trim().Length > 0)
                dic.Add(k, v);
        }
    }
}
