﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="WDD_Final_Practical_Component.page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Choose toppings</title>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
     <link rel="stylesheet" href="Styles.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1 class="mainHeader">SET Pizza Shop</h1>
        </header>
        <div class="container">
            <h1 class="multi-color-text">Ciao
                <i><asp:Label ID="userName" runat="server" Text=""></asp:Label></i>
            </h1>
            <h2 class="step-content">Step 2</h2>
            <p class="content-text2">You can only order <b class="ONE"><i>ONE</i></b> pizza each time with <b class="underline">sause</b> and <b class="underline">cheese</b>, <br/>these are <b>topping</b> you can select:</p>

            <asp:CheckBoxList ID="Toppings_Options" runat="server" CssClass="check-list">
                <asp:ListItem Text="pepperoni...$1.5" Value="1.5" />
                <asp:ListItem Text="mushrooms...$1" Value="1" />
                <asp:ListItem Text="green olives...$1" Value="1" />
                <asp:ListItem Text="green peppers...$1" Value="1" />
                <asp:ListItem Text="double cheese...$2.25" Value="2.25" />
            </asp:CheckBoxList>
            
            <h3 class="prompt-text">Total price:$
                <label id="Price" runat="server">10.0</label>
            </h3>

            <asp:Button ID="NextBtn" runat="server" Text="Make it!" OnClick="NextBtn_Click" CssClass="button" />

            <script type="text/javascript">
                $(document).ready(function() {
                    let status;
                    // Attach an event handler to the checkbox
                    $("#<%= Toppings_Options.ClientID %> input[type='checkbox']").change(function(e) {
                        console.log({ e });

                        let JSONObject = {
                            "currentPrice": document.getElementById("Price").innerText,
                            "price": e.originalEvent.target.defaultValue,
                            "status": $(this).is(":checked")
                        };

                        console.log(JSONObject);
                        JSONString = JSON.stringify(JSONObject);
                        $.ajax({
                            type: "POST",
                            url: "Page2.aspx/ProcessToppingPrice",
                            data: JSONString,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                // Update the result div with the server response
                                data = $.parseJSON(response.d);
                                document.getElementById('Price').innerText = data.totalPrice;
                                console.log(data);
                            },
                            error: function(XMLHttpRequest, textStatus, errorThrown) {
                                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                            },
                        });
                    })
                });
            </script>
        </div>
    </form>
</body>
</html>
