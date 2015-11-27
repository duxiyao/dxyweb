<%@ WebHandler Language="C#" Class="HGetBasicInfo" %>

using System;
using System.Web;

public class HGetBasicInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (!MMUtil.IsCanDeal(context))
            return;

        string id = context.Request.Form["id"];
        if (id != null && id.Trim().Length > 0)
        {
            BLL.Response res = new BLL.Response();
            DAL.ts.DaoUserInfo dao = new DAL.ts.DaoUserInfo();
            Model.ts.UserInfo ui = dao.SelectById(id);
            if (ui.Id != -1)
            {
                res.Code = BLL.ResCode.SUCCESS;
                res.Data = ui;
            }
            else
            {
                res.Code = BLL.ResCode.NONEUSER;
                res.Msg = BLL.ResCode.STRNONEUSER;
            }
            context.Response.Write(res.ToJson());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}