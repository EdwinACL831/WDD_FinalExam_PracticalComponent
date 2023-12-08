<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="WDD_Final_Practical_Component.Page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm your order</title>
    <link rel="stylesheet" href="Styles.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1 class="mainHeader">SET Pizza Shop</h1>
        </header>
        <main class="container">
            <h2 id="Greeting" runat="server" class="multi-color-text"></h2>
            <br/>
            <h2 class="step-content">Step 3</h2>
            <p class="content-text2">This is the summary of your order:</p>
            <div id="OrderSummary" runat="server" class="order-summary"></div>
            <div class="button">
                <asp:Button ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" cssClass="button1"/>
                <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" cssClass="button2"/>
            </div>
        </main>
    </form>
</body>
</html>
