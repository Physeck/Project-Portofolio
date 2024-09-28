<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/AdminNavbar.Master" AutoEventWireup="true" CodeBehind="PendingVerificationPage.aspx.cs" Inherits="CareYou.Views.PendingVerificationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/pendingverificationstyle.css?Version=3" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home">
        <div class="main">
            <div class="container">
                
                    <div class="filter-box">
                        <h1 class="title">Pending Verification</h1>
                        <div class="filter-container">
                            <asp:Image class="filter-Button" ID="filter" src="/Assets/Admin/filter-circle.svg" runat="server" />
                            <asp:DropDownList ID="FilterDDL" runat="server" CssClass="filter-flex-div" OnSelectedIndexChanged="FilterDDL_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="none" CssClass="filter-container" Text="All" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="new" CssClass="filter-container">New Program</asp:ListItem>
                                <asp:ListItem Value="edit" CssClass="filter-container">Program Changes</asp:ListItem>
                                <asp:ListItem Value="org" CssClass="filter-container">Organization</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                <div class="card-container">
                    <asp:Repeater ID="PendingRepeater" runat="server">
                        <ItemTemplate>
                            <div class="program-card-container" onclick="location.href='/Views/AdminProgramDetail.aspx?id=<%# Eval("ProgramID") %>'&type=<%# Eval("Type")%>">
                                <%# Eval("ProgramTitle") %>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="OrganizationRepeater" runat="server">
                        <ItemTemplate>
                            <div class="org-card-container" onclick="location.href='/Views/AdminOrganizationDetail.aspx?id=<%# Eval("UserID") %>'">
                                <%# Eval("Name") %>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
