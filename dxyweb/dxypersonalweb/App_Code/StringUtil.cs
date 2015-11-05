using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// StringUtil 的摘要说明
/// </summary>
public class StringUtil
{
    public static bool IsEmpty(object obj)
    {
        try
        {
            if (obj == null)
                return true;
            if (obj is String)
            {
                if (obj.ToString().Length == 0)
                    return true;
                if (obj.ToString().Trim().Length == 0)
                    return true;
            }
            return false;
        }
        catch (Exception)
        {

        }
        return true;
    }
}