using System;
using System.Collections.Generic;
using System.Text;

namespace CCPRestSDK
{
    public class VoipConfig
    {
        //public static string RESTADDRESS = "sandboxapp.cloopen.com";
        public static string RESTADDRESS = "app.cloopen.com";
        public static string RESTPORT = "8883";
        public static string ACCOUNTSID = "8a48b5514d32a2a8014d89972a303d91";
        public static string ACCOUNTTOKEN = "97b599886b6841c18c772040c960ea1e";
        public static string APPID = "aaf98f894d7439d8014d8998e0760dfe";

        public static CCPRestSDK getInitSDK()
        {
            CCPRestSDK api = new CCPRestSDK();
            //ip格式如下，不带https://
            bool isInit = api.init(RESTADDRESS, RESTPORT);
            api.setAccount(ACCOUNTSID, ACCOUNTTOKEN);
            api.setAppId(APPID);
            if (isInit)
                return api;
            else
                return null;
        }
    }
}
