<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtList.aspx.cs" Inherits="ArtList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        $(function () {
            $("#navigation li").removeClass("active");
            $("#artlist").addClass("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="newsList_box" >  
          <ol >
          <%foreach (Model.Article art in artList)
            { %>
          <li>
            <a target="_blank" href="ArticleMaster.aspx?Id=<%=art.Id %>"><%=art.ArticleName %></a>
          </li> 
          <%} %>
          </ol>
          </div>
</asp:Content>

