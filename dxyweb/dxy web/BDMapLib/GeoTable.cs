using System;
using System.Collections.Generic;
using System.Text;

namespace BDMapLib
{
    public class GeoTable
    {
        public static bool CreateTab(string tabName,string geotype="1")
        {
            string url = "http://api.map.baidu.com/geodata/v3/geotable/create";
            string ret=Http.c(url).Add("name", tabName).Add("geotype", geotype).Add("is_published", "1").Add("ak", Conf.AK).ExePost();
            EnCreateGeoTab ecgt = EnCreateGeoTab.FromJson<EnCreateGeoTab>(ret);
            if (ecgt.Status == 0)
                return true;
            else
                return false;
        }

        public static string QueryList()
        {
            string url = "http://api.map.baidu.com/geodata/v3/geotable/list";
            string ret = Http.c(url).Add("ak", Conf.AK).ExeGet();
            return ret;
        }

        public static string QueryTabById(string id)
        {
            string url = "http://api.map.baidu.com/geodata/v3/geotable/detail";
            string ret = Http.c(url).Add("id",id).Add("ak", Conf.AK).ExeGet();
            return ret;
        }

        public static void Update()
        {
            string url = "http://api.map.baidu.com/geodata/v3/geotable/update";
        }

        public static string DelTabById(string id)
        {
            string url = "http://api.map.baidu.com/geodata/v3/geotable/delete";
            string ret = Http.c(url).Add("id", id).Add("ak", Conf.AK).ExePost();
            return ret;
        }
    }
}
