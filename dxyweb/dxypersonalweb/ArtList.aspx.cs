using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class ArtList : System.Web.UI.Page
{
    protected List<Article> artList = new List<Article>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BLL.BLArticle bl = new BLL.BLArticle();
            artList = bl.Select();
        }
    }
}