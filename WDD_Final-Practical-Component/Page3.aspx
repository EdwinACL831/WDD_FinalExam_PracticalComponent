<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="WDD_Final_Practical_Component.Page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>SET Pizza Shop</h1>
        </header>
        <main>
            <h2 id="Greeting" runat="server"></h2>
            <h2>Step 3</h2>
            <p>This is the summary of your order:</p>
            <div></div>
            <asp:Button ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" />
            <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
        </main>
    </form>
</body>
</html>
