using DAL.ts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ts
{
    public class BLUserInfo
    {
        public Response RegisterUserByPhone(string phone, string pwd,string verifyCode)
        {
            Response res = new Response();
            DaoVerifyCode dao = new DaoVerifyCode();
            if (dao.Exists(phone, verifyCode))
            {
                DaoUserInfo daou = new DaoUserInfo();
                if (daou.Insert(phone, pwd))
                {
                    res.Code = ResCode.SUCCESS;
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
    }
}
