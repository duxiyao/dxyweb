<%@ WebHandler Language="C#" Class="HCreatePOI" %>

using System;
using System.Web;

public class HCreatePOI : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (!MMUtil.IsCanDeal(context))
            return;
        string ubId = context.Request.Form["ubId"];
        string identity = context.Request.Form["identity"];
        string price = context.Request.Form["price"];
        string praise = context.Request.Form["praise"];
        string title = context.Request.Form["title"];
        string tags = context.Request.Form["tags"];
        string latitude = context.Request.Form["latitude"];
        string longitude = context.Request.Form["longitude"];
        string radius = context.Request.Form["radius"];
        string addr = context.Request.Form["addr"];
        string locType = context.Request.Form["locType"];
        string locationDes = context.Request.Form["locationDes"];
        string poiInfo = context.Request.Form["poiInfo"];

        BLL.Response res = new BLL.Response();
        BLL.ts.BLPOIInfo bl = new BLL.ts.BLPOIInfo();
        if (ubId != null && ubId.Trim().Length>0&&bl.insert(ubId, identity, price, praise, title, tags, latitude, longitude, radius, addr, locType, locationDes, poiInfo))
        {
            res.Code = BLL.ResCode.SUCCESS;
        }
        
        context.Response.Write(res.ToJson());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}