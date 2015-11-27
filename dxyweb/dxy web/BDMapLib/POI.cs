using System;
using System.Collections.Generic;
using System.Text;

namespace BDMapLib
{
    public class POI
    {
        public static void CreatePOI(Dictionary<string,string> dic)
        {
            if(dic==null)
                dic=new Dictionary<string,string>();
            dic.Add("coord_type","3");
            dic.Add("geotable_id",Conf.GEOID);
            dic.Add("ak",Conf.AK);
            string url="http://api.map.baidu.com/geodata/v3/poi/create";
            string ret = Http.c(url).SetEscapeTrue().SetKv(dic).ExePost();
            Entity en = Entity.FromJson<Entity>(ret);
            string s = "";
        }

        public static void QueryPOI(Dictionary<string, string> dic)
        {
            if (dic == null)
                dic = new Dictionary<string, string>();
            dic.Add("geotable_id", Conf.GEOID);
            dic.Add("ak", Conf.AK);
            string url = "http://api.map.baidu.com/geodata/v3/poi/list";
            string ret = Http.c(url).SetEscapeTrue().SetKv(dic).ExeGet();
            Entity en = Entity.FromJson<Entity>(ret);
            string s = "";
        }

        public static void NearbyPOI(Dictionary<string, string> dic)
        {
            if (dic == null)
                dic = new Dictionary<string, string>();
            dic.Add("geotable_id", Conf.GEOID);
            dic.Add("ak", Conf.AK);
            string url = "http://api.map.baidu.com/geosearch/v3/nearby";
            string ret = Http.c(url).SetEscapeTrue().SetKv(dic).ExeGet();
            POIEntity en = POIEntity.FromJson<POIEntity>(ret);
            string s = "";
        }
    }
}

