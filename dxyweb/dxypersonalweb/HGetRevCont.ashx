<%@ WebHandler Language="C#" Class="HGetRevCont" %>

using System;
using System.Web;
using BLL;
using Model; 

public class HGetRevCont : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        string id = context.Request["artId"];
        System.Collections.Generic.List<Review> l = new BLReview().SelectByArticleId(id);        
        if (l != null)
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(l));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}