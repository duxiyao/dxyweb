<%@ WebHandler Language="C#" Class="HUpdateUserInfo" %>

using System;
using System.Web;
using System.Collections.Generic;

public class HUpdateUserInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string id = context.Request.Form["id"];
        if (StringUtil.IsEmpty(id))
        { 
            return;
        }
        Dictionary<string, string> dic = new Dictionary<string, string>();
        string[] keys = context.Request.Form.AllKeys;
        foreach(string k in keys){
            dic.Add(k, context.Request.Form[k]);
        }
        if (dic.ContainsKey("id"))
            dic.Remove("id");
        BLL.Response res = new BLL.Response();
        DAL.ts.DaoUserInfo dao = new DAL.ts.DaoUserInfo();
        if (dao.UpdateUserInfoKV(id, dic))
        {
            res.Code = BLL.ResCode.SUCCESS;
        }
        context.Response.Write(res.ToJson());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}