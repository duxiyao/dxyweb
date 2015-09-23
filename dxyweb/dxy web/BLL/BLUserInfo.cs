using CCPRestSDK;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLUserInfo
    {

        public void Verify(string voipAccount)
        { 
            DaoUserInfo dao = new DaoUserInfo();
            dao.Verified(voipAccount);
        } 

        public Response RegisterUser(string email, string pwd)
        {
            Response res = new Response();
            DaoUserInfo dao = new DaoUserInfo();
            if (dao.Exists(email))
            {
                res.Code = ResCode.USERALREADYEXISTS;
                res.Msg = ResCode.STRUSERALREADYEXISTS;
            }
            else
            {
                if (dao.Insert(email, pwd))
                {
                    res.Code = ResCode.SUCCESS;
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>voipAccount</returns>
        public string GenerateVoipInfo(string email)
        {
            CCPRestSDK.CCPRestSDK api = CCPRestSDK.VoipConfig.getInitSDK();

            try
            {
                if (api != null)
                {
                    Dictionary<string, object> retData = api.CreateSubAccount(email);

                    List<string> list = new List<string>();
                    list.Add("dateCreated");
                    list.Add("subAccountSid");
                    list.Add("subToken");
                    list.Add("voipAccount");
                    list.Add("voipPwd");
                    KV kv = new KV(retData, list);
                    if (kv.IsVerify())
                    {
                        bool flag = new DaoUserInfo().Update(email, kv.GetV("dateCreated"), kv.GetV("subAccountSid"), kv.GetV("subToken"), kv.GetV("voipAccount"), kv.GetV("voipPwd"));
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

        public Response QueryUser(string email, string pwd)
        {
            Response res = new Response();
            DaoUserInfo dao = new DaoUserInfo();
            if (dao.Exists(email))
            {
                res.Code = ResCode.SUCCESS;
                res.Data = dao.SelectByEmailPwd(email, pwd);
                if (res.Data == null)
                {
                    res.Code = ResCode.ERROREMAILPWD;
                    res.Msg = ResCode.STRERROREMAILPWD;
                }
            }
            else
            {
                res.Code = ResCode.NONEUSER;
                res.Msg = ResCode.STRNONEUSER;
            }
            return res;
        }
    }
}
