using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class AddArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.btnSubmit.Attributes.Add("OnClick", "return confirm('确认添加？')");
        }
        else
        {
            string artContent = this.articleContent.Value;
            if (!string.IsNullOrEmpty(artContent))
            {
                string artName = this.tbArticleName.Text;
                //string artContent = Request.Form["articleContent"];
                DateTime addDate = DateTime.Now;
                string fileName = artName + addDate.ToString("yyyy-MM-dd.HH-mm-ss");
                string diectoryPath = BLArticle.artPath + fileName + @"\";
                System.IO.Directory.CreateDirectory(diectoryPath);
                string artPath = diectoryPath + fileName;
                System.IO.File.WriteAllBytes(artPath, System.Text.Encoding.Default.GetBytes(artContent));
                BLArticle bll = new BLArticle();
                if (bll.Insert(artName, artPath, addDate))
                    Response.Redirect("ArticleMaster.aspx");
            }
        }
    }
}