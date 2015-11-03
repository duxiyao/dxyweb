using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Regex reg = new Regex(@"url\((['""]?)(.+[^'""])\1\)");  //注意里面的引号 要用双引号表示，而不是用反斜杠
            ////Console.WriteLine(reg.Match(@"{background-image:url(//ssl.gstatic.com/ui/v1/menu/checkmark.png);backgro")); 
            ////输出 url(//ssl.gstatic.com/ui/v1/menu/checkmark.png)

            //string str = @"statusCode=000000;statusMsg=成功;data={SubAccount={dateCreated=2015-05-27 11:04:27;subAccountSid=15c150d8041d11e58ad3ac853d9f54f2;subToken=73eb324e88e46c67ae874c37f9eec55a;voipAccount=86920000000003;voipPwd=HMFPZjoS;};};";
            //string sr = @"statusCode\=\d*\;";
            //sr = @"statusMsg\=.*;";
            //Regex reg1 = new Regex(sr);
            ////Console.WriteLine(reg1.Match(str));

            //StringReader sssr=new StringReader(str);
            //JsonReader reader = new JsonTextReader(sssr);
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);
            //}

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("a", "b");
            //Console.Write(dic.Count);

            //string htmlContent = "http://www.doctorsclub.cn/HVerify.ashx?voip=";
            //EmailUtil.Email e = new EmailUtil.Email("18701416082@163.com", "sfgnuiqny!@#45");
            //e.AddTo("1589878326@qq.com");
            //e.SetSubject("thank you for register!!!");
            //e.AddHtmlContent(htmlContent);
            //e.SendDone += e_SendDone;
            //e.Send();
            //Console.ReadKey();

            //string hex = "E906F675D7606B89CEBC5DE06F4CEB9D";
            //byte[] b = strToToHexByte(hex);

            //Console.WriteLine(AesDecrypt("e8GytNCe8Or6WNlcmpTePw==", "123456781234567a"));
            //CCPRestSDK.CCPRestSDK sdk = CCPRestSDK.VoipConfig.getInitSDK();
            //Dictionary<string, object> dic = sdk.VoiceVerify("18701416082", "ilovezjy", "18701416082", "3", "");
            //string s = GenerateRandomNumber(4).ToLower();

            //string s = AesEncrypt("1870141608215455", "sfgnuiqnyzjy1314");
            //string s1 = AesDecrypt(s, "sfgnuiqnyzjy1314");
            //string str = "";


            //string data = Encrypt("test");
            //Console.WriteLine(data);
            //Console.WriteLine(Decrypt(data));
            //Console.Write(IsPhone("15701282815"));
            //Console.Write(IsPhone("18701416082")); 
            DateTime dt = DateTime.Parse("2015-11-04 00:45:46");
            string s = dt.ToString();
            Console.Read();
        }
        public static bool IsPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^1(3|4|5|7|8){1}\d{9}");
        }
        private static char[] constant =   
      {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
      };
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        static void e_SendDone(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.Write("e_SendDone");
        }


        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string toDecrypt)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("123");
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string Decrypt(byte[] toEncryptArray)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("123456781234567a");

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string AesEncrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = System.Security.Cryptography.CipherMode.ECB,
                Padding = System.Security.Cryptography.PaddingMode.PKCS7
            };

            System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        ///  AES 解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(str);

            System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = System.Security.Cryptography.CipherMode.ECB,
                Padding = System.Security.Cryptography.PaddingMode.PKCS7
            };

            System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

    }
}
