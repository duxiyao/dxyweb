using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;
using System.Collections.Specialized;

namespace EmailUtil
{
    public class Email
    {
        private string adr, pwd;
        private MailMessage mailMessage;
        private List<string> toEmails;
        private StringBuilder sbHtmlContent;
        private NameValueCollection nvcImgIdFilePath;
        public Email(string adr, string pwd) 
        {
            if (IsNullOrEmp(adr) || IsNullOrEmp(pwd))
                throw new Exception("发送者的邮箱和邮箱密码不能为空！");
            this.adr = adr;
            this.pwd = pwd;
            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(adr);
            mailMessage.Priority = MailPriority.High; //优先级
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mailMessage.Subject = "From Dxy Code";
            toEmails = new List<string>();
            sbHtmlContent = new StringBuilder();
            nvcImgIdFilePath = new NameValueCollection();
        }

        public void AddTo(string emailAddress)
        {
            if (IsEmail(emailAddress))
                toEmails.Add(emailAddress);
            else
                throw new Exception(emailAddress + "不是正确的email格式");
        }

        public void SetSubject(string subject)
        {
            mailMessage.Subject = subject;
        }

        public void AddHtmlContent(string html)
        {
            sbHtmlContent.Append(html);
        }

        public void AddImgIdFile(string imgId, string filePath)
        {
            nvcImgIdFilePath.Add(imgId, filePath);
        }

        private void AddHtmlContent()
        {
            AlternateView htmlBody = AlternateView.CreateAlternateViewFromString(sbHtmlContent.ToString(), null, "text/html");
            foreach(string imgId in nvcImgIdFilePath.AllKeys)
            {
                LinkedResource lrImage = new LinkedResource(nvcImgIdFilePath[imgId], "image/gif");
                lrImage.ContentId = imgId;
                htmlBody.LinkedResources.Add(lrImage);
            }
            mailMessage.AlternateViews.Add(htmlBody);
        }

        public void Send()
        {
            if (toEmails.Count <= 0)
                throw new Exception("没有收件人地址");
            mailMessage.To.Add(toEmails[0]);
            AddHtmlContent();
            for (int i = 1; i < toEmails.Count; i++)
            {
                mailMessage.CC.Add(toEmails[i]);
            }
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = "smtp." + mailMessage.From.Host;
            smtpClient.Credentials = new NetworkCredential(mailMessage.From.Address, pwd);
            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            smtpClient.SendAsync(mailMessage, null);
        }

        public event SendCompletedEventHandler SendDone; 

        void smtpClient_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (SendDone != null)
                SendDone(sender, e);
            //if (e.Cancelled)
            //{
            //    Console.WriteLine("发送被取消");
            //}
            //else
            //{
            //    if (e.Error == null)
            //    {
            //        Console.WriteLine("发送成功");
            //    }
            //    else
            //    {
            //        Console.WriteLine("发送失败： " + e.Error.Message);
            //    }
            //}
        }
         
        private bool IsEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch("373071116@qq.com", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        private bool IsNullOrEmp(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        //static void ff()
        //{
        //    string adr = "18701416082@163.com";
        //    string pwd = "";
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.From = new MailAddress(adr);
        //    //mailMessage.To.Add("18701416082@163.com");
        //    //mailMessage.CC.Add("duxy@ray-links.com");
        //    mailMessage.To.Add("duxy@ray-links.com");
        //    mailMessage.Subject = "hello dxy";
        //    AlternateView htmlBody = AlternateView.CreateAlternateViewFromString("<img src=\"cid:Email001\">", null, "text/html");
        //    LinkedResource lrImage = new LinkedResource(@"d:\1.jpg", "image/gif");
        //    lrImage.ContentId = "Email001";
        //    htmlBody.LinkedResources.Add(lrImage);
        //    mailMessage.AlternateViews.Add(htmlBody);

        //    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //    //mailMessage.Headers.Add("Disposition-Notification-To", "18701416082@163.com");
        //    //mailMessage.Headers.Add("X-Website", "www.duxiyao.com");
        //    //mailMessage.Headers.Add("ReturnReceipt", "1");
        //    mailMessage.Priority = MailPriority.High; //优先级
        //    //mailMessage.ReplyTo = new MailAddress("373071116@qq.com", "我自己");

        //    #region send
        //    //SmtpClient smtpClient = new SmtpClient();
        //    //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    //smtpClient.Host = "smtp." + mailMessage.From.Host;
        //    //smtpClient.Credentials = new NetworkCredential(mailMessage.From.Address, pwd);
        //    //smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
        //    //smtpClient.SendAsync(mailMessage, null);
        //    #endregion
        //    //Console.Read();
        //}
    }
     
}

/*
   Email email = new Email("xxx@163.com", "****");
            email.SetSubject("你好！");
            email.AddTo("18701416082@163.com");
            string htmlContent = "<img src=\"cid:dxy\">";
            email.AddHtmlContent(htmlContent);
            email.AddImgIdFile("dxy", @"d:\1.jpg");
            email.SendDone += new System.Net.Mail.SendCompletedEventHandler(email_SendDone);
            email.Send();
 
 */