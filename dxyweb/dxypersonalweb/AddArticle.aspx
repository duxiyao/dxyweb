<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddArticle.aspx.cs" Inherits="AddArticle" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8" />
    <title>Add Article</title>
    <link rel="stylesheet" href="kindeditor-4.1.10/themes/default/default.css" />
	<link rel="stylesheet" href="kindeditor-4.1.10/plugins/code/prettify.css" />
	<script charset="utf-8" src="kindeditor-4.1.10/kindeditor.js"></script>
	<script charset="utf-8" src="kindeditor-4.1.10/lang/zh_CN.js"></script>
	<script charset="utf-8" src="kindeditor-4.1.10/plugins/code/prettify.js"></script>
	<script type="text/javascript" language="javascript" src="js/jquery-1.7.2.min.js"></script>
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#articleContent', {
	            cssPath: 'kindeditor-4.1.10/plugins/code/prettify.css',
	            uploadJson: 'kindeditor-4.1.10/asp.net/upload_json.ashx',
	            fileManagerJson: 'kindeditor-4.1.10/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
    </script>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="example" runat="server">
        <div class="style1">
            <asp:Label ID="Label1" runat="server" Text="标题："></asp:Label>
            <asp:TextBox ID="tbArticleName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                ControlToValidate="tbArticleName" Display="Dynamic" ErrorMessage="请填写标题" 
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
        <textarea id="articleContent" style="width:662px; height:450px; visibility:hidden;" 
            runat="server"></textarea>&nbsp;<br />
        <asp:Button ID="btnSubmit" runat="server" Text="提交内容" />
        </div>
    </form>
</body>
</html>