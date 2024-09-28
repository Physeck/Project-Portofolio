<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="CreateProgram.aspx.cs" Inherits="CareYou.Views.CreateProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/paymentstyle.css" rel="stylesheet" />
    <link href="../Style/editprogramstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="page-container">
            <div class="box-container">
                <div class="page-title">Create Your Program</div>
                <div class="edit-container">
                    <h1 class="form-title">Please input these fields.</h1>
                    <div class="edit-topic_row">
                        <h1 class="edit-text">Your program's topic</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="TopicTB" CssClass="insert-box" placeholder="Topic" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="topicErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Edit your program's title</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="TitleTB" CssClass="insert-box" placeholder="Title" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="titleErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Your name</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="NameTB" CssClass="insert-box" placeholder="Name" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="nameErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Beneficiary</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="BeneficiaryTB" CssClass="insert-box" placeholder="Beneficiary" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="benefeciaryErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-description_row">
                        <h1 class="edit-text-desc">Edit description</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="descTB" CssClass="insert-box-big" placeholder="Description" TextMode="MultiLine" runat="server" Style="resize: none"></asp:TextBox>
                    </div>
                    <asp:Label ID="descErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Fundraiser Type</h1>
                        <h1 class="edit-text colon">:</h1>
                        <div class="dropdown-container">
                            <img class="dropdown-png" src="/Assets/Login-Register/ReturnToSignin.png" />
                            <asp:DropDownList ID="TypeDDL" runat="server" CssClass="dropdownlist">
                                <asp:ListItem Value="social" >Social</asp:ListItem>
                                <asp:ListItem Value="project" >Project/Business</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:Label ID="typeErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Location</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="LocTB" CssClass="insert-box" placeholder="Location" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="locErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-target_row">
                        <h1 class="edit-text">Target donation</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="targetTb" CssClass="insert-box" placeholder="Target" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                    <asp:Label ID="TargetErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-deadline_row">
                        <h1 class="edit-text">Deadline date</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="dateTb" CssClass="date-box" placeholder="Date" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="DeadlineErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-image_row">
                        <h1 class="edit-text">Insert image</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="imageboxLb" runat="server" CssClass="insert-box" Text="Insert Image" accept=".png, .jpg, .jpeg"></asp:Label>
                        <asp:FileUpload ID="InsertImage" runat="server" />
                        <label for="<%= InsertImage.ClientID %>" class="insert-image">
                        </label>
                    </div>
                    <asp:Label ID="ImageErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-image_row">
                        <h1 class="edit-text">Insert your National Identity Card (KTP)</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="idImageBoxLb" runat="server" CssClass="insert-box" Text="Insert National Identity Card" accept=".png, .jpg, .jpeg"></asp:Label>
                        <asp:FileUpload ID="InsertID" runat="server" />
                        <label for="<%= InsertID.ClientID %>" class="insert-image">
                        </label>
                    </div>
                    <asp:Label ID="IDErrorLbl" CssClass="error-text" runat="server"></asp:Label>

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
        document.addEventListener('DOMContentLoaded', function () {
            var fileUpload = document.getElementById('<%= InsertID.ClientID %>');
            var errorLabel = document.getElementById('<%= IDErrorLbl.ClientID %>');
            var imagebox = document.getElementById('<%= idImageBoxLb.ClientID %>');

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
