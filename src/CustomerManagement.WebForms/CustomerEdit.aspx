<%@ Page Title="Edit Customer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="CustomerManagement.WebForms.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Customer information</h1>
    <div class="text-center">
        <%--<div class="form-group">
        <asp:Label Text="Id" runat="server" />
        <asp:TextBox ID="customerId" CssClass="form-control" runat="server" ReadOnly="true"/>
        </div>--%>
        <div class="form-group">
            <asp:Label Text="First Name" runat="server" />
            <asp:TextBox ID="customerFirstName" CssClass="form-control center-block" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Last Name" runat="server" />
            <asp:TextBox ID="customerLastName" CssClass="form-control center-block" runat="server" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="customerLastName" ErrorMessage="Last Name required"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="customerLastName" ValidationExpression=".{1,50}" ErrorMessage="Last Name too long"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Phone number" runat="server" />
            <asp:TextBox ID="customerPhoneNumber" CssClass="form-control center-block" runat="server" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="customerPhoneNumber" ValidationExpression="\+\d{5,15}" ErrorMessage="Invalid phone number format"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="customerEmail" CssClass="form-control center-block" runat="server" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="customerEmail" ValidationExpression="[[:alnum:]]+@[[:alnum:]]+\.[[:alnum:]]+" ErrorMessage="Invalid email format"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Total purchases amount" runat="server" />
            <asp:TextBox ID="customerTotalPurchasesAmount" CssClass="form-control center-block" runat="server" />
        </div>

        <asp:Button CssClass="btn btn-primary"  Text="Save" runat="server" OnClick="onClickSave"/>
        <a class="btn btn-info" href="CustomerList.aspx">Cancle</a>
    </div>

</asp:Content>
