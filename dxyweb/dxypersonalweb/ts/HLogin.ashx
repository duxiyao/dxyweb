<%@ WebHandler Language="C#" Class="HLogin" %>

using System;
using System.Web;

public class HLogin : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (!MMUtil.IsCanDeal(context))
            return;

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
        if (!"phone".Equals(type))
            return;
        string phone = nvc["phone"];
        string pwd = nvc["pwd"];
        BLL.ts.BLUserInfo bl = new BLL.ts.BLUserInfo();
        BLL.Response res = bl.ExistsByPhone(phone, pwd);
        resp.Write(res.ToJson());
    }

    private void TryQQ(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {
        if (!"qq".Equals(type))
            return;

        string qqOpenId = nvc["qqOpenId"];
        string nickname = nvc["nickname"];
        string figureurl_qq_2 = nvc["figureurl_qq_2"];
        BLL.ts.BLUserInfo bl = new BLL.ts.BLUserInfo();
        BLL.Response res = bl.ExistsByQQOpenId(qqOpenId, nickname, figureurl_qq_2);
        resp.Write(res.ToJson());
        
    }

    private void TryWx(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {
        if (!"wx".Equals(type))
            return;

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}