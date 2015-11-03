<%@ WebHandler Language="C#" Class="HGetVerifyCode" %>

using System;
using System.Web;

public class HGetVerifyCode : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (!MMUtil.IsCanDeal(context))
            return;
        BLL.Response res = null;
        string phone = context.Request.Form["phone"];
        string pwd = context.Request.Form["pwd"];
        string imei = context.Request.Form["imei"];
        string time = context.Request.Form["time"];
        string aesCode = context.Request.Form["aesCode"];

        if (RegexUtil.IsPhone(phone))
        {
            if (MMUtil.IsAesCodeRight(time, imei, aesCode))
            {
                res = new BLL.Response();
                BLL.ts.BLUserInfo bl = new BLL.ts.BLUserInfo();
                DAL.ts.DaoUserInfo dao = new DAL.ts.DaoUserInfo();
                if (dao.ExistsByPhone(phone))
                {
                    res.Code = BLL.ResCode.USERALREADYEXISTS;
                    res.Msg = BLL.ResCode.STRUSERALREADYEXISTS;
                }
                else
                {
                    if (dao.IsCanSendCode(phone, aesCode))
                    {
                        DAL.ts.DaoVerifyCode daoCode = new DAL.ts.DaoVerifyCode();
                        string verifyCode = daoCode.Insert(phone, imei, aesCode);
                        if (verifyCode != null && verifyCode.Length > 0)
                        {
                            CCPRestSDK.CCPRestSDK sdk = CCPRestSDK.VoipConfig.getInitSDK();
                            System.Collections.Generic.Dictionary<string, object> dic = sdk.VoiceVerify(phone, verifyCode, "18701416082", "3", "");
                            try
                            {
                                if (dic["statusCode"] == "000000")
                                {
                                    res.Code = BLL.ResCode.SUCCESS;
                                    //res.Data = verifyCode;
                                }
                                else
                                {
                                    res.Code = BLL.ResCode.ERRYUNTONGXUNGENERATECODE;
                                    res.Msg = BLL.ResCode.STRERRYUNTONGXUNGENERATECODE + " " + dic["statusMsg"];
                                }
                            }
                            catch (Exception e)
                            {
                                res.Code = BLL.ResCode.ERRYUNTONGXUNGENERATECODE;
                                res.Msg = BLL.ResCode.STRERRYUNTONGXUNGENERATECODE + " " + e.ToString();
                            }
                        }
                        else
                        {
                            res.Code = BLL.ResCode.ERRGENERATEVERIFYCODE;
                            res.Msg = BLL.ResCode.STRERRGENERATEVERIFYCODE;
                        }
                    }
                    else
                    {
                        res.Code = BLL.ResCode.LIMITPHONEREGISTER;
                        res.Msg = BLL.ResCode.STRLIMITPHONEREGISTER;
                    }
                }
            }
            else
            {
                res = new BLL.Response();
                res.Code = BLL.ResCode.ILLEGALUSER;
                res.Msg = BLL.ResCode.STRILLEGALUSER;
            }
        }
        else
        {
            res = new BLL.Response();
            res.Code = BLL.ResCode.ILLEGALPHONENUM;
            res.Msg = BLL.ResCode.STRILLEGALPHONENUM;
        }
        context.Response.Write(res.ToJson());
    } 

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}