using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MMUtil 的摘要说明
/// </summary>
public class MMUtil
{
    public static bool IsCanDeal(HttpContext context)
    {
        try
        {
            string imei = context.Request.Form["imei"];
            string time = context.Request.Form["time"];
            string aesCode = context.Request.Form["aesCode"];
            return MMUtil.IsAesCodeRight(time, imei, aesCode);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool IsAesCodeRight(string time, string imei, string aesCode)
    {
        try
        {
            return (aesCode.Equals(MM.AesDecrypt(imei + time)));
        }
        catch (Exception)
        {
            return false;
        }
    }
}