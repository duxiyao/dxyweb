<%@ WebHandler Language="C#" Class="HRegister" %>

using System;
using System.Web;

public class HRegister : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string phone = context.Request.Form["phone"];
        string pwd = context.Request.Form["pwd"];
        string verifyCode = context.Request.Form["verifyCode"];
        BLL.ts.BLUserInfo bl = new BLL.ts.BLUserInfo();
        BLL.Response res = bl.RegisterUserByPhone(phone, pwd, verifyCode);
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