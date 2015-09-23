using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAL;
using Model;
using System.Data.OleDb;

namespace DAL
{
    public class DaoLeaveMsg:ILeaveMsg
    {
        #region ILeaveMsg 成员

        public bool Insert(LeaveMsg leaveMsg)
        {
            string sql = "insert into LeaveMsg (Name,Tel,Qq,Email,Company,Industry,Interest,AddDate) values(?,?,?,?,?,?,?,?)";
            OleDbParameter[] oleDbParameters = { new OleDbParameter("@Name",leaveMsg.Name),
                                                   new OleDbParameter("@Tel",leaveMsg.Tel),
                                                   new OleDbParameter("@Qq",leaveMsg.Qq),
                                                   new OleDbParameter("@Email",leaveMsg.Email),
                                                   new OleDbParameter("@Company",leaveMsg.Company),
                                                   new OleDbParameter("@Industry",leaveMsg.Industry),
                                                   new OleDbParameter("@Interest",leaveMsg.Interest),
                                               new OleDbParameter("@AddDate",DateTime.Now)};
            if (SQLHelper.ExecuteSql(sql, oleDbParameters) > 0)
                return true;
            return false;
        }

        #endregion
    }
}
