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
        public void insert(string identity,string price,string praise,string title, string tags, string latitude, string longitude, string radius, string addr, string locType, string locationDescribe, string poiInfo)
        {

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

            }
        }

        private void add(string k, string v, Dictionary<string, string> dic)
        {
            if (v != null && v.Trim().Length > 0)
                dic.Add(k, v);
        }
    }
}
