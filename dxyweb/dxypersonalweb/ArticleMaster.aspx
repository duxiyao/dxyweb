<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleMaster.aspx.cs" Inherits="ArticleMaster" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8" />
    <link href="css/Layout.css" rel="stylesheet" type="text/css" />
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-size: 12px;
        }
        form
        {
            margin: 0;
        }
        textarea
        {
            display: block;
        }
        #J_editorDialog
        {
            display: none;
        }
    </style>
    <link rel="stylesheet" href="kindeditor-4.1.10/examples/jquery-ui/css/smoothness/jquery-ui-1.9.2.custom.css" />
    <link rel="stylesheet" href="kindeditor-4.1.10/themes/default/default.css" />
    <script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/examples/jquery.js"></script>
    <script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/examples/jquery-ui/js/jquery-ui-1.9.2.custom.js"></script>
    <script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/kindeditor.js"></script>
    <script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/lang/zh_CN.js"></script> 
    <script type="text/javascript" language="javascript">
        $(function () {
            ///////      

            var editor;
            $('#J_openDialog').click(function () {
                $('#J_editorDialog').dialog({
                    title: '评论',
                    width: 700,
                    open: function (event, ui) {
                        // 打开Dialog后创建编辑器
                        editor = KindEditor.create('textarea[name="reviewContent"]', {
                            cssPath: 'kindeditor-4.1.10/plugins/code/prettify.css',
                            uploadJson: 'kindeditor-4.1.10/asp.net/upload_json.ashx',
                            fileManagerJson: 'kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                            resizeType: 1
                        });
                        editor.options.cssData = 'body { font-size: 24px; }';
                    },
                    beforeClose: function (event, ui) {
                        // 关闭Dialog前移除编辑器
                        KindEditor.remove('textarea[name="reviewContent"]');
                    }
                });
            });

            function GetRevCont() { 
                $('#revCont').load("ReviewContent.aspx?artId=" + '<%=art.Id %>'); 
                /* $.ajax({
                type: "POST",
                url: "HGetRevCont.ashx",
                data: "artId=<%=art.Id %>",
                success: function (data) { 
                $('#revCont').load(data[0].ReviewContentPath);
                //alert(data[0].ReviewDate); 
                }
                });*/
            }

            $('#btnPublic').click(function () {
                $.ajax({
                    type: "POST",
                    url: "HDealReview.ashx",
                    data: "fileName=<%=fileName %>&artId=<%=art.Id %>&revContent=" + editor.html(),
                    success: function (result) {
                        if (result == 1) {
                            alert('发布成功！谢谢评论！');
                            $('#J_editorDialog').dialog("close");
                            //location.reload();    
                            GetRevCont();
                        }
                        else
                            alert('发布失败！请再评论，谢谢！');
                    }
                });
            });
            GetRevCont();
            ///////
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div>
        <h2 id="artName" class="artName" runat="server">
        </h2>
        <span id="artDate" class="artDate" runat="server"></span>
        <hr width="100%" size="3" color="#FF0000" />
    </div>
    <div id="articleContent" runat="server">
    </div>
    <hr width="100%" size="3" color="#FF0000" />
    </form>
    <%-- 评论、回复开始 --%>
    <div id="J_editorDialog">
        <textarea id="reviewContent" name="reviewContent" style="width: 100%; height: 200px;"></textarea>
        <div class="dxy_btn"> <a id="btnPublic" href="javascript:void(0);">发表评论</a> </div>
 <%--       <button type="button" id="btnPublic">
            发表评论</button>--%>
    </div>
    <%-- 评论、回复结束 --%>
<%--    <button type="button" id="J_openDialog">
        我要说两句</button>
    <button type="button" id="Button1">
        留下我的信息，方便联系</button>--%>
<div class="dxy_btn"> <a id="J_openDialog" href="javascript:void(0);">我要说两句</a> <a href="javascript:void(0);">留下信息，方便联系</a> </div>
        <p />
        <p />
    <%-- 评论、回复记录列表开始 --%>
    <div id="revCont" ><div style="clear:both;"></div></div>
    <%--
    <ul>
        <%
            if (listReview != null)
            {
                foreach (Model.Review review in listReview)
                { %>
            <li>
            <div><%=System.Text.Encoding.Default.GetString(System.IO.File.ReadAllBytes(review.ReviewContentPath)) %></div>
            </li>
           <hr width="100%" size="1" color="#000000" />
        <%}
        } %>
    </ul>
    --%>
    <%-- 评论、回复记录列表结束 --%>
</asp:Content>
