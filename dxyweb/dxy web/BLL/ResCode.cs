using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ResCode
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        public static int SUCCESS = 0;
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        public static int ERROREMAILPWD = 1;
        public static string STRERROREMAILPWD = "用户名或密码错误!";
        /// <summary>
        /// 用户不存在
        /// </summary>
        public static int NONEUSER = 2;
        public static string STRNONEUSER = "用户不存在!";
        /// <summary>
        /// 用户已存在
        /// </summary>
        public static int USERALREADYEXISTS = 3;
        public static string STRUSERALREADYEXISTS = "用户已存在!";
    }
}
