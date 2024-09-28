<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/AdminNavbar.Master" AutoEventWireup="true" CodeBehind="UserReportPage.aspx.cs" Inherits="CareYou.Views.UserReportPage" %>

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
                    <asp:Repeater ID="PendingRepeater" runat="server">
                        <ItemTemplate>
                            <div class="program-card-container" style="justify-content:space-between;" onclick="location.href='/Views/AdminProgramReport.aspx?id=<%# Eval("ProgramID") %>'">
                                <%# Eval("ProgramTitle") %>
                                <div class="report-count-container">
                                    <asp:Image class="userProfile" ID="UserReportProfile" runat="server" ImageUrl="~/assets/UserReportProfile.svg" />
                                    <div> : </div>
                                    <%# Eval("ReportCount") %>
                                </div>
                                
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
