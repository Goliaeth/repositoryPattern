<%@ Page Title="Addresses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressesList.aspx.cs" Inherits="CustomerManagement.WebForms.AddressesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><b><%=_currentCustomer.FirstName %> <%=_currentCustomer.LastName %></b> Addresses</h1>
    <div class="text-right">
        <a class="btn btn-success" href="AddressEdit.aspx?customerId=<%=_currentCustomer.Id %>">Add new address</a>
    </div>
    <table class="table text-center">
        <thead>
            <tr>
                <th class="text-center">
                    Id
                </th>
                <th class="text-center">
                    AddressLine
                </th>
                <th class="text-center">
                    AddressLine2
                </th>
                <th class="text-center">
                    AddressType
                </th>
                <th class="text-center">
                    City
                </th>
                <th class="text-center">
                    PostalCode
                </th>
                <th class="text-center">
                    State
                </th>
                <th class="text-center">
                    Country
                </th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var address in _addressList)
                { %>
            <tr>
                <td>
                    <%=address.Id%>
                </td>
                <td>
                    <%=address.AddressLine%>
                </td>
                <td>
                    <%=address.AddressLine2%>
                </td>
                <td>
                    <%=address.AddressType%>
                </td>
                <td>
                    <%=address.City%>
                </td>
                <td>
                    <%=address.PostalCode%>
                </td>
                <td>
                    <%=address.State%>
                </td>
                <td>
                    <%=address.Country%>
                </td>
                <td>
                    <a href="AddressEdit.aspx?addressId=<%=address.Id %>&operation=edit&customerId=<%=_currentCustomer.Id %>" role="button" class="btn btn-primary">
                        Edit
                    </a>
                    <a href="AddressEdit.aspx?addressId=<%=address.Id %>&operation=delete&customerId=<%=_currentCustomer.Id %>" role="button" class="btn btn-danger">
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
