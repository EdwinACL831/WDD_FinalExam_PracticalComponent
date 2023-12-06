<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="WDD_Final_Practical_Component.page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Choose toppings</title>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Ciao <i>Edwin</i></h2>
            
            <p>You can only order <b>ONE</b> pizza each time with sause and cheese, these are <b>topping</b> you can select:</p>

            Debug option 1:
            <asp:CheckBoxList ID="Toppings_Options" runat="server">
                <asp:ListItem Text="pepperoni" Value="pepperoni" name="pepperoni" />
                <asp:ListItem Text="mushrooms" Value="mushrooms" name="mushrooms" />
                <asp:ListItem Text="green olives" Value="green_olives" />
                <asp:ListItem Text="green peppers" Value="green_peppers" />
                <asp:ListItem Text="double cheese" Value="double_cheese" />
            </asp:CheckBoxList>
            <br/>
            Debug option 2:
            <div>
                <asp:CheckBox ID="pepperoni" runat="server" Text="pepperoni" AutoPostBack="true" OnCheckedChanged="Select_topping"/>
                <asp:CheckBox ID="mushrooms" runat="server" Text="mushrooms"/>
                <asp:CheckBox ID="green_olives" runat="server" Text="green olives"/>
                <asp:CheckBox ID="green_peppers" runat="server" Text="green peppers"/>
                <asp:CheckBox ID="double_cheese" runat="server" Text="double cheese"/>
            </div>
            
            
            <h3>Total price:$
                <asp:Label ID="Price" runat="server" Text="0.0"></asp:Label>
            </h3>
            

            <script type="text/javascript">
                $(document).ready(function () {
                    // Attach an event handler to the checkbox
                    $("#Toppings_Options").change(function (e) {
                        console.log(e.originalEvent.target.defaultValue);
                        // Check if the checkbox is checked
                        let topping = e.originalEvent.target.defaultValue;
                        console.log({ topping });
                        $.ajax({
                            type: "POST",
                            url: "Page2.aspx/TestMethod",
                            data: { topping },
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                // Update the result div with the server response
                                document.getElementById('Price').value = "ss";
                            }
                        });
                    })
                });
            </script>





            <!--
                pepperoni, mushrooms, green olives, green peppers and double cheese
                -->
        </div>
    </form>
</body>
</html>
