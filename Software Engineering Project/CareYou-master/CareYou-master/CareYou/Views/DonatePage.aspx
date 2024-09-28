<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="DonatePage.aspx.cs" Inherits="CareYou.Views.DonatePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="../Style/contentstyle.css" rel="stylesheet" /> --%>
    <link href="../Style/donatestyle.css" rel="stylesheet" />
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var dropdown = document.getElementById('<%= FilterDDL.ClientID %>');
            var icon = document.querySelector('.ddl');
            var customDropdown = document.createElement('div');
            customDropdown.classList.add('custom-dropdown');

            // Create a custom dropdown menu
            var dropdownContent = document.createElement('div');
            dropdownContent.classList.add('custom-dropdown-content');

            for (var i = 0; i < dropdown.options.length; i++) {
                var option = dropdown.options[i];
                var link = document.createElement('a');
                link.href = '#';
                link.textContent = option.text;
                link.dataset.value = option.value;
                link.addEventListener('click', function (event) {
                    event.preventDefault();
                    dropdown.value = event.target.dataset.value;
                    dropdown.dispatchEvent(new Event('change'));
                    dropdownContent.classList.remove('show');

                    // Trigger postback
                    __doPostBack('<%= FilterDDL.ClientID %>', '');
                });
                dropdownContent.appendChild(link);
            }

            customDropdown.appendChild(icon);
            customDropdown.appendChild(dropdownContent);
            dropdown.parentNode.insertBefore(customDropdown, dropdown);

            icon.addEventListener('click', function (event) {
                event.stopPropagation();
                dropdownContent.classList.toggle('show');
            });

            document.addEventListener('click', function (event) {
                if (event.target !== dropdown && !customDropdown.contains(event.target)) {
                    dropdownContent.classList.remove('show');
                }
            });
            var searchBar = document.getElementById('<%= SearchBar.ClientID %>');
            searchBar.addEventListener('keydown', function (event) {
                if (event.key === 'Enter') {
                    event.preventDefault();
                    document.getElementById('<%= SearchBtn.ClientID %>').click();
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="donate-section">
        <div class="donate-page-flexbox">
            <div class="search-bar-container">
                <asp:TextBox ID="SearchBar" placeholder="Search program here" CssClass="search-bar" runat="server"></asp:TextBox>
                <div class="search-flexrow">
                    <asp:ImageButton ID="SearchBtn" runat="server" CssClass="search-btn" ImageUrl="~/Assets/Search/search-btn.png" OnClick="SearchBtn_Click" />
                    <asp:DropDownList ID="FilterDDL" runat="server" CssClass="hidden-dropdown" AutoPostBack="True" OnSelectedIndexChanged="FilterDDL_SelectedIndexChanged">
                        <asp:ListItem Text="None" Value="none"></asp:ListItem>
                        <asp:ListItem Text="Social Activity" Value="social"></asp:ListItem>
                        <asp:ListItem Text="Projects/Business" Value="project"></asp:ListItem>

                    </asp:DropDownList>
                    <label for="<%= FilterDDL.ClientID %>" class="ddl">
                    </label>
                </div>
            </div>
            <div class="program-list-container">
                <div class="card-container">
                    <asp:Repeater ID="ProgramRepeater" runat="server">
                        <ItemTemplate>
                            <div class="program-card-container" onclick="location.href='/Views/ProgramDetail.aspx?id=<%# Eval("ProgramID") %>'">
                                <h2 class="date"><%# Eval("DateCreated") %></h2>
                                <div class="image-container" style='--src: url(/Assets/Program/<%# Eval("ProgramImage") %>)'></div>
                                <div class="program-container">
                                    <div class="program-container-content">
                                        <h1 class="program-title"><%# Eval("ProgramTitle") %></h1>
                                        <h3 class="fundraiser"><%# Eval("FundraiserName") %></h3>
                                    </div>
                                    <div class="raised-container">
                                        <h2 class="raised">Rp <%# Eval("ProgramRaised", "{0:N0}") %> raised</h2>
                                        <div class="progress-bar">
                                            <div class="progress-bar-inner" style="width: <%# Eval("Progress") %>%">
                                                <div class="progress-text"><%# Eval("Progress") %>%</div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Button ID="ViewMoreBtn" CssClass="btn" runat="server" Text="View more" OnClick="ViewMoreBtn_Click" />
            </div>
        </div>
    </section>
    <%-- <div class="donatepage">
        <div class="searchbar">
            <div id="searchinputT">
                <asp:TextBox ID="searchprogram" runat="server" placeholder="Search Program Here"></asp:TextBox>
            </div>
            <div id="searchI">
                <asp:Image ID="magnifyingglass" src="https://uxwing.com/wp-content/themes/uxwing/download/user-interface/search-icon.png" runat="server" />
                <asp:Image ID="filter" src="https://www.svgrepo.com/show/327767/filter-circle.svg" runat="server" />
            </div>
        </div>

        <div class="donateC">
            <div class="donateprogramC">
                <asp:Image class="programI" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQVua1higrnAKxEJ8ufI9iIJ8Y3_-DGUBEoA&s" runat="server" />
                <div class="donatecontain2">
                    <div class="donatecontain1">
                        <asp:Label class="donateT" runat="server" Text="Help with 2$ meal for hungry Orphans in Switzerland"></asp:Label>
                        <asp:Label class="donateD" runat="server" Text="10 May 2024"></asp:Label>
                    </div>
                    <asp:Label class="donateN" runat="server" Text="John Doe"></asp:Label>
                    <div class="progressbar">
                        belum
                    </div>
                    <div class="detailprogramP">
                        <asp:Button class="detailprogrambtn" ID="detailprogram" runat="server" Text="Detail Program" />
                    </div>
                </div>
            </div>
        </div>
        <asp:Button CssClass="detailprogrambtn" ID="viewmore" runat="server" Text="View More" OnClick="viewmore_Click" />
    </div> --%>
</asp:Content>
