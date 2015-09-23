using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DaoUserInfo
    {
        public TabUserInfo SelectByEmailPwd(string email,string pwd)
        {
            string sql = "select * from tab_user_info where email=? and passwd=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@email",email),
                                               new OleDbParameter("@passwd",pwd)};
            return Select(sql, oleDbParameters); ;
        }


        public TabUserInfo Select(string sql, OleDbParameter[] oleDbParameters)
        {
            DataSet ds = SQLHelper.Query(sql,oleDbParameters);
            return Select(ds);
        }


        public TabUserInfo Select(string sql)
        {
            DataSet ds = SQLHelper.Query(sql);
            return Select(ds);
        }

        private TabUserInfo Select(DataSet ds)
        { 
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TabUserInfo userInfo = new TabUserInfo();
                    userInfo.Id = int.Parse(dr["Id"].ToString());
                    userInfo.Name = dr["name"].ToString();
                    userInfo.Passwd = dr["passwd"].ToString();
                    userInfo.Sex = int.Parse(dr["sex"].ToString());
                    userInfo.Phone = dr["phone"].ToString();
                    userInfo.Email = dr["email"].ToString();
                    userInfo.Verify = int.Parse(dr["verify"].ToString());

                    userInfo.DateCreated = dr["dateCreated"].ToString();
                    userInfo.SubAccountSid = dr["subAccountSid"].ToString();
                    userInfo.SubToken = dr["subToken"].ToString();
                    userInfo.VoipAccount = dr["voipAccount"].ToString();
                    userInfo.VoipPwd = dr["voipPwd"].ToString();
                    userInfo.CreateTime = dr["createTime"].ToString();
                    userInfo.UpdateTime = dr["updateTime"].ToString();
                    return userInfo;
                }
            }
            return null;
        }

        public bool Insert(string email, string pwd)
        {
            OleDbParameter pVerify=new OleDbParameter("@verify",OleDbType.Integer);
            pVerify.Value=0;
            string sql = "insert into tab_user_info (email,passwd,verify,createTime,updateTime) values(?,?,?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@email",email),
                                               new OleDbParameter("@passwd",pwd),
                                                pVerify ,
                                                   new OleDbParameter("@createTime",DateTime.Now.ToString()),
                                               new OleDbParameter("@updateTime",DateTime.Now.ToString())};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }

        public bool Exists(string email)
        {
            string sql = "select count(*) from tab_user_info where email=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@email", email) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool Update(string email, string dateCreate, string subAccountSid, string subToken, string voipAccount, string voipPwd)
        {
            if (!Exists(email))
            {
                return false;
            }
            string sql = "update tab_user_info set dateCreated=?, subAccountSid=?, subToken=?, voipAccount=?, voipPwd=?, updateTime=? where email=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@dateCreate",dateCreate),
                                               new OleDbParameter("@subAccountSid",subAccountSid),
                                                 new OleDbParameter("@subToken",subToken),
                                                   new OleDbParameter("@voipAccount",voipAccount),
                                                   new OleDbParameter("@voipPwd",voipPwd),
                                               new OleDbParameter("@updateTime",DateTime.Now.ToString()),
                                                   new OleDbParameter("@email",email)};
            return SQLHelper.ExecuteSql(sql, oleDbParameters) > 0 ? true : false;
        }

        public bool Verified(string voipAccount)
        {
            string sql = "update tab_user_info set verify=?, updateTime=? where voipAccount=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@verify",1), 
                                               new OleDbParameter("@updateTime",DateTime.Now.ToString()),
                                                   new OleDbParameter("@voipAccount",voipAccount)};
            return SQLHelper.ExecuteSql(sql, oleDbParameters) > 0 ? true : false;
        }
    }
}
