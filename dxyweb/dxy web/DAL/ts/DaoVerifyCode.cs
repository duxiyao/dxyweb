using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DAL.ts
{
    public class DaoVerifyCode
    {
        private string GenerateCode()
        {
            return Util.GenerateRandomNumber(4);
        }

        public string Insert(string phone, string imei, string time, string aesCode)
        {
            string verifyCode = GenerateCode();
            string sql = "insert into tab_verify_request (aesCode,dataBirthday,imei,phone,verifyCode) values(?,?,?,?,?)";
            
            DateTime dt = DateTime.Parse(time);
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@aesCode",aesCode),
                                                   new OleDbParameter("@dataBirthday",dt),
                                               new OleDbParameter("@imei",imei),
                                               new OleDbParameter("@phone",phone),
                                               new OleDbParameter("@verifyCode",verifyCode)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return verifyCode;
            return null;
        }

        public bool Exists(string phone, string verifyCode)
        {
            string sql = "select count(*) from tab_verify_request where phone=? and verifyCode=?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@phone", phone), new OleDbParameter("@verifyCode", verifyCode) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool Exists(string aesCode)
        {
            string sql = "select count(*) from tab_verify_request where aesCode =?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@aesCode", aesCode) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }

        public bool ExistsTwoToday(string phone)
        {
            string sql = "select count(*) from tab_verify_request where DateDiff(dd,dataBirthday,getdate())=0 and phone =?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@phone", phone) };
            object obj = SQLHelper.GetSingle(sql, oleDbParameters);
            int ret = int.Parse(obj.ToString());
            if (ret > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
