<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="WDD_Final_Practical_Component.Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to SET Pizza Shop!</h1>
            <p>Here you can order pizza online!</p>
            <h2>Step 1</h2>
            <asp:Label ID="Label1" runat="server" Text="Label">Please enter your full name (first and last name)</asp:Label>
            <input id="FullName" type="text" runat="server" placeholder="Sally Smith"/>
            <asp:Button ID="NextBtn" runat="server" Text="Next" OnClick="NextBtn_Click" />
            <div id="FeedBack" runat="server" ></div>
        </div>
    </form>
</body>
</html>
