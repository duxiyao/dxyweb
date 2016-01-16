<%@ WebHandler Language="C#" Class="HCall" %>

using System;
using System.Web;

public class HCall : IHttpHandler
{


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string ret = "error";
        try
        {

            string from = context.Request["from"];
            string to = context.Request["to"];
            string other = context.Request["other"];
            string me = context.Request["me"];
            if(me==null||me.Length==0)
            {
                other = from;
                me = to;
            }
            CallUtil cu = new CallUtil();
            ret = cu.call(from, to, other, me);
        }
        catch (Exception)
        {
        }
        context.Response.Write(ret);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}