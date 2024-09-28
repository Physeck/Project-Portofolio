<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="CareYou.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function triggerFileInput() {
            document.getElementById('<%= FileUploadControl.ClientID %>').click();
            if (!fileInput.disabled) {
                fileInput.click();
            }
        }

        function previewProfilePic(input) {
            if (input.files && input.files[0]) {
                var file = input.files[0];
                var validImageTypes = ["image/gif", "image/jpeg", "image/png", "image/webp"];
                if (validImageTypes.includes(file.type)) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        document.getElementById('ProfilePic').src = e.target.result;
                    };
                    reader.readAsDataURL(file);
                    document.getElementById('<%= UploadButton.ClientID %>').click(); // Automatically submit the form
                } else {
                    alert("Please select a valid image file (gif, jpeg, png, webp).");
                    input.value = ""; // Clear the input
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Style/Styling.css" rel="stylesheet" />

    <div class="background"></div>
    
    <div class="profileContainer">
        
        <div class="detailProfileContainer">
            
            <div class="verified-image" id="uPLogo" runat="server"  >
                <div class="verified-image-flexbox">
                    <img class="verified-image-png" src="/Assets/ProgramDetail/verified.png" alt="alt text" />
                    <h2 class="verified-text">Organization Verified</h2>
                </div>
                
            </div>
            
            <div class="detailPP">
                <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="file-input" OnChange="previewProfilePic(this)" />
                <img id="uPPp"  runat="server" class="uPPp" onclick="triggerFileInput()"/>
                <asp:Label ID="uploadStatusLabel" CssClass="errorlblUp" runat="server" Text="" />
                <asp:Button ID="UploadButton" runat="server" Text="" OnClick="UploadProfilePic" Style="display: none;" />
                <div class="detailDataPP">
                    <div id="showpp" runat="server">
                        <div class="PPName">
                            <%= curr.UserName %>
                        </div>

                        <div class="PPEmail">
                            <%= curr.UserEmail %>
                        </div>

                        <asp:Button ID="UPBtn" class="UPBtn" runat="server" Text="Update Profile" OnClick="UPBtn_Click" />
                    </div>

                    <div id="updatePP" runat="server">
                        <div class="PPNameTBC">
                            <asp:TextBox ID="PPNameTB" class="PPNameTB" runat="server"></asp:TextBox>
                            <div>
                                <asp:Label ID="eNup" runat="server" class="errorlblUp" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="PPEmailTBC">
                            <asp:TextBox ID="PPEmailTB" class="PPEmailTB" runat="server"></asp:TextBox>
                            <div>
                                <asp:Label ID="eEup" runat="server" class="errorlblUp" Text=""></asp:Label>
                            </div>
                        </div>

                        <div id="UPPass" runat="server">
                             <div class="PPPassTBC">
                                 <asp:TextBox ID="PPPassTB" TextMode="Password" placeholder="Password" class="PPPassTB" runat="server"></asp:TextBox>
                                 <div>
                                     <asp:Label ID="ePup" runat="server" class="errorlblUp" Text=""></asp:Label>
                                 </div>
                             </div>

                             <div class="PPCPassTBC">
                                <asp:TextBox ID="PPCPassTB" TextMode="Password" placeholder="Confirm Password" class="PPCPassTB" runat="server"></asp:TextBox>
                                 <div>
                                    <asp:Label ID="eCPup" runat="server" class="errorlblUp" Text=""></asp:Label>
                                 </div>
                             </div>
                        </div>
                   

                        <div class="changePassUP" runat="server">
                            <asp:LinkButton ID="changePassU" class="changePassU" OnClick="changePassU_Click" runat="server">Change Password</asp:LinkButton>
                            <asp:LinkButton ID="cancelChangeUP" class="changePassU" OnClick="cancelChangeUP_Click" runat="server">Cancel</asp:LinkButton>
                        </div>

                        <asp:Button ID="updtP2" class="UPBtn" runat="server" Text="Update Profile" OnClick="updtP2_Click" />
                    </div>
                

                    <div class="regcom">
                        <asp:HyperLink ID="regComlnk" class="regComlnk" runat="server" NavigateUrl="~/Views/OrganizationForm.aspx">Register as Organization</asp:HyperLink>
                    </div>
                

                    <div class="uPdetailInfoContainer">

                        <div class="totalDonation">
                            <asp:Label ID="tDLblUP" runat="server" Text="Total Donation"></asp:Label>
                            <div class="totDonation">
                                <%= totalDonate %>
                            </div>
                        </div>

                        <div class="rank">
                            <asp:Label ID="rLbl" runat="server" Text="Rank"></asp:Label>
                            <div class="uPrank">
                                <%= rank %>
                            </div>
                        </div>

                        <div class="joinDate">
                            <asp:Label ID="jDLbl" runat="server" Text="Join Date"></asp:Label>
                            <div class="uPJD">
                                <%= curr.JoinDate.Year %>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="uPlogoutContainer">
                <asp:Button ID="uPLogoutBtn" class="uPLogoutBtn" runat="server" Text="Logout" OnClick="uPLogoutBtn_Click" />
            </div>
        </div>

        <div class="uPBadgeContainer">
            <div class="uPBadgeHeader">
                <asp:Label ID="uPBadgeLbl" class="uPBadgeLbl" runat="server" Text="Badge"></asp:Label>
                <div class="uPTotBadge">
                    <div class="uPtotLbl">
                        Total:
                    </div>
                     <%= badgeOfUser.totalBadge %>
                </div>
            </div>

            <asp:DataList ID="uPBadges" class="uPBadges" runat="server" RepeatColumns="4">
                <ItemTemplate>
                    <img id="uPBadge" src="../Assets/Badges/<%# Eval("BadgeImage") %>"  class="uPBadge" />
                </ItemTemplate>
            </asp:DataList>

            <asp:Label ID="noBadgeLbl" class="noBadgeLbl" runat="server" Text="No Badge"></asp:Label>
        </div>

    </div>
</asp:Content>