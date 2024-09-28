<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/AdminNavbar.Master" AutoEventWireup="true" CodeBehind="AdminProgramDetail.aspx.cs" Inherits="CareYou.Views.AdminProgramDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/paymentstyle.css" rel="stylesheet" />
    <link href="../Style/editprogramstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="page-container">
            <div class="box-container">
                <div class="page-title" id="pageTitle" runat="server" >Verify Program</div>
                <div class="edit-container" style="padding-bottom:16.667vw;">
                    <div class="edit-topic_row">
                        <h1 class="edit-text">Program's topic</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="TopicTB" CssClass="insert-box" placeholder="Topic" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <asp:Label ID="topicErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row">
                        <h1 class="edit-text">Program's title</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="TitleTB" CssClass="insert-box" placeholder="Title" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <asp:Label ID="titleErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row" id="nameCtn" runat="server">
                        <h1 class="edit-text">Name</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="NameTB" CssClass="insert-box" placeholder="Name" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <asp:Label ID="nameErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row" id="beneficiaryCtn" runat="server">
                        <h1 class="edit-text">Beneficiary</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="BeneficiaryTB" CssClass="insert-box" placeholder="Beneficiary" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <asp:Label ID="benefeciaryErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-description_row">
                        <h1 class="edit-text-desc">Description</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="descTB" CssClass="insert-box-big" placeholder="Description" Enabled="false" TextMode="MultiLine" runat="server" Style="resize: none"></asp:TextBox>
                    </div>
                    <asp:Label ID="descErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row" id="typeCtn" runat="server">
                        <h1 class="edit-text">Fundraiser Type</h1>
                        <h1 class="edit-text colon">:</h1>
                        <div class="dropdown-container">
                            <asp:DropDownList ID="TypeDDL" runat="server" CssClass="dropdownlist" Enabled="false">
                                <asp:ListItem Value="social" >Social</asp:ListItem>
                                <asp:ListItem Value="project" >Project/Business</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:Label ID="typeErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-program_row" id="locCtn" runat="server">
                        <h1 class="edit-text">Location</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="LocTB" CssClass="insert-box" placeholder="Location" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <asp:Label ID="locErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-target_row">
                        <h1 class="edit-text">Target donation</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="targetTb" CssClass="insert-box" Enabled="false" placeholder="Target" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                    <asp:Label ID="TargetErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-deadline_row">
                        <h1 class="edit-text">Deadline date</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:TextBox ID="dateTb" CssClass="date-box" placeholder="Date" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <asp:Label ID="DeadlineErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-image_row">
                        <h1 class="edit-text">Image</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="imageboxLb" runat="server" CssClass="insert-box" Enabled="false" Text="Insert Image" accept=".png, .jpg, .jpeg"></asp:Label>
                    </div>
                    <asp:Label ID="ImageErrorLbl" CssClass="error-text" runat="server"></asp:Label>

                    <div class="edit-image_row" id="idCardCtn" runat="server">
                        <h1 class="edit-text">National Identity Card (KTP)</h1>
                        <h1 class="edit-text colon">:</h1>
                        <asp:Label ID="idImageBoxLb" runat="server" Enabled="false" CssClass="insert-box" Text="Insert National Identity Card" accept=".png, .jpg, .jpeg"></asp:Label>
                        
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
