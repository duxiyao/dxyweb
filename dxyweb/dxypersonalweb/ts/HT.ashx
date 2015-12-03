<%@ WebHandler Language="C#" Class="HT" %>

using System;
using System.Web;
using Model.ts;
using SqlLib;

public class HT : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //Model.ts.BStudentInfo info = new Model.ts.BStudentInfo();
        
        //info.PoiId = "11554";
        //if (SqlLib.DbUtil.UpdateByWhere(info, "ubid=17"))

        //context.Response.Write(info.DataBirthday.ToString());
        context.Response.Write("hehe");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}