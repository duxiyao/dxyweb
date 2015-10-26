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
            throw new NotImplementedException();
        }

        public string Insert(string phone, string imei, string aesCode)
        {
            string verifyCode = GenerateCode();
            string sql = "insert into tab_verify_request (aesCode,dataBirthday,imei,phone,verifyCode) values(?,?,?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@aesCode",aesCode),
                                                   new OleDbParameter("@dataBirthday",DateTime.Now),
                                               new OleDbParameter("@imei",imei),
                                               new OleDbParameter("@phone",phone),
                                               new OleDbParameter("@verifyCode",verifyCode)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return verifyCode;
            return null;
        }

        public bool Exists(string aesCode)
        {
            string sql = "select count(*) from tab_verify_request where aesCode =?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@aesCode", aesCode) };
            return SQLHelper.Exists(sql, oleDbParameters);
        }
        public bool ExistsTwoToday(string phone)
        {
            string sql = "select count(*) from tab_verify_request where DateDiff(dd,AddDate,getdate())=0 and phone =?";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@phone", phone) };
            DataSet ds = SQLHelper.Query(sql);
            if (ds.Tables[0].Rows.Count > 2)
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
