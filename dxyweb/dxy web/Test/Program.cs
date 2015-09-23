using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

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

            string htmlContent = "http://www.doctorsclub.cn/HVerify.ashx?voip=";
            EmailUtil.Email e = new EmailUtil.Email("18701416082@163.com", "sfgnuiqny!@#45");
            e.AddTo("1589878326@qq.com");
            e.SetSubject("thank you for register!!!");
            e.AddHtmlContent(htmlContent);
            e.SendDone += e_SendDone;
            e.Send();
            Console.ReadKey();
        }

        static void e_SendDone(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.Write("e_SendDone");
        }
    }
}
