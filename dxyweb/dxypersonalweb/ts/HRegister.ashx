<%@ WebHandler Language="C#" Class="HRegister" %>

using System;
using System.Web;

public class HRegister : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string phone = context.Request.Form["phone"];
        string pwd = context.Request.Form["pwd"];
        string verifyCode = context.Request.Form["verifyCode"];
        BLL.ts.BLUserInfo bl = new BLL.ts.BLUserInfo();
        
        BLL.Response res = bl.RegisterUser(phone, pwd);
        if (res.Code == BLL.ResCode.SUCCESS)
        {
            //string voip = bl.GenerateVoipInfo(phone);
            //send code
            //res = bl.QueryUser(phone, pwd);
        }
        context.Response.Write(res.ToJson());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}