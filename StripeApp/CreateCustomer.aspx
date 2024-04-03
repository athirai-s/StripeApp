<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCustomer.aspx.cs" Inherits="StripeApp.CreateCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Customer</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Create Customer</h2>
            <div>
                <label for="Name">Name:</label>
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="Phone">Phone Number:</label>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="EmployerId">Employer ID:</label>
                <asp:TextBox ID="EmployerId" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="Email">Email:</label>
                <asp:TextBox ID="Email" runat="server"></asp:TextBox>    
            </div>
            <div>
                <asp:Button ID="CreateCustomerButton" runat="server" Text="Create Customer" OnClick="CreateCustomer_Click" />
            </div>
            <div>
                <asp:Label ID="SuccessLabel" runat="server" ForeColor="Green" Visible="true"></asp:Label>
            </div>
            <div>
                <asp:Label ID="ResultLabel" runat="server" EnableViewState="False"></asp:Label> 
            </div>
        </div>
    </form>
</body>
</html>
