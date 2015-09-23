using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class BLLeaveMsg
    {
        public bool Insert(string name,string tel,string qq,string email,string company,string industry,string interest)
        {
            LeaveMsg leaveMsg = new LeaveMsg();
            leaveMsg.Name = name;
            leaveMsg.Tel = tel;
            leaveMsg.Qq = qq;
            leaveMsg.Email = email;
            leaveMsg.Company = company;
            leaveMsg.Industry = industry;
            leaveMsg.Interest = interest;
            DaoLeaveMsg dao = new DaoLeaveMsg();
            try
            {
                return dao.Insert(leaveMsg);
            }
            catch 
            {
                return false;
            }
        }
    }
}
