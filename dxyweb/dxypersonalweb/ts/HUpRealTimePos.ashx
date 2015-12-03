<%@ WebHandler Language="C#" Class="HUpRealTimePos" %>

using System;
using System.Web;
using Model.ts;
using SqlLib;

public class HUpRealTimePos : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (!MMUtil.IsCanDeal(context))
            return;
        System.Collections.Specialized.NameValueCollection nvc = context.Request.Form;
        string ubId = nvc["ubid"];
        string userType = nvc["userType"];
        string latlng = nvc["latlng"];
        if (!StringUtil.IsEmpty(ubId))
        {
            RealPos rp = new RealPos();
            rp.UbId = int.Parse(ubId);
            try
            {
                rp.UserType = int.Parse(userType);
            }
            catch (Exception)
            {                
            }
            rp.Latlng = latlng;
            rp.DataBirthday = DateTime.Now;
            DbUtil.Insert(rp);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}