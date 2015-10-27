using CCPRestSDK;
using DAL.ts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ts
{
    public class BLUserInfo
    {
        public Response ExistsByQQOpenId(string qqOpenId,string nickname,string figureurl_qq_2)
        {
            Response res = new Response();
            DaoUserInfo dao = new DaoUserInfo();
            if (dao.ExistsByQQOpenId(qqOpenId))
            {
                res.Code = ResCode.SUCCESS;
                res.Data = dao.SelectByQQOpenId(qqOpenId);
            }
            else
            {
                if (dao.InsertQQOpenId(qqOpenId, nickname, figureurl_qq_2))
                {
                    res.Code = ResCode.SUCCESS;
                    res.Data = dao.SelectByQQOpenId(qqOpenId);
                } 
            }
            return res;
        }

        public Response ExistsByPhone(string phone, string pwd)
        {
            Response res = new Response();
            
            DaoUserInfo dao = new DaoUserInfo();
            if (dao.ExistsByPhone(phone, pwd))
            {
                res.Code = ResCode.SUCCESS;
                res.Data = dao.SelectByPhonePwd(phone, pwd);
            }
            else
            {
                res.Code = ResCode.ERRACCOUNTPWD;
                res.Msg = ResCode.STRERRACCOUNTPWD;
            }
            return res;
        }

        public Response RegisterUserByPhone(string phone, string pwd,string verifyCode)
        {
            Response res = new Response();
            DaoVerifyCode dao = new DaoVerifyCode();
            if (dao.Exists(phone, verifyCode))
            {
                DaoUserInfo daou = new DaoUserInfo();
                if (daou.Insert(phone, pwd))
                {                    
                    string voip = GenerateVoipInfo(phone);
                    if (voip != null && voip.Length > 0)
                    {
                        res.Code = ResCode.SUCCESS;
                    }
                    else
                    {
                        res.Code = ResCode.ERRGENERATEVOIP;
                        res.Msg = ResCode.STRERRGENERATEVOIP;
                    }
                }
                else
                {
                    res.Code = ResCode.ERRREGISTERWRITEDB;
                    res.Msg = ResCode.STRERRREGISTERWRITEDB;
                }
            }
            else
            {
                res.Code = ResCode.ERRVERIFYCODE;
                res.Msg = ResCode.STRERRVERIFYCODE;
            }
             
            return res;
        }

        public string GenerateVoipInfo(string phone)
        {
            CCPRestSDK.CCPRestSDK api = CCPRestSDK.VoipConfig.getInitSDK();

            try
            {
                if (api != null)
                {
                    Dictionary<string, object> retData = api.CreateSubAccount(phone);

                    List<string> list = new List<string>();
                    list.Add("dateCreated");
                    list.Add("subAccountSid");
                    list.Add("subToken");
                    list.Add("voipAccount");
                    list.Add("voipPwd");
                    KV kv = new KV(retData, list);
                    if (kv.IsVerify())
                    {
                        bool flag = new DaoUserInfo().Update(phone, kv.GetV("dateCreated"), kv.GetV("subAccountSid"), kv.GetV("subToken"), kv.GetV("voipAccount"), kv.GetV("voipPwd"));
                        if (flag)
                            return kv.GetV("voipAccount");
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
