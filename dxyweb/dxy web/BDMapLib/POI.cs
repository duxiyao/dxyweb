using System;
using System.Collections.Generic;
using System.Text;

namespace BDMapLib
{
    public class POI
    {
        public static EnCreatePOI CreatePOI(Dictionary<string, string> dic)
        {
            if(dic==null)
                dic=new Dictionary<string,string>();
            dic.Add("coord_type","3");
            dic.Add("geotable_id",Conf.GEOID);
            dic.Add("ak",Conf.AK);
            string url="http://api.map.baidu.com/geodata/v3/poi/create";
            string ret = Http.c(url).SetEscapeTrue().SetKv(dic).ExePost();
            EnCreatePOI en = Entity.FromJson<EnCreatePOI>(ret);
            return en;
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

        /// <summary>
        /// ak=您的ak&geotable_id=****&location=116.395884,39.932154&radius=1000&tags=酒店&sortby=distance:1|price:1&filter=price:200,300
        /// </summary>
        /// <param name="dic"></param>
        public static string NearbyPOI(Dictionary<string, string> dic)
        {
            if (dic == null)
                dic = new Dictionary<string, string>();
            dic.Add("geotable_id", Conf.GEOID);
            dic.Add("ak", Conf.AK);
            string url = "http://api.map.baidu.com/geosearch/v3/nearby";
            string ret = Http.c(url).SetEscapeTrue().SetKv(dic).ExeGet();
            POIEntity en = POIEntity.FromJson<POIEntity>(ret);
            return ret;
        }

        /// <summary>
        /// region=北京&ak=您的ak&geotable_id=****&tags=酒店&sortby=distance:1|price:1 &filter=price:200,300
        /// </summary>
        /// <param name="dic"></param>
        public static EnLocalPOI LocalPOI(Dictionary<string, string> dic)
        {
            if (dic == null)
                dic = new Dictionary<string, string>();
            dic.Add("geotable_id", Conf.GEOID);
            dic.Add("ak", Conf.AK);
            string url = "http://api.map.baidu.com/geosearch/v3/local";
            string ret = Http.c(url).SetEscapeTrue().SetKv(dic).ExeGet();
            EnLocalPOI en = POIEntity.FromJson<EnLocalPOI>(ret);
            return en;
        }

        public static EnCreatePOI DeletePOI(string poiId)
        {
            
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", poiId);
            dic.Add("coord_type", "3");
            dic.Add("geotable_id", Conf.GEOID);
            dic.Add("ak", Conf.AK);
            string url = "http://api.map.baidu.com/geodata/v3/poi/delete";
            string ret = Http.c(url).SetEscapeTrue().SetKv(dic).ExePost();
            EnCreatePOI en = Entity.FromJson<EnCreatePOI>(ret);
            return en;
        }
    }
}

