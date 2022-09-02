<%@ Page Title="Address edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressEdit.aspx.cs" Inherits="CustomerManagement.WebForms.AddressEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Address information</h1>
    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="Address Line" runat="server" />
            <asp:TextBox ID="addressLine" CssClass="form-control center-block" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Address Line 2" runat="server" />
            <asp:TextBox ID="addressLine2" CssClass="form-control center-block" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Label Text="AddressType" runat="server" />
            <asp:TextBox ID="addressType" CssClass="form-control center-block" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Label Text="City" runat="server" />
            <asp:TextBox ID="city" CssClass="form-control center-block" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Postal Code" runat="server" />
            <asp:TextBox ID="postalCode" CssClass="form-control center-block" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Label Text="State" runat="server" />
            <asp:TextBox ID="state" CssClass="form-control center-block" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Label Text="Country" runat="server" />
            <asp:TextBox ID="country" CssClass="form-control center-block" runat="server"/>
        </div>
        <asp:Button CssClass="btn btn-primary"  Text="Save" runat="server" OnClick="onAddressSave"/>
        <a class="btn btn-info" href="AddressesList.aspx?page=1&customerId=<%=Request.QueryString["customerId"] %>">Cancle</a>
    </div>
</asp:Content>
