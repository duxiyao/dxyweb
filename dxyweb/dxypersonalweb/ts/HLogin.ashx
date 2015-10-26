<%@ WebHandler Language="C#" Class="HLogin" %>

using System;
using System.Web;

public class HLogin : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string type = context.Request.Form["type"];
        if (type != null && type.Length > 0)
        {
            TryPhone(type, context.Request.Form, context.Response);
            TryQQ(type, context.Request.Form, context.Response);
            TryWx(type, context.Request.Form, context.Response);
        }
    }

    private void TryPhone(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {
        string phone = nvc["phone"];
        string pwd = nvc["pwd"];
        BLL.ts.BLUserInfo bl = new BLL.ts.BLUserInfo();
        //BLL.Response res = bl.RegisterUserByPhone(phone, pwd, verifyCode);
        //resp.Write(res.ToJson());
    }

    private void TryQQ(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {

    }

    private void TryWx(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {

    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}