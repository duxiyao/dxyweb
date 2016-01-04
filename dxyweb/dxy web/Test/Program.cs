using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using SqlLib;
using BDMapLib;

namespace Test
{
    class Program
    {
        static void testSqllib(){
            //UserInf userss = new UserInf();
            //userss.U_UserID = "aw12311";
            //userss.U_Psw = "123";
            //userss.U_UserName = "aw";
            //userss.U_City = "武汉";
            //userss.U_Popedom = 1;
            //userss.U_Sex = 1;
            //userss.U_BirthTime = 19900114;
            //userss.U_AddDataTime = DateTime.Now;

            //DateIsTableAttribute<UserInf> t = new DateIsTableAttribute<UserInf>();

            //Response.Write(" </br>" + t.insertDate(userss));  
            //new SQLManager().GetList<UserInf>();

            //SqlLib.PE_Files pef = new SqlLib.PE_Files();
            //new SqlLib.SQLManager().Insert(pef);
            //SqlLib.Entity.IsHide(pef.GetType().GetProperties()[0]);

            //User u = new User();
            //u.Id = 1;
            //u.Name = "dxy";
            //u.Age = 25;
            //string sql = SqlBuilder.BuildUpdate(u,"");

            //Tmp tmp = new Tmp();
            //tmp.Id = 23;
            //tmp.Name = "test";
            //tmp.Num = "22";
            //bool f = DbUtil.DeleteByWhere<Tmp>("num='&&'");

            //tmp = DbUtil.GetModelByWhere<Tmp>("id=23");

            //List<Tmp> tlist = DbUtil.GetListByWhere<Tmp>("num='1'");

            Console.Read();
             
        }


        static void testBDmap(){

            string url = "http://api.map.baidu.com/geodata/v3/geotable/list";
            string p = "ak=FF220617922875eb62a6d9db2c7dd479";
            //string ret = HttpReqp.HttpGet(url, p);
            string ret = Http.c(url).Add("ak", "FF220617922875eb62a6d9db2c7dd479").ExeGet();
         

            //string url1 = "http://api.map.baidu.com/geodata/v3/geotable/detail";
            //ret = Http.c(url1).Add("ak", "FF220617922875eb62a6d9db2c7dd479").Add("id", "125348").ExeGet();
            Console.WriteLine(ret);
            
            //string ret1 = Uri.UnescapeDataString(ret);
            //Console.WriteLine(ret1);
            Console.Read();
        }

        static void testBDmapDel()
        {
            string url = "http://api.map.baidu.com/geodata/v3/geotable/delete";
            string ret = Http.c(url).Add("ak", "FF220617922875eb62a6d9db2c7dd479").Add("id", "125348").ExePost();
            Console.WriteLine(ret);
        }

        static void testmap()
        {
            //string ret = Col.CreateStrCol("身份", "identity", "50");
            //string ret1 = Col.CreateDoubleCol("价格", "price");
            //string ret2 = Col.CreateIntCol("好评", "praise");

            //string ret0 = Col.QueryList(Conf.GEOID);

            //string ret = Col.DelColById("188577", Conf.GEOID);
            //string ret1 = Col.DelColById("188578", Conf.GEOID);
            //string ret2 = Col.DelColById("188579", Conf.GEOID);

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("title", "first");
            //dic.Add("address", "软件园东站");
            //dic.Add("tags", "专业");
            //dic.Add("latitude", "39.924475");
            //dic.Add("longitude", "116.403689");

            //dic.Add("identity", "老师");
            //dic.Add("price", "20");
            //dic.Add("praise", "5");
            //POI.CreatePOI(dic);

            //dic = new Dictionary<string, string>();
            //dic.Add("title", "two");
            //dic.Add("address", "软件园东站2");
            //dic.Add("tags", "专业2");
            //dic.Add("latitude", "39.924475");
            //dic.Add("longitude", "116.403689");

            //dic.Add("identity", "学生");
            //dic.Add("price", "10");
            //dic.Add("praise", "4");
            //POI.CreatePOI(dic);

            //dic = new Dictionary<string, string>();
            //dic.Add("title", "three");
            //dic.Add("address", "软件园东站3");
            //dic.Add("tags", "专业3");
            //dic.Add("latitude", "39.924475");
            //dic.Add("longitude", "116.403689");

            //dic.Add("identity", "老师");
            //dic.Add("price", "15");
            //dic.Add("praise", "2");
            //POI.CreatePOI(dic);

            //dic = new Dictionary<string, string>();
            //dic.Add("title", "four");
            //dic.Add("address", "软件园东站4");
            //dic.Add("tags", "专业4");
            //dic.Add("latitude", "39.924475");
            //dic.Add("longitude", "116.403689");

            //dic.Add("identity", "老师");
            //dic.Add("price", "13");
            //dic.Add("praise", "1");
            //POI.CreatePOI(dic);

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("title", "three");
            //dic.Add("tags", "专业");
            //dic.Add("district", "东城区");
            //POI.QueryPOI(dic);

            //dic.Add("location", "116.403689,39.924475");
            //POI.NearbyPOI(dic);

            Console.Read();
        }

        public static string RESTADDRESS = "112.124.25.36";
        public static string RESTPORT = "8883";
        public static string ACCOUNTSID = "ddbd993f002c11e5b37eac853d9f52ec";
        public static string ACCOUNTTOKEN = "12d504dfcf1ed0284b7de4ff7ce739e3";
        public static string APPID = "f0fc99a44844ed3c01486cb614ba0004";

        static void testcallback()
        {

            CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();

            //ip格式如下，不带https://
            bool isInit = api.init(RESTADDRESS, RESTPORT);
            //api.setAccount(ACCOUNTSID, ACCOUNTTOKEN);
            api.setSubAccount(ACCOUNTSID, ACCOUNTTOKEN, "80000300592148", "eRuJZAO8");
            api.setAppId(APPID);
            Dictionary<string, object>  tmp=api.CallBack("18701416082", "15811488360", "呵呵", "哈哈", "");
            Console.Read();
        }

        static void Main(string[] args)
        {
            testcallback();

            //Model.ts.BStudentInfo info = new Model.ts.BStudentInfo();
            //info.PoiId = "1554";
            //SqlLib.DbUtil.UpdateByWhere(info, "ubid='" + "17" + "'");
                
            //testmap();
            //testBDmap();
            //testBDmapDel();
            //testSqllib();
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
            
            //DateTime dt = DateTime.Parse("2015-11-04 00:45:46");
            //string s = dt.ToString();

            //int i = 10;
            //string s = Convert.ToString(i, 2);
            //Console.WriteLine(s);

            //int a = Convert.ToInt32(s, 2);
            //Console.WriteLine(a);

            //string content = "\u6210\u529f";
            //string result = Uri.UnescapeDataString(content);
            //Console.WriteLine(result);//操作成功

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
