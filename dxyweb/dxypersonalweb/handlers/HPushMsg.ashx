<%@ WebHandler Language="C#" Class="HPushMsg" %>

using System;
using System.Web;
using System.Collections.Generic;
using CCPRestSDK;

public class HPushMsg : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        context.Response.ContentType = "text/plain";
        string ret = "";

        CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
        //ip格式如下，不带https://
        bool isInit = api.init("sandboxapp.cloopen.com", "8883");
        api.setAccount("8a48b5514d32a2a8014d89972a303d91", "97b599886b6841c18c772040c960ea1e");
        api.setAppId("aaf98f894d7439d8014d8998e0760dfe");

        try
        {
            if (isInit)
            {
                Dictionary<string, object> retData = api.PushMsg("86920000000023", "hello client");

                List<string> list = new List<string>();
                list.Add("statusCode");
                list.Add("statusMsg"); 
                KV kv = new KV(retData, list);
                if (kv.IsVerify())
                {
                    ret = kv.GetKvv();
                }
                else
                {
                   // ret = getDictionaryData(retData);
                }
            }
            else
            {
                ret = "初始化失败";
            }
        }
        catch (Exception exc)
        {
            ret = exc.Message;
        }
        finally
        {
            context.Response.Write(ret);
        } 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}