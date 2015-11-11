using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

public class Http
{
    private Dictionary<string, string> mDic = new Dictionary<string, string>();
    private string mUrl;

    private Http(string url)
    {
        mUrl = url;
    }

    public Http Add(string k, string v)
    {
        mDic.Add(k, v);
        return this;
    }

    public Http SetKv(Dictionary<string, string> dic)
    {
        foreach (string k in dic.Keys)
        {
            mDic.Add(k, dic[k]);
        }
        return this;
    }

    public string ExeGet()
    {
        string p = "";
        foreach (string k in mDic.Keys)
        {
            p += k + "=" + mDic[k] + "&";
        }
        if (p != null && p.Length > 0)
            return HttpGet(mUrl, p.Substring(0, p.Length - 1));
        else
            return HttpGet(mUrl, "");
    }

    public string ExePost()
    {
        string p = "";
        foreach (string k in mDic.Keys)
        {
            p += k + "=" + mDic[k] + "&";
        }
        if (p != null && p.Length > 0)
            return HttpPost(mUrl, p.Substring(0, p.Length - 1));
        else
            return HttpPost(mUrl, "");
    }

    public static Http c(string url)
    {
        Http hp = new Http(url);
        return hp;
    }

    public CookieContainer mCookie = new CookieContainer();

    public string HttpPost(string Url, string postDataStr)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
        request.CookieContainer = mCookie;
        Stream myRequestStream = request.GetRequestStream();
        StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
        myStreamWriter.Write(postDataStr);
        myStreamWriter.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        response.Cookies = mCookie.GetCookies(response.ResponseUri);
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        return System.Web.HttpUtility.UrlDecode(retString, System.Text.Encoding.GetEncoding("utf-8"));
    }

    public string HttpGet(string Url, string postDataStr)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
        request.Method = "GET";
        request.ContentType = "text/html;charset=UTF-8";

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        return System.Web.HttpUtility.UrlDecode(retString, System.Text.Encoding.GetEncoding("utf-8"));
    }
}
