<%@ Page Title="Note edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoteEdit.aspx.cs" Inherits="CustomerManagement.WebForms.NoteEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Note information</h1>
    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="Note Text" runat="server" />
            <asp:TextBox ID="noteTextArea" CssClass="form-control center-block" runat="server"/>
        </div>
        <asp:Button CssClass="btn btn-primary"  Text="Save" runat="server" OnClick="onNoteSave"/>
        <a class="btn btn-info" href="NotesList.aspx?page=1&customerId=<%=Request.QueryString["customerId"] %>">Cancle</a>
    </div>
</asp:Content>
