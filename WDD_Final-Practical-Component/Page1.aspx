<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="WDD_Final_Practical_Component.Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Pizza Shop</title>
    <link rel="stylesheet" href="Styles.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1 class="mainHeader">SET Pizza Shop</h1>
        </header>
        <div class="container">
            <h1 class="multi-color-text">Welcome to SET Pizza Shop!</h1>
            <p class="content-text1">Here you can order pizza online!</p>
            <h2 class="step-content">Step 1</h2>
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="prompt-text">Please enter your <b>full name</b> (<i>first</i> and <i>last</i> name)</asp:Label>
            <br/>
            <input id="FullName" type="text" runat="server" placeholder="Sally Smith" class="input-text"/>
            <asp:Button ID="NextBtn" runat="server" Text="Next" OnClick="NextBtn_Click" CssClass="button"/>
            <div id="FeedBack" runat="server" class="warning-text"></div>
        </div>
    </form>
</body>
</html>
