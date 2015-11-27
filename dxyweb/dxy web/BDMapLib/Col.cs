using System;
using System.Collections.Generic;
using System.Text;

namespace BDMapLib
{
    public class Col
    {
        public static string CreateStrCol(string name, string key, string maxLen)
        {
            string url = "http://api.map.baidu.com/geodata/v3/column/create";
            string ret = Http.c(url).SetEscapeTrue().Add("name", name).Add("geotable_id", Conf.GEOID).Add("key", key).Add("type", "3").Add("max_length", maxLen).Add("is_index_field", "1").Add("default_value", "").Add("is_seach_field", "1").Add("ak", Conf.AK).ExePost();
            EnCreateCol ecc = EnCreateCol.FromJson<EnCreateCol>(ret);

            return ret;
        }

        public static string CreateDoubleCol(string name, string key)
        {
            string url = "http://api.map.baidu.com/geodata/v3/column/create";
            string ret = Http.c(url).SetEscapeTrue().Add("name", name).Add("geotable_id", Conf.GEOID).Add("key", key).Add("type", "2").Add("is_sortfilter_field", "1").Add("is_index_field", "1").Add("ak", Conf.AK).ExePost();
            EnCreateCol ecc = EnCreateCol.FromJson<EnCreateCol>(ret);

            return ret;
        }

        public static string CreateIntCol(string name, string key)
        {
            string url = "http://api.map.baidu.com/geodata/v3/column/create";
            string ret = Http.c(url).SetEscapeTrue().Add("name", name).Add("geotable_id", Conf.GEOID).Add("key", key).Add("type", "1").Add("is_sortfilter_field", "1").Add("is_index_field", "1").Add("ak", Conf.AK).ExePost();
            EnCreateCol ecc = EnCreateCol.FromJson<EnCreateCol>(ret);

            return ret;
        }

        public static string QueryList(string geotableId)
        {
            string url = "http://api.map.baidu.com/geodata/v3/column/list";
            string ret = Http.c(url).Add("geotable_id", geotableId).Add("ak", Conf.AK).ExeGet();

            return ret;
        }

        public static string QueryColById(string colId,string geotableId)
        {
            string url = "http://api.map.baidu.com/geodata/v3/column/detail";
            string ret = Http.c(url).Add("geotable_id", geotableId).Add("id",colId).Add("ak", Conf.AK).ExeGet();
            return ret;
        }

        public static void Update(string colId, string geotableId)
        {
            string url = "http://api.map.baidu.com/geodata/v3/column/update";
            string ret = Http.c(url).Add("geotable_id", geotableId).Add("id", colId).Add("ak", Conf.AK).Add("is_index_field","1").ExePost();
            string s = "";
        }

        public static string DelColById(string colId, string geotableId)
        {
            string url = "http://api.map.baidu.com/geodata/v3/column/delete";
            string ret = Http.c(url).Add("geotable_id", geotableId).Add("id", colId).Add("ak", Conf.AK).ExePost();
            Entity en = Entity.FromJson<Entity>(ret);
            return ret;
        }
    }
}
