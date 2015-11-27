using Model.ts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DAL.ts
{
    public class DaoUserInfo
    {
        public UserInfo SelectById(string id)
        {
            string sql = "select * from tab_ts_user_basic_info where id=? ";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@id",id)
                                               };
            UserInfo userInfo = Select(sql, oleDbParameters);
            return userInfo;
        }

        public UserInfo SelectByPhonePwd(string phone, string pwd)
        {
            string sql = "select * from tab_ts_user_basic_info where phone=? and pwd=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@phone",phone),
                                               new OleDbParameter("@pwd",pwd)};
            UserInfo userInfo = Select(sql, oleDbParameters);
            userInfo.Pwd = "";
            return userInfo;
        }

        public UserInfo SelectByEmailPwd(string email, string pwd)
        {
            string sql = "select * from tab_ts_user_basic_info where email=? and passwd=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@email",email),
                                               new OleDbParameter("@pwd",pwd)};
            return Select(sql, oleDbParameters); ;
        }

        public UserInfo SelectByQQOpenId(string qqOpenId)
        {
            string sql = "select * from tab_ts_user_basic_info where qqOpenId=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@qqOpenId", qqOpenId) };
            UserInfo userInfo = Select(sql, oleDbParameters);
            userInfo.Pwd = "";
            return userInfo;
        }

        public UserInfo SelectByWXOpenId(string wxOpenId)
        {
            string sql = "select * from tab_ts_user_basic_info where wxOpenId=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@wxOpenId", wxOpenId) };
            UserInfo userInfo = Select(sql, oleDbParameters);
            userInfo.Pwd = "";
            return userInfo;
        }


        public UserInfo Select(string sql, OleDbParameter[] oleDbParameters)
        {
            DataSet ds = SQLHelper.Query(sql, oleDbParameters);
            return Select(ds);
        }


        public UserInfo Select(string sql)
        {
            DataSet ds = SQLHelper.Query(sql);
            return Select(ds);
        }

        private UserInfo Select(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.Id = int.Parse(dr["Id"].ToString());
                    userInfo.Name = dr["name"].ToString();
                    userInfo.Pwd = dr["pwd"].ToString();
                    userInfo.Age = int.Parse(dr["age"].ToString());
                    userInfo.Sex = int.Parse(dr["sex"].ToString());
                    userInfo.Phone = dr["phone"].ToString();
                    userInfo.Email = dr["email"].ToString();
                    userInfo.Qq = dr["qq"].ToString();
                    userInfo.Wx = dr["wx"].ToString();
                    userInfo.QqOpenId = dr["qqOpenId"].ToString();
                    userInfo.WxOpenId = dr["wxOpenId"].ToString();
                    userInfo.Verify = int.Parse(dr["verify"].ToString());
                    userInfo.PhotoUrl = dr["photoUrl"].ToString();

                    userInfo.DateCreated = dr["dateCreated"].ToString();
                    userInfo.SubAccountSid = dr["subAccountSid"].ToString();
                    userInfo.SubToken = dr["subToken"].ToString();
                    userInfo.VoipAccount = dr["voipAccount"].ToString();
                    userInfo.VoipPwd = dr["voipPwd"].ToString();
                    userInfo.DataBirthday = DateTime.Parse(dr["dataBirthday"].ToString());
                    userInfo.UpdateTime = DateTime.Parse(dr["updateTime"].ToString());
                    return userInfo;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据终端提交的k v更新数据库。k必须为表中字段
        /// </summary>
        /// <param name="inttype">选择存入哪个表 0 基础表 ; 1 学生附加表 ; 2 老师附加表</param>
        /// <param name="id"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool UpdateUserInfoKV(int intType, string id, Dictionary<string, string> p)
        {
            if (p == null || p.Count == 0)
                return false;
            try
            {
                string sqlPre = "";
                string surffix = "";
                switch (intType)
                {
                    case 0:
                        sqlPre = "update a set ";
                        surffix = " from tab_ts_user_basic_info a where a.id=? ";
                        break;
                    case 1:
                        sqlPre = "update b set ";
                        surffix = " from tab_ts_user_basic_info a,tab_ts_student_info b where a.id=b.ubId and a.id=?";
                        break;
                    case 2:
                        sqlPre = "update b set ";
                        surffix = " from tab_ts_user_basic_info a,tab_ts_teacher_info b where a.id=b.ubId and a.id=?";
                        break;
                    default:
                        break;
                }
                string s = "";

                List<OleDbParameter> l = new List<OleDbParameter>();
                foreach (string k in p.Keys)
                {
                    l.Add(new OleDbParameter(k, p[k]));
                    s = s + k + "=? , ";
                }
                string sql = sqlPre + s.Substring(0, s.Length - 2) + surffix;


                l.Add(new OleDbParameter("@a.id", id));
                if (SQLHelper.ExecuteSql(sql, l.ToArray()) > 0)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUserInfoKV(string id, string k, string v)
        {
            try
            {
                string sql = "update tab_ts_user_basic_info set " + k + "=? , updateTime=? where id=?";
                OleDbParameter[] oleDbParameters = { new OleDbParameter(k,v),
                                               new OleDbParameter("@updateTime",DateTime.Now),
                                               new OleDbParameter("@id",id)};
                if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(string phone, string pwd)
        {
            OleDbParameter pVerify = new OleDbParameter("@verify", OleDbType.Integer);
            pVerify.Value = 1;
            string sql = "insert into tab_ts_user_basic_info (phone,pwd,verify,dataBirthday,updateTime) values(?,?,?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@phone",phone),
                                               new OleDbParameter("@pwd",pwd),
                                                pVerify ,
                                                   new OleDbParameter("@dataBirthday",DateTime.Now),
                                               new OleDbParameter("@updateTime",DateTime.Now)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }

        public bool ExistsByEmail(string email)
        {
            string sql = "select count(*) from tab_ts_user_basic_info where email=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@email", email) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool ExistsByPhone(string phone)
        {
            string sql = "select count(*) from tab_ts_user_basic_info where phone=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@phone", phone) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool ExistsByPhone(string phone, string pwd)
        {
            string sql = "select count(*) from tab_ts_user_basic_info where phone=? and pwd=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@phone", phone), new OleDbParameter("@pwd", pwd) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool ExistsByQQOpenId(string qqOpenId)
        {
            string sql = "select count(*) from tab_ts_user_basic_info where qqOpenId=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@qqOpenId", qqOpenId) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool ExistsByWXOpenId(string wxOpenId)
        {
            string sql = "select count(*) from tab_ts_user_basic_info where wxOpenId=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@wxOpenId", wxOpenId) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool InsertQQOpenId(string qqOpenId, string nickname, string figureurl_qq_2)
        {
            OleDbParameter pVerify = new OleDbParameter("@verify", OleDbType.Integer);
            pVerify.Value = 0;
            string sql = "insert into tab_ts_user_basic_info (qqOpenId,name,photoUrl,verify,dataBirthday,updateTime) values(?,?,?,?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@qqOpenId",qqOpenId),
                                                    new OleDbParameter("@name",nickname),
                                                     new OleDbParameter("@photoUrl",figureurl_qq_2),
                                                pVerify ,
                                                   new OleDbParameter("@dataBirthday",DateTime.Now),
                                               new OleDbParameter("@updateTime",DateTime.Now)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }

        public bool InsertWxOpenId(string wxOpenId)
        {
            OleDbParameter pVerify = new OleDbParameter("@verify", OleDbType.Integer);
            pVerify.Value = 0;
            string sql = "insert into tab_ts_user_basic_info (wxOpenId,verify,dataBirthday,updateTime) values(?,?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@wxOpenId",wxOpenId),
                                                pVerify ,
                                                   new OleDbParameter("@dataBirthday",DateTime.Now),
                                               new OleDbParameter("@updateTime",DateTime.Now)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }

        public bool Update(string phone, string dateCreated, string subAccountSid, string subToken, string voipAccount, string voipPwd)
        {
            if (!ExistsByPhone(phone))
            {
                return false;
            }
            string sql = "update tab_ts_user_basic_info set dateCreated=?, subAccountSid=?, subToken=?, voipAccount=?, voipPwd=?, updateTime=? where phone=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@dateCreated",dateCreated),
                                               new OleDbParameter("@subAccountSid",subAccountSid),
                                                 new OleDbParameter("@subToken",subToken),
                                                   new OleDbParameter("@voipAccount",voipAccount),
                                                   new OleDbParameter("@voipPwd",voipPwd),
                                               new OleDbParameter("@updateTime",DateTime.Now),
                                                   new OleDbParameter("@email",phone)};
            return SQLHelper.ExecuteSql(sql, oleDbParameters) > 0 ? true : false;
        }

        public bool Verified(string voipAccount)
        {
            string sql = "update tab_ts_user_basic_info set verify=?, updateTime=? where voipAccount=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@verify",1), 
                                               new OleDbParameter("@updateTime",DateTime.Now.ToString()),
                                                   new OleDbParameter("@voipAccount",voipAccount)};
            return SQLHelper.ExecuteSql(sql, oleDbParameters) > 0 ? true : false;
        }

        public bool IsCanSendCode(string phone, string aesCode)
        {
            DAL.ts.DaoVerifyCode daoCode = new DAL.ts.DaoVerifyCode();
            if (daoCode.Exists(aesCode))
            {
                return false;
            }
            else
            {
                if (daoCode.ExistsTwoToday(phone))
                    return false;
            }
            return true;
        }
    }
}
