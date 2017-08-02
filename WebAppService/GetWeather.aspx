<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetWeather.aspx.cs" Inherits="WebAppService.GetWeather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      请输入查询的城市：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" Width="98px" /><br />
      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        天气概况：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><asp:Image ID="Image1" runat="server" /><br />
        天气实况:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
