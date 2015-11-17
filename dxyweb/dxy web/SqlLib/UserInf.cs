using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlLib
{
    [Table("Consumers")]
    public class UserInf
    {
        private string _UserID;
        /// <summary>  
        /// 登陆ID  
        /// </summary>  
        [Field("ConsumerID", DbType.String, 12)]
        public string U_UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _Psw;
        /// <summary>  
        /// 登陆密码  
        /// </summary>  
        [Field("ConsumerPwd", DbType.String, 12)]
        public string U_Psw
        {
            get { return _Psw; }
            set { _Psw = value; }
        }

        private string _UserName;
        /// <summary>  
        /// 用户别称  
        /// </summary>  
        [Field("ConsumerName", DbType.String, 50)]
        public string U_UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _City;
        /// <summary>  
        /// 所住城市  
        /// </summary>  
        [Field("UserCity", DbType.String, 50)]
        public string U_City
        {
            get { return _City; }
            set { _City = value; }
        }

        private int _Popedom;
        /// <summary>  
        /// 权限  
        /// </summary>  
        [Field("popedom", DbType.Int32, 0)]
        public int U_Popedom
        {
            get { return _Popedom; }
            set { _Popedom = value; }
        }

        private DateTime _AddDataTime;
        /// <summary>  
        /// 注册时间  
        /// </summary>  
        [Field("addDataTime", DbType.Date, 0)]
        public DateTime U_AddDataTime
        {
            get { return _AddDataTime; }
            set { _AddDataTime = value; }
        }

        private int _Sex;
        /// <summary>  
        /// 性别  
        /// </summary>  
        [Field("Sex", DbType.Int32, 0)]
        public int U_Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private int _BirthTime;
        /// <summary>  
        /// 出身日期；  
        /// </summary>  
        [Field("BirthTime", DbType.String, 9)]
        public int U_BirthTime
        {
            get { return _BirthTime; }
            set { _BirthTime = value; }
        }
    }  
}
