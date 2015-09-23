<%@ WebHandler Language="C#" Class="HDealReview" %>

using System;
using System.Web;
using BLL;

public class HDealReview : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        try
        {
            int lMsgId=-1;
            string leaveMsgId = "";
            string articleId = context.Request.Form["artId"];
            DateTime reviewDate = DateTime.Now;
            try
            {
                leaveMsgId = context.Session["leaveMsgId"].ToString();
                lMsgId=int.Parse(leaveMsgId);
            }
            catch { }
            string fileName = context.Request.Form["fileName"];
            string reviewContent = context.Request.Form["revContent"];
            string reviewFileName = @"\" + reviewDate.ToString("yyyy-MM-dd.HH-mm-ss");
            string dirPath = BLL.BLArticle.artPath + fileName + reviewFileName;
            System.IO.File.WriteAllBytes(dirPath , System.Text.Encoding.Default.GetBytes(reviewContent));


            BLL.BLReview bll = new BLReview();
            if (!bll.Insert(int.Parse(articleId), lMsgId, reviewDate, dirPath))
                context.Response.Write("2");
            
            context.Response.Write("1");
        }
        catch
        {
           
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}