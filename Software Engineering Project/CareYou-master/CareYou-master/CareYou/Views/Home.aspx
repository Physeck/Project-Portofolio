<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CareYou.Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/homepagestyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home">
        <div class="top" style="--src: url(/Assets/HomePage/home-background.png)">
            <div class="title_container">
                <div class="title_flexbox">
                    <h1 class="app-title_box">
                        <span class="app-title"><span class="app-title_span0">Care</span><span class="app-title_span1">You</span></span>
                    </h1>
                    <h1 class="tagline_box">
                        <span class="tagline"><span class="tagline_span0">Join Us</span><span class="tagline_span1">
                            <br />
                            in Making Dreams a Reality</span></span>
                    </h1>
                    <asp:Button CssClass="fundraise-btn" ID="FundraiseBtn" runat="server" Text="Start Fundraising" OnClick="FundraiseBtn_Click"/>
                </div>
            </div>
        </div>
        <div class="bottom">
            <div class="discover-flexbox">
                <h1 class="discover-title">Discover</h1>
                <div class="programs-container">
                    <h1 class="section-title">Recommended Social Activities</h1>
                    <div class="card-container">
                        <asp:Repeater ID="SocialProgramRepeater" runat="server">
                            <ItemTemplate>
                                <div class='program-card-container<%# Container.ItemIndex == 0 ? " wide" : "" %>'>
                                    <div class='program-container<%# Container.ItemIndex == 0 ? " wide" : "" %>' style='--src: url(/Assets/Program/<%# Eval("ProgramImage") %>)' onclick="location.href='/Views/ProgramDetail.aspx?id=<%# Eval("ProgramID") %>'">
                                        <div class="program-container-content">
                                            <div class='program-container-content-flexbox<%# Container.ItemIndex == 0 ? " wide" : "" %>'>
                                                <h1 class='program-title<%# Container.ItemIndex == 0 ? " wide" : "" %>'><%# Eval("ProgramTitle") %></h1>
                                                <h3 class='fundraiser' <%# Container.ItemIndex == 0 ? " wide" : "" %>><%# Eval("FundraiserName") %></h3>
                                                <h2 class='raised<%# Container.ItemIndex == 0 ? " wide" : "" %>'>Rp <%# Eval("ProgramRaised", "{0:N0}") %> raised</h2>
                                                <div class='progress-bar<%# Container.ItemIndex == 0 ? " wide" : "" %>'>
                                                    <div class="progress-bar-inner" style="width: <%# Eval("Progress") %>%"></div>
                                                </div>
                                                <div class="brief-description"><%# Eval("ProgramDesc") %></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="programs-container">
                    <h1 class="section-title">Recommended Projects</h1>
                    <div class="card-container">
                        <asp:Repeater ID="ProjectProgramRepeater" runat="server">
                            <ItemTemplate>
                                <div class='program-card-container<%# Container.ItemIndex == 0 ? " wide" : "" %>'>
                                    <div class='program-container<%# Container.ItemIndex == 0 ? " wide" : "" %>' style='--src: url(/Assets/Program/<%# Eval("ProgramImage") %>)' onclick="location.href='/Views/ProgramDetail?id=<%# Eval("ProgramID") %>'">
                                        <div class="program-container-content">
                                            <div class='program-container-content-flexbox<%# Container.ItemIndex == 0 ? " wide" : "" %>'>
                                                <h1 class='program-title<%# Container.ItemIndex == 0 ? " wide" : "" %>'><%# Eval("ProgramTitle") %></h1>
                                                <h3 class='fundraiser' <%# Container.ItemIndex == 0 ? " wide" : "" %>><%# Eval("FundraiserName") %></h3>
                                                <h2 class='raised<%# Container.ItemIndex == 0 ? " wide" : "" %>'>Rp <%# Eval("ProgramRaised", "{0:N0}") %> raised</h2>
                                                <div class='progress-bar<%# Container.ItemIndex == 0 ? " wide" : "" %>'>
                                                    <div class="progress-bar-inner" style="width: <%# Eval("Progress") %>%"></div>
                                                </div>
                                                <div class="brief-description"><%# Eval("ProgramDesc") %></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <asp:Button CssClass="viewmore-btn" ID="ViewMoreBtn" runat="server" Text="View More" OnClick="ViewMoreBtn_Click"/>
            </div>
        </div>
    </section>
</asp:Content>
