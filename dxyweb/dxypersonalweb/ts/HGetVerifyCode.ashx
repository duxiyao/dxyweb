<%@ WebHandler Language="C#" Class="HGetVerifyCode" %>

using System;
using System.Web;

public class HGetVerifyCode : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        BLL.Response res = null;
        string phone = context.Request.Form["phone"];
        string pwd = context.Request.Form["pwd"];
        string imei = context.Request.Form["imei"];
        string time = context.Request.Form["time"];
        string aesCode = context.Request.Form["aesCode"];

        if (RegexUtil.IsPhone(phone))
        {
            if (IsAesCodeRight(time, aesCode))
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
                    if (dao.IsCanSendCode(phone,aesCode))
                    {
                        DAL.ts.DaoVerifyCode daoCode = new DAL.ts.DaoVerifyCode();
                        string verifyCode=daoCode.Insert(phone, imei, aesCode);
                        if (verifyCode != null && verifyCode.Length > 0)
                        {
                            res.Code = BLL.ResCode.SUCCESS;
                            res.Data = verifyCode;
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

    private bool IsAesCodeRight(string time, string aesCode)
    {
        throw new NotImplementedException();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}