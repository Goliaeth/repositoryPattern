<%@ Page Title="Address edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressEdit.aspx.cs" Inherits="CustomerManagement.WebForms.AddressEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Address information</h1>
    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="Address Line" runat="server" />
            <asp:TextBox ID="addressLine" CssClass="form-control center-block" runat="server"/>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="addressLine" ErrorMessage="Address line required"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="addressLine" ValidationExpression=".{1,100}" ErrorMessage="Address line too long"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Address Line 2" runat="server" />
            <asp:TextBox ID="addressLine2" CssClass="form-control center-block" runat="server"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="addressLine2" ValidationExpression=".{0,100}" ErrorMessage="Address line2 too long"/>
        </div>
        <div class="form-group">
            <asp:Label Text="AddressType" runat="server" />
            <asp:TextBox ID="addressType" CssClass="form-control center-block" runat="server"/>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="addressType" ErrorMessage="Type required"/>
        </div>
        <div class="form-group">
            <asp:Label Text="City" runat="server" />
            <asp:TextBox ID="city" CssClass="form-control center-block" runat="server"/>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="city" ErrorMessage="City required"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="city" ValidationExpression=".{1,50}" ErrorMessage="City too long"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Postal Code" runat="server" />
            <asp:TextBox ID="postalCode" CssClass="form-control center-block" runat="server"/>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="postalCode" ErrorMessage="Postal code required"/>
        </div>
        <div class="form-group">
            <asp:Label Text="State" runat="server" />
            <asp:TextBox ID="state" CssClass="form-control center-block" runat="server"/>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="state" ErrorMessage="State required"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Country" runat="server" />
            <asp:TextBox ID="country" CssClass="form-control center-block" runat="server"/>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="country" ErrorMessage="Country required"/>
        </div>
        <asp:Button CssClass="btn btn-primary"  Text="Save" runat="server" OnClick="onAddressSave"/>
        <a class="btn btn-info" href="AddressesList.aspx?page=1&customerId=<%=Request.QueryString["customerId"] %>">Cancle</a>
    </div>
</asp:Content>
