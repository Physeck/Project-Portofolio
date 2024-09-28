<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="EditProgramDetails.aspx.cs" Inherits="CareYou.Views.EditProgramDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/paymentstyle.css" rel="stylesheet" />
    <link href="../Style/editprogramstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="page-container">
            <div class="box-container">
                <div class="edit-flex_col">

                    <asp:ImageButton ID="BackBtn" runat="server" CssClass="method-img" ImageUrl="/Assets/TransactionMethod/back-btn.png" OnClick="BackBtn_Click" />
                    <h1 class="edit-text-header">Edit Your Program</h1>
                </div>
                <div class="edit-container">
                    <div class="edit-topic_row">
                        <h1 class="edit-text">Edit your programs topic</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="TopicLb" CssClass="topic-box" runat="server" Text="Label"></asp:Label>
                        <div class="img-box" style="--src: url(/Assets/ProgramDetail/locked.png)"></div>

                    </div>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Edit your program's title</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="TitleLb" CssClass="topic-box" runat="server" Text="Label"></asp:Label>
                        <div class="img-box" style="--src: url(/Assets/ProgramDetail/locked.png)">
                        </div>
                    </div>


                    <div class="edit-description_row">
                        <h1 class="edit-text-desc">Edit description</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="descTb" CssClass="insert-box-big" placeholder="Description" TextMode="MultiLine" runat="server" Style="resize: none"></asp:TextBox>

                    </div>
                    <asp:Label ID="descErrorLbl" CssClass="error-text" runat="server"></asp:Label>
                    <div class="edit-target_row">
                        <h1 class="edit-text">Edit target donation</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="targetTb" CssClass="insert-box" placeholder="Target" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                    <asp:Label ID="TargetErrorLbl" CssClass="error-text" runat="server"></asp:Label>
                    <div class="edit-deadline_row">
                        <h1 class="edit-text">Edit deadline date</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="dateTb" CssClass="date-box" placeholder="Date" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="DeadlineErrorLbl" CssClass="error-text" runat="server"></asp:Label>
                    <div class="edit-image_row">
                        <h1 class="edit-text">Update image</h1>
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
                    <asp:Label ID="ConfirmErrorLbl" CssClass="error-text" style="margin-left: 0" runat="server"></asp:Label>
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
