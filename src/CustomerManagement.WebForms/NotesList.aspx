<%@ Page Title="Notes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotesList.aspx.cs" Inherits="CustomerManagement.WebForms.NotesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><b><%=_currentCustomer.FirstName %> <%=_currentCustomer.LastName %></b> Notes</h1>
    <div class="text-right">
        <a class="btn btn-success" href="NoteEdit.aspx?customerId=<%=_currentCustomer.Id %>">Add new note</a>
    </div>
    <table class="table text-center">
        <thead>
            <tr>
                <th class="text-center">
                    Id
                </th>
                <th class="text-center">
                    Note text
                </th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var note in _noteList)
                { %>
            <tr>
                <td>
                    <%=note.Id%>
                </td>
                <td>
                    <%=note.NoteText%>
                </td>
                <td>
                    <a href="NoteEdit.aspx?noteId=<%=note.Id %>&operation=edit&customerId=<%=_currentCustomer.Id %>" role="button" class="btn btn-primary">
                        Edit
                    </a>
                    <a href="NoteEdit.aspx?noteId=<%=note.Id %>&operation=delete&customerId=<%=_currentCustomer.Id %>" role="button" class="btn btn-danger">
                        Delete
                    </a>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
    <div class="d-flex flex-row">
        <asp:Button ID="buttonFirst" CssClass="btn btn-secondary" Text="First" onclick="onClickFirstPage" runat="server"></asp:Button>
        <asp:Button ID="buttonPrev" CssClass="btn btn-secondary" Text="Prev" onclick="onClickPrevPage" runat="server"></asp:Button>
        <asp:Button ID="buttonNext" CssClass="btn btn-secondary" Text="Next" onclick="onClickNextPage" runat="server"></asp:Button>
        <asp:Button ID="buttonLast" CssClass="btn btn-secondary" Text="Last" onclick="onClickLastPage" runat="server"></asp:Button>
    </div>
</asp:Content>
