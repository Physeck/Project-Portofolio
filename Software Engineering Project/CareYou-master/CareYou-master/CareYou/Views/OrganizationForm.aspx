<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="OrganizationForm.aspx.cs" Inherits="CareYou.Views.OrganizationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/paymentstyle.css" rel="stylesheet" />
    <link href="../Style/editprogramstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="page-container">
            <div class="box-container">
                <div class="page-title">Verify Your Organization</div>
                <div class="edit-container">
                    <h1 class="form-title">Please input these fields.</h1>
                    <div class="edit-topic_row">
                        <h1 class="edit-text">Organization's Name</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="NameTB" CssClass="insert-box" placeholder="Name" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="nameErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's Type</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="TypeTB" CssClass="insert-box" placeholder="Organization’s type (e.g., International Government Agency)" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="typeErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's Location</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="LocTB" CssClass="insert-box" placeholder="Location" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="locErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's phone number</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="NumberTB" CssClass="insert-box" placeholder="Phone Number" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                    <asp:Label ID="numberErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Organization's email</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="EmailTB" CssClass="insert-box" placeholder="Email" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="emailErrorLbl" CssClass="error-text" TextMode="email" runat="server"></asp:Label>

                    <div class="edit-target_row">
                        <h1 class="edit-text">Organization's website</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="WebsiteTB" CssClass="insert-box" placeholder="Website (if any)" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="websiteErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-deadline_row">
                        <h1 class="edit-text">Organization's leader name</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="LeaderTB" CssClass="insert-box" placeholder="Leader's Name" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="leaderErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-image_row">
                        <h1 class="edit-text">Organization's registration certificate</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="imageboxLb" runat="server" CssClass="insert-box" Text="Insert Image" accept=".png, .jpg, .jpeg"></asp:Label>
                        <asp:FileUpload ID="InsertImage" runat="server" />
                        <label for="<%= InsertImage.ClientID %>" class="insert-image">
                        </label>
                    </div>
                    <asp:Label ID="ImageErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="checkbox-button-content">
                        <asp:CheckBox ID="ConfirmationCB" runat="server" />
                        <h1 class="checkbox-text">I confirm that the information provided is accurate and complete.</h1>
                    </div>
                    <asp:Label ID="ConfirmErrorLbl" CssClass="error-text" Style="margin-left: 0" runat="server"></asp:Label>
                    <asp:Button ID="sendreqBtn" CssClass="send-request-btn" Text="Send Request" runat="server" OnClick="sendreqBtn_Click" />

                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var fileUpload = document.getElementById('<%= InsertImage.ClientID %>');
            var errorLabel = document.getElementById('<%= ImageErrorLbl.ClientID %>');
            var imagebox = document.getElementById('<%= imageboxLb.ClientID %>');

            fileUpload.addEventListener('change', function (event) {
                var file = event.target.files[0];
                if (file) {
                    var fileExtension = file.name.split('.').pop().toLowerCase();
                    var allowedExtensions = ['jpg', 'jpeg', 'png'];

                    if (!allowedExtensions.includes(fileExtension)) {
                        errorLabel.innerText = "Only files with .jpg, .jpeg, or .png extensions are allowed.";
                        errorLabel.style.color = "red";
                        fileUpload.value = "";
                    } else {
                        errorLabel.innerText = "";
                        imagebox.innerText = file.name;
                    }
                }
            });
        });
</script>
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
