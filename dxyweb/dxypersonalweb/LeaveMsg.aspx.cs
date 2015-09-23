using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaveMsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        { 
            BLL.BLLeaveMsg bl = new BLL.BLLeaveMsg();
            if (bl.Insert(name.Value, tel.Value, qq.Value, email.Value, company.Value, industry.Value, interest.Value))
            {
                Response.Write("<script type='text/javascript' >alert('谢谢留言！回见！');location.href = 'Default.aspx';</script>");
               
            }
            else
            {
                Response.Write("<script type='text/javascript' >alert('err');location.href = 'LeaveMsg.aspx';</script>"); 
            }
        }
    }
}