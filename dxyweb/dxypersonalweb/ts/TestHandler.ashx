<%@ WebHandler Language="C#" Class="TestHandler" %>

using System;
using System.Web;

public class TestHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain"; 
        string obj = context.Request.Form["t"];
        string str = MM.Decrypt(obj);
        //byte[] b=(byte[])obj;
        //string str = MM.Decrypt(b);
        context.Response.Write(str);        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}