<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/AdminNavbar.Master" AutoEventWireup="true" CodeBehind="DashboardPage.aspx.cs" Inherits="CareYou.Views.DashboardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/dashboardpagestyle.css?Version=4" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home">
        <div class="main">
            <div class="container">
                <h1 class="dashboard-title">Dashboard</h1>
                <div>
                    <div class="container-box">
                        <div class="flex-div">
                            <h1 class="title-container">Total User</h1>
                            <asp:Label CssClass="info-container" ID="UserCount" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="flex-div">
                            <h1 class="title-container">New User</h1>
                            <h1 class="title-container small">(Monthly)</h1>
                             <asp:Label CssClass="info-container" ID="NewUserCount" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="container-box">
                        <div class="flex-div">
                            <h1 class="title-container">Donations</h1>
                            <asp:Label CssClass="info-container" ID="TotalDonation" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="flex-div">
                            <h1 class="title-container">Active Programs</h1>
                            <asp:Label CssClass="info-container" ID="ActiveProgram" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
