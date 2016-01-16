using CCPRestSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CallUtil 的摘要说明
/// </summary>
public class CallUtil
{
    private string RESTADDRESS = "112.124.25.36";
    private string RESTPORT = "8883";
    private string ACCOUNTSID = "ddbd993f002c11e5b37eac853d9f52ec";
    private string ACCOUNTTOKEN = "12d504dfcf1ed0284b7de4ff7ce739e3";
    private string APPID = "f0fc99a44844ed3c01486cb614ba0004";
    public CallUtil()
    {
        
    }
    public string call(string from,string to,string other,string me)
    {

        CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();

        //ip格式如下，不带https://
        bool isInit = api.init(RESTADDRESS, RESTPORT);
        //api.setAccount(ACCOUNTSID, ACCOUNTTOKEN);
        api.setSubAccount(ACCOUNTSID, ACCOUNTTOKEN, "80000300592148", "eRuJZAO8");
        api.setAppId(APPID);
        Dictionary<string, object> retData = api.CallBack(from, to, other, me, "");
        List<string> list = new List<string>();
        list.Add("statusCode");
        list.Add("statusMsg");
        KV kv = new KV(retData, list);
        if (kv.IsVerify())
        {
            return kv.GetKvv();
        }
        return "error";
    }
}