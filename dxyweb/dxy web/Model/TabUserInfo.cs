using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TabUserInfo
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
        private string passwd;

        public string Passwd
        {
            get { return passwd; }
            set { passwd = value; }
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
        private int verify;

        /// <summary>
        /// 0  注册未验证
        /// 1  已验证
        /// </summary>
        public int Verify
        {
            get { return verify; }
            set { verify = value; }
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

        private string createTime;

        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private string updateTime;

        public string UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }
    }
}
