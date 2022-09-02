<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerManagement.WebForms.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%=Title %></h1>
    
    <div class="text-right">
        <a class="btn btn-success" href="CustomerEdit.aspx">Add new customer</a>
    </div>
    
    <table class="table text-center">
        <thead>
            <tr>
                <th class="text-center">
                    Id
                </th>
                <th class="text-center">
                    First Name
                </th>
                <th class="text-center">
                    Last Name
                </th>
                <th class="text-center">
                    Phone number
                </th>
                <th class="text-center">
                    Email
                </th>
                <th class="text-center">
                    Total purchases amount
                </th>
                <th class="text-center">
                    Notes
                </th>
                <th class="text-center">
                    Addresses
                </th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var customer in _customerList)
            {%>
            <tr>
                <td>
                    <%=customer.Id%>
                </td>
                <td>                    
                    <%=customer.FirstName%>                    
                </td>
                <td>
                    <%=customer.LastName%>
                </td>
                <td>
                    <%=customer.PhoneNumber%>
                </td>
                <td>
                    <%=customer.Email%>
                </td>
                <td>
                    <%=customer.TotalPurchasesAmount%>
                </td>
                <td>
                    <a href="NotesList.aspx?page=1&customerId=<%=customer.Id %>" role="button" class="btn btn-link">
                        view
                    </a>
                </td>
                <td>
                    <a href="AddressesList.aspx?page=1&customerId=<%=customer.Id %>" role="button" class="btn btn-link">
                        view
                    </a>
                </td>
                <td>
                    <a href="CustomerEdit.aspx?customerId=<%=customer.Id %>&operation=edit" role="button" class="btn btn-primary">
                        Edit
                    </a>
                </td>
                <td>
                    <a href="CustomerEdit.aspx?customerId=<%=customer.Id %>&operation=delete" role="button" class="btn btn-danger">
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
