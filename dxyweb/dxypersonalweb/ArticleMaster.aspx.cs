using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ArticleMaster : System.Web.UI.Page
{
    protected Article art;
    protected List<Review> listReview;
    protected string fileName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BLArticle bll = new BLArticle();
            art = bll.SelectOne(Request.QueryString["Id"]);
            if (art != null)
            { 
                this.artName.InnerText = art.ArticleName;
                this.artDate.InnerText = art.AddDate.ToString("yyyy-MM-dd HH:mm:ss");
                string artContent = System.Text.Encoding.Default.GetString(System.IO.File.ReadAllBytes(art.ArticlePath));
                this.articleContent.InnerHtml = artContent;
                fileName=art.ArticleName+art.AddDate.ToString("yyyy-MM-dd.HH-mm-ss");

                listReview = new BLReview().SelectByArticleId(art.Id.ToString());
            }
        }
    }
}