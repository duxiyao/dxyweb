using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Statistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        string name = tbName.Text.ToString();
        string num = tbNum.Text.ToString();
        if (name == null || name.Trim().Length == 0)
        {
            Response.Write("<script>alert('写你的名字啊！')</script>");
            return;
        }
        if (num == null || num.Trim().Length == 0)
        {
            num = "0";
        }
        DAL.TabTmp tmp = new DAL.TabTmp();
        tmp.Insert(name, num);
        Response.Redirect("tmpthankyou.aspx");  
    }
}