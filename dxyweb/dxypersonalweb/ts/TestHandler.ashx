<%@ WebHandler Language="C#" Class="TestHandler" %>

using System;
using System.Web;

public class TestHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        try
        {

            context.Response.ContentType = "text/plain";
            string url = "http://api.map.baidu.com/geodata/v3/geotable/list";
            string ret = Http.c(url).Add("ak", "FF220617922875eb62a6d9db2c7dd479").ExeGet();
            
            object req = context.Request;
            HttpFileCollection fileList = context.Request.Files;// System.Web.HttpContext.Current.Request.Files;
            System.Web.HttpPostedFile postedFile = fileList[0];
            string fileName = postedFile.FileName;
            string Imagetype = fileName.Substring(fileName.LastIndexOf("."));
            Imagetype = Imagetype.ToLower();
            if (Imagetype == ".jpg" || Imagetype == ".bmp" || Imagetype == ".gif" || Imagetype == ".png" || Imagetype == ".jpeg")
            {
                string root = context.Server.MapPath("~/ts/imgs/heads/");  //图片保存路径
                string filePathNew = root + DateTime.Now.ToString("yyyyMMddhhmmss") + Imagetype;
                //if (!System.IO.File.Exists(filePathNew))
                //{
                //    System.IO.File.Create(filePathNew);
                //}
                postedFile.SaveAs(filePathNew);
            }
            //string obj = context.Request.Form["t"];
            //string str = MM.Decrypt(obj);
            //byte[] b=(byte[])obj;
            //string str = MM.Decrypt(b);
            //context.Response.Write(str);
        }
        catch (Exception)
        {

        }

        string strss = "";
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}