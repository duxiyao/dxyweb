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
        return System.Text.RegularExpressions.Regex.IsMatch(phone, @"(^189\d{8}$)|(^13\d{9}$)|(^15\d{9}$)");
    }
}