<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBob.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="card-header">
                <h1>Papa Bob's Pizza</h1>
                <p class="lead">Pizza to Code by</p>
              </div>
           
            <div class="form-group">
                <label>Size:</label>
            <asp:DropDownList ID="sizeDropDownList" runat="server" CssClass ="form-control" AutoPostBack="true" OnSelectedIndexChanged="recalculateCost">
                <asp:ListItem value="" >Choose one..</asp:ListItem>
                <asp:ListItem Value="Small">Small(12 inch - $12)</asp:ListItem>
                <asp:ListItem Value="Medium">Medium (14 inch - $14)</asp:ListItem>
                <asp:ListItem Value="Large">Large (16 inch - $16)</asp:ListItem>
                </asp:DropDownList>
                
                </div>
            <div class="form-group">
                <label>Crust:</label>
            <asp:DropDownList ID="crustDropDownList" runat="server" CssClass ="form-control" AutoPostBack ="true" OnSelectedIndexChanged="recalculateCost">
                <asp:ListItem Value="">Choose one..</asp:ListItem>
                <asp:ListItem>Regular</asp:ListItem>
                <asp:ListItem>Thin</asp:ListItem>
                <asp:ListItem Value="Thick">Thick (+ $2)</asp:ListItem>
                </asp:DropDownList>
                
                 </div>
            <div class="custom-checkbox"><label> <asp:CheckBox ID="sausageCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged ="recalculateCost" /> Sausage</label></div>
            <div class="custom-checkbox"><label> <asp:CheckBox ID="pepperoniCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged ="recalculateCost"/> Pepperoni</label></div>
            <div class="custom-checkbox"><label> <asp:CheckBox ID="onionsCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged ="recalculateCost"/> Onions</label></div>
            <div class="custom-checkbox"><label> <asp:CheckBox ID="greenpepperCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged ="recalculateCost"/> Green Pepper</label></div>
            
       

            <h3>Deliver To:</h3>
            <div class ="form-group">
                <label>Name:</label>
            <asp:TextBox ID="nameTextBox" runat="server" CssClass ="form-control"></asp:TextBox>
              </div>
             <div class ="form-group">
                <label>Adress:</label>
            <asp:TextBox ID="adressTextBox" runat="server" CssClass ="form-control"></asp:TextBox>
              </div>
             <div class ="form-group">
                <label>Zip:</label>
            <asp:TextBox ID="zipTextBox" runat="server" CssClass ="form-control"></asp:TextBox>
              </div>
             <div class ="form-group">
                <label>Phone:</label>
            <asp:TextBox ID="phoneTextBox" runat="server" CssClass ="form-control"></asp:TextBox>
              </div>
           

            <h3>Payment:</h3>

            <div class="custom-radio"><label><asp:RadioButton ID="cashRadioButton" runat="server" GroupName ="PaymentGroup" Checked="true" /></label> Cash</div>
            <div class="custom-radio"><label><asp:RadioButton ID="creditRadioButton" runat="server" GroupName ="PaymentGroup" /></label> Credit</div>

            <asp:Button ID="orderButton" runat="server" Text="Order" Cssclass ="btn btn-group-lg btn-primary" OnClick="orderButton_Click"/>
            <p>&nbsp;</p>
            <h6><asp:Label ID="validationLabel" runat="server" Text="" Visible ="false" CssClass ="bg-danger"></asp:Label></h6>
            <h3>Total Cost: <asp:Label ID="paymentLabel" runat="server" Text=""></asp:Label></h3>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            

        </div>         
    </form>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
