using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.3
    /// 日期：2012-07-05
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// 如何获取安全校验码和合作身份者ID
    /// 1.用您的签约支付宝账号登录支付宝网站(www.alipay.com)
    /// 2.点击“商家服务”(https://b.alipay.com/order/myOrder.htm)
    /// 3.点击“查询合作者身份(PID)”、“查询安全校验码(Key)”
    /// </summary>
    public class Config
    {
        #region 字段
        private static string partner = "";
        private static string private_key = "";
        private static string public_key = "";
        private static string input_charset = "";
        private static string sign_type = "";
        #endregion

        static Config()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //合作身份者ID，以2088开头由16位纯数字组成的字符串
            partner = "";

            //商户的私钥
            private_key = @"MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBALtbtG+ZM+oE5lAqNmEI7jt2Z9EMo4B3UrWO6ynxBmpOnCnNEfQf8ErhpYY6FW17PZ58Dpn3Fe58bVB+X0UFgfiiR22ag2fQVnbzUFa1GRCsiCrU95Q4RXX37WQfFcYW0EhqiMn+bCfYj13KPkdA0O9W36MTY3MjQi31NNlomLevAgMBAAECgYBb57w3EhvZK9YedNZ/+vWBza9XaK+7kMzNqvHIfSb8dts71hB8hD5HPTEJCuz/63hqichP1li3x+mHlrX9EZqTGDCJNrNmnJUvCeAzXbRNKCf0prfmkve1ddnlU54JOnGkWGilBX5uhRXZ64OYpURXDeS/JsnVVxC0VNTkUlJ94QJBAPT/p0Tst9qEkjOk2oBz+HMvIE+va0OforSmARaQKyHleYIo+ClveWtJeo0Hj9TT3Szu4xxYMtnhA+ICfE6fK9sCQQDDxXRJs+LD8LK3M/7yG3ffvMPyFhPIWraVPa2m7ivBUyrRdt6eppVc1YTxvh730GELjfdkczedlO4FPErjUzW9AkB5eSCITg5CbCTJMl2b/uQayCzvFXzLhKT5iK1VcJnSLqL2ZDXW5YyAI2h98FfiIEGze6ZjcV+VI7n3H2Be4xCtAkAQZYxM0/0tLg6522gB/Rz4J0Y+E21KvZZHP6g4sAAILCAM9SjGHuupn9SHrsXHObO3FQfgaOoCj8Ozuo4HJiP9AkEAsDT+xayJxesduNAtXDrT/6uoDADcpJC3tZVRa6wscYg9s0Y3VVCD5c7P1Hts0UmrZTJNHiCXb6gH5Gov27Qufg==";

            //支付宝的公钥，无需修改该值
            public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";

            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 目前支持 gbk 或 utf-8
            input_charset = "utf-8";

            //签名方式，选择项：RSA、DSA、MD5
            sign_type = "RSA";
        }

        #region 属性
        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        /// <summary>
        /// 获取或设置商户的私钥
        /// </summary>
        public static string Private_key
        {
            get { return private_key; }
            set { private_key = value; }
        }

        /// <summary>
        /// 获取或设置支付宝的公钥
        /// </summary>
        public static string Public_key
        {
            get { return public_key; }
            set { public_key = value; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public static string Input_charset
        {
            get { return input_charset; }
        }

        /// <summary>
        /// 获取签名方式
        /// </summary>
        public static string Sign_type
        {
            get { return sign_type; }
        }
        #endregion
    }
}