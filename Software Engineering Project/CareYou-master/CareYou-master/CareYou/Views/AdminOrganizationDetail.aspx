<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/AdminNavbar.Master" AutoEventWireup="true" CodeBehind="AdminOrganizationDetail.aspx.cs" Inherits="CareYou.Views.AdminOrganizationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/paymentstyle.css" rel="stylesheet" />
    <link href="../Style/editprogramstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="page-container">
            <div class="box-container">
                <div class="page-title">Verify Organization</div>
                <div class="edit-container" style="padding-bottom: 16.667vw;">
                    <div class="edit-topic_row">
                        <h1 class="edit-text">Organization's Name</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="NameTB" Enabled="false" CssClass="insert-box" placeholder="Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's Type</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="TypeTB" CssClass="insert-box" Enabled="false" placeholder="Organization’s type (e.g., International Government Agency)" runat="server"></asp:TextBox>
                    </div>
                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's Location</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="LocTB" CssClass="insert-box" Enabled="false" placeholder="Location" runat="server"></asp:TextBox>
                    </div>
                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's phone number</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="NumberTB" CssClass="insert-box" Enabled="false" placeholder="Phone Number" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's email</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="EmailTB" CssClass="insert-box" Enabled="false" placeholder="Email" runat="server"></asp:TextBox>
                    </div>
                    <div class="edit-target_row">
                        <h1 class="edit-text">Organization's website</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="WebsiteTB" CssClass="insert-box" Enabled="false" placeholder="Website (if any)" runat="server"></asp:TextBox>
                    </div>
                    <div class="edit-deadline_row">
                        <h1 class="edit-text">Organization's leader name</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="LeaderTB" CssClass="insert-box" Enabled="false" placeholder="Leader's Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="edit-image_row">
                        <h1 class="edit-text">Organization's registration certificate</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="imageboxLb" runat="server" CssClass="insert-box" Enabled="false" Text="Insert Image" accept=".png, .jpg, .jpeg"></asp:Label>
                    </div>
                    <div class="btns-container">
                        <asp:Button ID="RejectBtn" CssClass="reject-btn" Text="Reject" runat="server" OnClick="RejectBtn_Click" />
                        <asp:Button ID="AccBtn" CssClass="send-request-btn" Text="Accept" runat="server" OnClick="AccBtn_Click" />
                    </div>

                </div>
            </div>
        </div>
    </section>
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>

