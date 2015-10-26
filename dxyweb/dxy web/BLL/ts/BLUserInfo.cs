using DAL.ts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ts
{
    public class BLUserInfo
    {
        public Response RegisterUser(string phone, string pwd)
        {
            Response res = new Response();
            DaoUserInfo dao = new DaoUserInfo();
            if (dao.ExistsByPhone(phone))
            {
                res.Code = ResCode.USERALREADYEXISTS;
                res.Msg = ResCode.STRUSERALREADYEXISTS;
            }
            else
            {
                if (dao.Insert(phone, pwd))
                {
                    res.Code = ResCode.SUCCESS;
                }
            }
            return res;
        }
    }
}
