<%@ WebHandler Language="C#" Class="TestHandler" %>

using System;
using System.Web;

public class TestHandler : IHttpHandler
{
    private string serverRoot = "/ts/imgs/heads/";

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            context.Response.ContentType = "text/plain";
            HttpFileCollection fileList = context.Request.Files;// System.Web.HttpContext.Current.Request.Files;
            string id = context.Request.Form["id"];
            if (id == null || id.Trim().Length == 0)
                return;
            System.Web.HttpPostedFile postedFile = fileList[0];
            string fileName = postedFile.FileName;
            string imagetype = fileName.Substring(fileName.LastIndexOf("."));
            imagetype = imagetype.ToLower();
            if (imagetype == ".jpg" || imagetype == ".bmp" || imagetype == ".gif" || imagetype == ".png" || imagetype == ".jpeg")
            {
                string root = context.Server.MapPath("~" + serverRoot);  //图片保存路径
                string filePathNew = root + DateTime.Now.ToString("yyyyMMddhhmmss") + imagetype;
                //if (!System.IO.File.Exists(filePathNew))
                //{
                //    System.IO.File.Create(filePathNew);
                //}
                postedFile.SaveAs(filePathNew); 

                DAL.ts.DaoUserInfo dao = new DAL.ts.DaoUserInfo();
                string url = "http://" + System.Web.HttpContext.Current.Request.Url.Host + serverRoot + filePathNew;
                BLL.Response res = new BLL.Response();
                if (dao.UpdateUserInfoKV(id, "photoUrl",url))
                {
                    res.Code = BLL.ResCode.SUCCESS;
                    res.Data = url;
                }
                context.Response.Write(res.ToJson());
            } 
        }
        catch (Exception)
        {

        }
    }
         
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}