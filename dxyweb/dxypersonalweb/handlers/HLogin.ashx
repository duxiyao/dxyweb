<%@ WebHandler Language="C#" Class="HLogin" %>

using System;
using System.Web;

public class HLogin : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string email = context.Request.Form["email"];
        string pwd = context.Request.Form["pwd"]; 
        context.Response.Write(new BLL.BLUserInfo().QueryUser(email, pwd).ToJson()); 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}