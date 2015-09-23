<%@ WebHandler Language="C#" Class="HVerify" %>

using System;
using System.Web;

public class HVerify : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string voip = context.Request["voip"];
        if (voip != null && voip.Trim().Length > 0)
        {
            new BLL.BLUserInfo().Verify(voip);
            context.Response.Write("success");            
        }
        else
        { 
            context.Response.Write("fail");
        } 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}