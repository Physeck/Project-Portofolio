<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/AdminNavbar.Master" AutoEventWireup="true" CodeBehind="AdminProgramReport.aspx.cs" Inherits="CareYou.Views.AdminProgramReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/pendingverificationstyle.css?Version=3" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home">
        <div class="main">
            <div class="container">

                <div class="filter-box">
                    <h1 class="title">User Reports</h1>
                </div>
                <div class="card-container">
                    <asp:Repeater ID="ReportRepeater" runat="server">
                        <ItemTemplate>
                            <div class="program-card-container" style="justify-content:space-between; cursor: default">
                                <div>ID : <%# Eval("ReportID") %></div>
                                <div class="report-count-container" style="">
                                    <%# Eval("ReportReason") %>
                                </div>
                                <asp:Button ID="ResolveButton" CssClass="resolve-btn" runat="server" Text="Resolve" CommandArgument='<%# Eval("ReportID") %>' OnClick="ResolveButton_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
