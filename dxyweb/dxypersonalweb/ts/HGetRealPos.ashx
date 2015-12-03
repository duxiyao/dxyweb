<%@ WebHandler Language="C#" Class="HGetRealPos" %>

using System;
using System.Web;
using Model.ts;
using SqlLib;

public class HGetRealPos : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //if (!MMUtil.IsCanDeal(context))
        //    return;
        string ubId = context.Request.Form["ubId"];
        RealPos rp = DbUtil.GetModelByWhere<RealPos>("ubid=" + ubId + " order by dataBirthday desc");
        BLL.Response res = new BLL.Response();
        if (rp != null)
        {
            string pos = rp.Latlng;
            if (!StringUtil.IsEmpty(pos)) 
            {
                res.Code = BLL.ResCode.SUCCESS;
                res.Data = rp;                 
            }            
        }
        context.Response.Write(res.ToJson());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}