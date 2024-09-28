<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="FundraisePage.aspx.cs" Inherits="CareYou.Views.FundraisePage" %>

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
    <section class="fundraise-section">
        <div class="fundraise-page-flexbox">
            <div class="create-program-container" id="createProgramBox" runat="server">
                <div class="create-program-flexbox">
                    <h1 class="create-program-text">Create your own program here!</h1>
                    <div class="fundraise-button-container">
                        <div class="fundraise-img-flexbox">
                            <img class="fundraise-img" src="/Assets/Search/fundraise-plus.png" alt="alt text" /><img class="fundraise-img small" src="/Assets/Search/fundraise-plus.png" alt="alt text" />
                        </div>
                        <asp:Button ID="FundraiseBtn" CssClass="fundraise-btn" runat="server" Text="Start Fundraising" OnClick="FundraiseBtn_Click" />
                    </div>
                </div>
            </div>
            <asp:Label ID="TitleLbl" CssClass="your-program-title" runat="server" Text="Your Program(s)" ></asp:Label>
            <div class="search-bar-container">
                <asp:TextBox ID="SearchBar" placeholder="Search program here" CssClass="search-bar" runat="server"></asp:TextBox>
                <div class="search-flexrow">
                    <asp:ImageButton ID="SearchBtn" runat="server" CssClass="search-btn" ImageUrl="~/Assets/Search/search-btn.png" OnClick="SearchBtn_Click" />
                    <asp:DropDownList ID="FilterDDL" runat="server" CssClass="hidden-dropdown" AutoPostBack="True" OnSelectedIndexChanged="FilterDDL_SelectedIndexChanged">
                        <asp:ListItem Text="Social Activity" Value="social"></asp:ListItem>
                        <asp:ListItem Text="Projects/Business" Value="project"></asp:ListItem>
                        <asp:ListItem Text="None" Value="none"></asp:ListItem>
                    </asp:DropDownList>
                    <label for="<%= FilterDDL.ClientID %>" class="ddl">
                    </label>
                </div>
            </div>
            <div class="program-list-container" style="margin-top: 4.219vw;">
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
            </div>
            <div id="pendingProgramContainer" runat="server">
                <h1 class="your-program-title">Your Pending Program(s)</h1>
                <div class="program-list-container">
                    <div class="card-container">
                        <asp:Repeater ID="PendingRepeater" runat="server">
                            <ItemTemplate>
                                <div class="pending-card-container">
                                    <div class="image-container" style='cursor: default; --src: url(/Assets/Program/<%# Eval("ProgramImage") %>)'></div>
                                    <div class="program-container" style="justify-content: flex-start; align-items: center; cursor: default;">
                                        <div class="program-container-content">
                                            <h1 class="program-title" style="color: white"><%# Eval("ProgramTitle") %></h1>
                                            <h3 class="fundraiser" style="color: white"><%# Eval("FundraiserName") %></h3>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<%--    <div class="fundraisepage">
            <div class="createprogram">
                <asp:Label ID="createT" runat="server" Text="Create your own program here!"></asp:Label>
                <asp:Button ID="startfundraisingbtn" runat="server" Text="Start Fundraising" Onclick="startfundraisingbtn_Click"/>
            </div>
            <br class="Apple-interchange-newline">
            <asp:Label class="textTitle" ID="fundraiseT" runat="server" Text="Your program(s)"></asp:Label>
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
                            -- blm --
                        </div>
                        <div class="detailprogramP">
                            <asp:Button class="detailprogrambtn" ID="detailprogram" runat="server" Text="Detail Program" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="pendingC">
                <asp:Label class="textTitle" ID="pendingprogramT" runat="server" Text="Your Pending Program(s)"></asp:Label>
                    <div class="pendingprogramC">
                        <asp:Image class="programI" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQVua1higrnAKxEJ8ufI9iIJ8Y3_-DGUBEoA&s" runat="server" />
                        <div class="donatecontain2">
                            <div class="donatecontain1">
                                <asp:Label class="donateT" id="pendingT" runat="server" Text="Help with 2$ meal for hungry Orphans in Switzerland"></asp:Label>
                                <asp:Label class="donateD" id="pendingD" runat="server" Text="10 May 2024"></asp:Label>
                            </div>
                            <asp:Label class="donateN" id="pendingN" runat="server" Text="John Doe"></asp:Label>
                            <div class="progressbar">
                                -- blm --
                            </div>
                            <div class="detailprogramP">
                                <asp:Button class="detailprogrambtn" ID="pendingdetailprogram" runat="server" Text="Detail Program" />
                            </div>
                        </div>
                    </div>
            </div>
        </div>  --%>   
