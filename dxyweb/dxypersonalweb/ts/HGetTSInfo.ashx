<%@ WebHandler Language="C#" Class="HGetTSInfo" %>

using System;
using System.Web;
using Model.ts;

public class HGetTSInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string id = context.Request.Form["uBid"];
        string type = context.Request.Form["type"];
        BLL.Response res = new BLL.Response();
        if ("student".Equals(type))
        {
            BStudentInfo bInfo = SqlLib.DbUtil.GetModelByWhere<BStudentInfo>("uBid=" + id);
            if (int.Parse(id) == bInfo.UbId)
            {
                res.Data = bInfo;
                res.Code = BLL.ResCode.SUCCESS;
            }
            else
            {
                res.Code = BLL.ResCode.ERRQUERYINFO;
                res.Msg = BLL.ResCode.STRERRQUERYINFO;
            }
        }

        if ("teacher".Equals(type))
        {
            BTeacherInfo tInfo = SqlLib.DbUtil.GetModelByWhere<BTeacherInfo>("uBid=" + id);
            if (int.Parse(id) == tInfo.UbId)
            {
                res.Data = tInfo;
                res.Code = BLL.ResCode.SUCCESS;
            }
            else
            {
                res.Code = BLL.ResCode.ERRQUERYINFO;
                res.Msg = BLL.ResCode.STRERRQUERYINFO;
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