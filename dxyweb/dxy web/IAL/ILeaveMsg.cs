using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IAL
{
    public interface ILeaveMsg
    {
        bool Insert(LeaveMsg leaveMsg);
    }
}
