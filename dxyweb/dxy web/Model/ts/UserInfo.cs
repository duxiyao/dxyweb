using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ts
{
    public class UserInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private int sex;

        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string qq;

        public string Qq
        {
            get { return qq; }
            set { qq = value; }
        }
        private string wx;

        public string Wx
        {
            get { return wx; }
            set { wx = value; }
        }
        private string qqOpenId;

        public string QqOpenId
        {
            get { return qqOpenId; }
            set { qqOpenId = value; }
        }
        private string wxOpenId;

        public string WxOpenId
        {
            get { return wxOpenId; }
            set { wxOpenId = value; }
        }
        private int verify;

        public int Verify
        {
            get { return verify; }
            set { verify = value; }
        }
        private string photoUrl;

        public string PhotoUrl
        {
            get { return photoUrl; }
            set { photoUrl = value; }
        }
        private string dateCreated;

        public string DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
        private string subAccountSid;

        public string SubAccountSid
        {
            get { return subAccountSid; }
            set { subAccountSid = value; }
        }
        private string subToken;

        public string SubToken
        {
            get { return subToken; }
            set { subToken = value; }
        }
        private string voipAccount;

        public string VoipAccount
        {
            get { return voipAccount; }
            set { voipAccount = value; }
        }
        private string voipPwd;

        public string VoipPwd
        {
            get { return voipPwd; }
            set { voipPwd = value; }
        }
        private DateTime dataBirthday;

        public DateTime DataBirthday
        {
            get { return dataBirthday; }
            set { dataBirthday = value; }
        }
        private DateTime updateTime;

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

    }
}
