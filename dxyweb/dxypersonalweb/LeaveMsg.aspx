<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LeaveMsg.aspx.cs" Inherits="LeaveMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" >
    $(function () {
        $("#navigation li").removeClass("active");
        $("#lmsg").addClass("active"); 
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="whiteblock"><ul><li> 
        <div class="article"   style="margin-top:-30px;" > 
          <form action="#" method="post"  runat="server">
          <ol>
          <li>
        <h2><span>我们有合作机会？那就联系我吧！！</span>^,^Y</h2><div class="clr"></div>
          <p style="font-size:20px;">请把您的信息留下来吧，我会及时跟您联系的！！</p>     
          </li>
          <li>
            <label for="name">姓名称呼 (写写吧，不写的话我打电话怎么称呼您我都不知道...<img border="0" alt="" src="kindeditor-4.1.10/plugins/emoticons/images/49.gif" />)</label>
            <input id="name" name="name" class="text" runat="server"/>
          </li><li>
            <label for="tel">联系电话 (直接打电话会省很多没必要的麻烦哦！！！<img border="0" alt="" src="kindeditor-4.1.10/plugins/emoticons/images/21.gif" />)</label>
            <input id="tel" name="email" class="text" runat="server"/>
          </li><li>
            <label for="email">电子邮箱 (方便我们互发规范性的文件等数据。。。<img border="0" alt="" src="kindeditor-4.1.10/plugins/emoticons/images/3.gif" />)</label>
            <input id="email" name="website" class="text" runat="server"/>
          </li><li>
            <label for="qq">QQ (及时沟通，互相了解。。。<img border="0" alt="" src="kindeditor-4.1.10/plugins/emoticons/images/81.gif" />)</label>
            <input id="qq" name="name" class="text" runat="server"/>
          </li><li>
            <label for="company">公司 (可以不告诉我。<img border="0" alt="" src="kindeditor-4.1.10/plugins/emoticons/images/46.gif" />)</label>
            <input id="company" name="name" class="text" runat="server"/>
          </li><li>
            <label for="industry">行业 (你是CIA的？<img border="0" alt="" src="kindeditor-4.1.10/plugins/emoticons/images/53.gif" />)</label>
            <input id="industry" name="name" class="text" runat="server"/>
          </li><li>
            <label for="interest">说点感兴趣的吧 (<img border="0" alt="" src="kindeditor-4.1.10/plugins/emoticons/images/0.gif" />)</label>
            <textarea id="interest" name="message" rows="8" cols="50" runat="server"></textarea>
          </li></ol>
            <input type="image" name="imageField" id="imageField" src="images/submit.gif" class="send" />
            <div class="clr"></div>
          
          </form>
        </div> 
        </li></ul> </div>
</asp:Content>

