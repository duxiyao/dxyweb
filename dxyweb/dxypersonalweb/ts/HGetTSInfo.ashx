<%@ WebHandler Language="C#" Class="HGetTSInfo" %>

using System;
using System.Web;
using Model.ts;

public class HGetTSInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string id = context.Request.Form["id"];
        string type = context.Request.Form["type"];
        BLL.Response res = new BLL.Response();
        if ("student".Equals(type))
        {
            BStudentInfo bInfo = SqlLib.DbUtil.GetModel<BStudentInfo>("id=" + id);
            if (int.Parse(id) == bInfo.Id)
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
            BTeacherInfo tInfo = SqlLib.DbUtil.GetModel<BTeacherInfo>("id=" + id);
            if (int.Parse(id) == tInfo.Id)
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

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}