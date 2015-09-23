using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ReviewContent : System.Web.UI.Page
{
    protected List<Review> listReview;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string artId = Request.QueryString["artId"];
            if (string.IsNullOrEmpty(artId))
                return;
            listReview = new BLReview().SelectByArticleId(artId);
        }
    }
}