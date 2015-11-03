using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// RegexUtil 的摘要说明
/// </summary>
public class RegexUtil
{
    public static bool IsEmail(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }

    public static bool IsPhone(string phone)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^1(3|4|5|7|8){1}\d{9}");
    }
}