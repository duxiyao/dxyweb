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
        /// <summary>
        /// 非法用户
        /// </summary>
        public static int ILLEGALUSER = 4;
        public static string STRILLEGALUSER = "非法用户!";
        /// <summary>
        /// 手机号不正确
        /// </summary>
        public static int ILLEGALPHONENUM = 5;
        public static string STRILLEGALPHONENUM = "手机号不正确!";
        /// <summary>
        /// 同一手机号每天只能请求两次注册验证码
        /// </summary>
        public static int LIMITPHONEREGISTER = 6;
        public static string STRLIMITPHONEREGISTER = "同一手机号每天只能请求两次注册验证码!";
        /// <summary>
        /// 生成验证码错误
        /// </summary>
        public static int ERRGENERATEVERIFYCODE = 7;
        public static string STRERRGENERATEVERIFYCODE = "生成验证码错误!";
        /// <summary>
        /// 云通讯平台生成验证码错误
        /// </summary>
        public static int ERRYUNTONGXUNGENERATECODE = 8;
        public static string STRERRYUNTONGXUNGENERATECODE = "云通讯平台生成验证码错误!";
        /// <summary>
        /// 注册验证码不正确
        /// </summary>
        public static int ERRVERIFYCODE = 9;
        public static string STRERRVERIFYCODE = "注册验证码不正确!";
        /// <summary>
        /// 注册写入数据库数据错误
        /// </summary>
        public static int ERRREGISTERWRITEDB = 10;
        public static string STRERRREGISTERWRITEDB = "注册写入数据库数据错误!";
        /// <summary>
        /// 用户名密码错误
        /// </summary>
        public static int ERRACCOUNTPWD= 11;
        public static string STRERRACCOUNTPWD = "用户名密码错误!";
        /// <summary>
        /// voip生成错误
        /// </summary>
        public static int ERRGENERATEVOIP = 11;
        public static string STRERRGENERATEVOIP = "voip生成错误!";
    }
}
