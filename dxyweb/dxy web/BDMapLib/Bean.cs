using System;
using System.Collections.Generic;
using System.Text;

namespace BDMapLib
{
    public class Entity
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public static T FromJson<T>(string ret) where T : Entity
        {
            Entity en = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(ret);
            if (en.Message != null)
                en.Message = Uri.UnescapeDataString(en.Message);
            return (T)en;
        }
    }

    public class POIEntity : Entity
    {
        public int Size { get; set; }
        public int Total { get; set; }

    }

    public class EnLocalPOI:POIEntity
    {
        public List<ContentEntity> Contents { get; set; }
    }

    public class ContentEntity : Entity
    {
        public string Uid { get; set; }
        public string Geotable_id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int Coord_type { get; set; }
        public string Tags { get; set; }
        public List<string> Location { get; set; }
        public int Distance { get; set; }


    }


    public class EnCreatePOI : Entity
    {
        public string Id { get; set; }
    }

    public class EnCreateGeoTab : Entity
    {
        public string Id { get; set; }
    }

    public class EnCreateCol : Entity
    {
        public string Id { get; set; }
    }
}
