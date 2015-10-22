<%@ WebHandler Language="C#" Class="HRegister" %>

using System;
using System.Web;

public class HRegister : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string email = context.Request.Form["email"];
        string pwd = context.Request.Form["pwd"]; 
        BLL.BLUserInfo bl = new BLL.BLUserInfo();
        BLL.Response res = bl.RegisterUser(email, pwd);
        if (res.Code == BLL.ResCode.SUCCESS)
        {
            string voip = bl.GenerateVoipInfo(email);
            sendEmail(email,voip);
            res = bl.QueryUser(email, pwd);
        }
        context.Response.Write(res.ToJson());
    }

    private void sendEmail(string email ,string voip)
    {
        string htmlContent = "http://www.doctorsclub.cn/handlers/HVerify.ashx?voip=" + voip;
        EmailUtil.Email e = new EmailUtil.Email("18701416082@163.com", "sfgnuiqny!@#45");
        e.AddTo(email);
        e.SetSubject("thank you for register!!!");
        e.AddHtmlContent(htmlContent);
        e.Send();
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}