<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewContent.aspx.cs" Inherits="ReviewContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>--%>
</head>
<body> 
<div class="newsList_box">
	<ul> 
<%
    if (listReview != null)
    {
        foreach(Model.Review rev in listReview){
            %>
            <li>
  <%--          <div>
            <%=System.Text.Encoding.Default.GetString(System.IO.File.ReadAllBytes(rev.ReviewContentPath)) %>
            </div>--%>
            <div>
            <div id="reviewContent"><%=System.Text.Encoding.Default.GetString(System.IO.File.ReadAllBytes(rev.ReviewContentPath)) %></div>
            <div id="reviewDate"> <%=rev.ReviewDate %> <span id="who"></span></div>
            </div>
            </li> 
            <%
        }
    }
     %> 
	</ul>
</div>
</body>
</html>
