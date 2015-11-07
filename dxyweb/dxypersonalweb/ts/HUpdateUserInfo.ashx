<%@ WebHandler Language="C#" Class="HUpdateUserInfo" %>

using System;
using System.Web;
using System.Collections.Generic;

public class HUpdateUserInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string id = context.Request.Form["id"];
        string type = context.Request.Form["intType"];
        int intType = -1;
        try
        {
            intType=Convert.ToInt16(type);
            if (intType < 0)
                return;
        }
        catch (Exception)
        {
            return;  
        } 
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
        if(dic.ContainsKey("intType"))
            dic.Remove("intType");
        BLL.Response res = new BLL.Response();
        DAL.ts.DaoUserInfo dao = new DAL.ts.DaoUserInfo();
        if (dao.UpdateUserInfoKV(intType,id, dic))
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