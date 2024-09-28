<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="ProgramDetail.aspx.cs" Inherits="CareYou.Views.ProgramDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/programdetailstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="program-detail">
        <% if (reportClicked)
            { %>
        <div id="reportPopup" class="modal">
            <div class="modal-content">
                <div class="report-flexbox">
                    <h1 class="report-title">Report Fundraiser</h1>
                    <h1 class="report-desc">Please give us a reason on why you want to report this program.</h1>
                    <div class="report-checkbox-flexbox">
                        <div class="checkbox-button-content">
                            <asp:CheckBox ID="ScamCB" runat="server" />
                            <h1 class="checkbox-text">Scam Program</h1>
                        </div>
                        <div class="checkbox-button-content">
                            <asp:CheckBox ID="FraudCB" runat="server" />
                            <h1 class="checkbox-text">Fraud Program</h1>
                        </div>
                        <div class="checkbox-button-content">
                            <asp:CheckBox ID="ThirdpartyCB" runat="server" />
                            <h1 class="checkbox-text">Thirdparty Beneficiary</h1>
                        </div>
                        <div class="others-flexbox">
                            <div class="checkbox-button-content">
                                <asp:CheckBox ID="OtherCB" runat="server" onchange="toggleOtherReasonTextBox()"/>
                                <h1 class="checkbox-text">Others</h1>
                            </div>
                            <asp:TextBox ID="OtherReasonTB" TextMode="MultiLine" CssClass="reason-textbox" Style="resize: none" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="errorLbl" runat="server" CssClass="error-text"></asp:Label>
                    </div>
                </div>
                <asp:Button ID="SubmitBtn" CssClass="report-submit-btn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />
            </div>
        </div>



        <% } %>
        <% if (reportSubmitted)
            { %>
        <div id="reportPopup1" class="modal">
            <div class="modal-content1">
                <div class="report-flexbox">
                    <h1 class="report-title">Report Fundraiser</h1>
                    <h1 class="report-submitted-desc">Thank you for reporting. Your feedback helps us keep the platform safe.</h1>
                </div>
            </div>
        </div>



        <% } %>
        <asp:Label CssClass="title" ID="ProgramTitleLbl" runat="server"></asp:Label>
        <div class="program-detail-flexbox">
            <div class="program-detail-content">

                <asp:Image ID="ProgramImage" CssClass="program-image" runat="server" />
                <div class="fundraiser-flexbox">
                    <div class="fundraiser">
                        <asp:Image ID="FundraiserImage" CssClass="profile-image" runat="server" alt="alt text" />
                        <div class="fundraiser-detail-flexbox">
                            <asp:Label CssClass="profile-text" ID="FundraiserName" runat="server"></asp:Label>
                            <h2 class="profile-text bold">Organizer</h2>
                        </div>
                    </div>
                    <div class="fundraiser">
                        <img class="profile-image" src="/Assets/Profiles/ProfileDefault.png" alt="alt text" />
                        <div class="fundraiser-detail-flexbox">
                            <asp:Label CssClass="profile-text" ID="BeneficiaryName" runat="server"></asp:Label>
                            <h2 class="profile-text bold">Beneficiary</h2>
                        </div>
                    </div>
                </div>
                <div class="desc-container">
                    <div class="desc-flexbox">
                        <div class="verified-image">
                            <div class="verified-image-flexbox">
                                <img class="verified-image-png" src="/Assets/ProgramDetail/verified.png" alt="alt text" />
                                <h2 class="verified-text">Donation Verified</h2>
                            </div>
                        </div>
                        <hr class="line" size="1" />
                        <asp:Label CssClass="desc" ID="ProgramDescLbl" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="comment-container">
                    <div class="comment-flexbox">
                        <h1 class="comment-title">Supporting words</h1>
                        <hr class="line" size="1" />
                        <div class="comment-content-flexbox">
                            <asp:Repeater ID="CommentRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="comment-content-container">
                                        <img class="profile-image1" src='/Assets/Profiles/<%# Eval("ProfilePicture") %>' alt="alt text" />
                                        <div class="comment-text-flexbox">
                                            <h2 class="profile-text"><%# Eval("UserName") %></h2>
                                            <div class="donated-flexbox">
                                                <h2 class="donation-text">Rp <%# Eval("Amount","{0:N0}") %></h2>
                                                <h3 class="donation-time"><%# Eval("CommentTime") %></h3>
                                            </div>
                                            <h2 class="profile-text3"><%# Eval("Comment") %></h2>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <asp:Button ID="ShowMoreBtn" CssClass="btn" runat="server" Text="Show more" />
                    </div>
                </div>
                <asp:Label CssClass="profile-text4" ID="ProgramCreatedLbl" runat="server"></asp:Label>
                <hr class="line" size="1" style="width: 95%;" />
                <div class="report-btn">
                    <img class="report-img" src="/Assets/ProgramDetail/reportbtn.png" alt="alt text" />
                    <asp:LinkButton CssClass="profile-text5" ID="ReportLB" runat="server" OnClick="ReportLB_Click">Report program</asp:LinkButton>

                </div>
            </div>
            <div class="donate-container">
                <div class="donate-flexbox">
                    <div class="raised-flexbox">
                        <div class="raised-text-flexbox">
                            <asp:Label CssClass="raised-text" ID="TotalRaisedLbl" runat="server"></asp:Label>
                            <asp:Label ID="GoalLbl" runat="server" CssClass="desc1"></asp:Label>
                        </div>
                        <div class="progress-bar">
                            <div id="progressBar" runat="server" class="progress-bar-inner"></div>
                        </div>
                    </div>
                    <asp:Label ID="DonationsCountLbl" runat="server" CssClass="donation-count"></asp:Label>
                    <asp:Button ID="DonateBtn" CssClass="donate-btn" runat="server" Text="Donate Now" OnClick="DonateBtn_Click" />
                    <div class="top-donation-flexbox">
                        <div class="top-donation-title-container">
                            <asp:Label ID="TopDonationLbl" runat="server" Text="Top Donation" CssClass="top-donation-title"></asp:Label>
                        </div>
                        <div class="top-donation-content-flexbox">
                            <asp:Repeater ID="TopDonationRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="top-donater-container">
                                        <img class="profile-image1" src='/Assets/Profiles/<%# Eval("ProfilePicture") %>' alt="alt text" />
                                        <div class="top-donater-content-flexbox">
                                            <h2 class="profile-text"><%# Eval("UserName") %></h2>
                                            <div class="donated-flexbox1">
                                                <h2 class="donation-text">Rp <%# Eval("Amount","{0:N0}") %></h2>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <button class="btn1">Share</button>
                </div>
            </div>
        </div>

    </section>
    <script>
        // Get the modal and modal content elements
        var modal = document.getElementById("reportPopup");
        var modal1 = document.getElementById("reportPopup1");
        var modalContent = document.querySelector(".modal-content");
        var modalContent1 = document.querySelector(".modal-content1");

        // Add a click event listener to the document
        document.addEventListener("click", function (event) {
            // Check if the clicked element is outside the modal content
            if (event.target !== modalContent && modalContent != null && !modalContent.contains(event.target)) {
                // Close the popup
                modal.style.display = "none";
            } else if (event.target !== modalContent1 && modalContent1 != null && !modalContent1.contains(event.target)) {
                modal1.style.display = "none";
            }
        });

        function toggleOtherReasonTextBox() {
            var otherCB = document.getElementById('<%= OtherCB.ClientID %>');
            var otherReasonTB = document.getElementById('<%= OtherReasonTB.ClientID %>');

            if (otherCB.checked) {
                otherReasonTB.disabled = false;
            } else {
                otherReasonTB.disabled = true;
            }
        }
    </script>
</asp:Content>
