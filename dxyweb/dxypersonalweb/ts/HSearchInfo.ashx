<%@ WebHandler Language="C#" Class="HSearchInfo" %>

using System;
using System.Web;
using System.Collections.Generic;

public class HSearchInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (!MMUtil.IsCanDeal(context))
            return;
        string type = context.Request.Form["type"];
        if (type != null && type.Length > 0)
        {
            TryByRegisterTime(type, context.Request.Form, context.Response);
            TryByIdentity(type, context.Request.Form, context.Response);
            Try(type, context.Request.Form, context.Response);
        }
    }

    private void TryByRegisterTime(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {
        if (!"by_register_time".Equals(type))
            return;
        string region = nvc["region"];
        string page_index = nvc["page_index"];
        string page_size = nvc["page_size"];
        Dictionary<string, string> dic = new Dictionary<string, string>();
        if (!StringUtil.IsEmpty(region))
        {
            dic.Add("region", region);
        }
        if (!StringUtil.IsEmpty(page_index))
            dic.Add("page_index", page_index);
        if (!StringUtil.IsEmpty(page_size))
            dic.Add("page_size", page_size);
        dic.Add("sortby", "distance:1");
        BDMapLib.EnLocalPOI ret = BDMapLib.POI.LocalPOI(dic);
        try
        {
            foreach (BDMapLib.ContentEntity ce in ret.Contents)
            {
                if (ce != null && !StringUtil.IsEmpty(ce.Uid))
                {
                    if (!StringUtil.IsEmpty(ce.Tags))
                    {
                        string tabw = "";
                        if ("student".Equals(ce.Tags))
                        {
                            tabw = "tab_ts_student_info";
                        }
                        else if ("teacher".Equals(ce.Tags))
                        {
                            tabw = "tab_ts_teacher_info";
                        }
                        ce.UInfo = SqlLib.DbUtil.GetModel<Model.ts.UserInfo>(string.Format("SELECT * from tab_ts_user_basic_info a LEFT JOIN {0} b on a.id=b.ubId where b.poiId='{1}'", tabw, ce.Uid));
                        
                    }
                }
            }
        }
        catch (Exception)
        {

        }

        BLL.Response res = new BLL.Response();
        res.Code = BLL.ResCode.SUCCESS;
        res.Data = ret;
        resp.Write(res.ToJson());
    }

    private void TryByIdentity(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {
        if (!"qq".Equals(type))
            return;

        string qqOpenId = nvc["qqOpenId"];
        string nickname = nvc["nickname"];
        string figureurl_qq_2 = nvc["figureurl_qq_2"];
        BLL.ts.BLUserInfo bl = new BLL.ts.BLUserInfo();
        BLL.Response res = bl.ExistsByQQOpenId(qqOpenId, nickname, figureurl_qq_2);
        resp.Write(res.ToJson());

    }

    private void Try(string type, System.Collections.Specialized.NameValueCollection nvc, HttpResponse resp)
    {
        if (!"wx".Equals(type))
            return;

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
