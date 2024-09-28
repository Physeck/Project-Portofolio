<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CareYou.Views.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/loginstyle.css" rel="stylesheet" />
    <link href="../Style/resetpasswordstyle.css" rel="stylesheet" />

</head>
<body style="margin: 0">
        <form id="form1" runat="server">
            <div>
                <div class="reset-page-left-flexbox">
                    <h1 class="app-title-container">
                        <span class="app-title"><span class="app-title_span0">Care</span><span class="app-title_span1">You</span></span>
                    </h1>
                    <h1 class="welcome-text">Welcome to CareYou!</h1>
                    <h1 class="reset-pw-text">Reset Your Password</h1>
                </div>

                <div class="loginPagebg-container" style="--src: url(/Assets/Login-Register/Rectangle-RegLogin.png)">
                    <div class="loginPage-form">

                        <div class="Lgflex_col">

                            <div class="loginPage-form-title">
                                <h1 class="acc-det">Enter and Confirm Your New Password</h1>
                            </div>

                            <div class="email-container">
                                <asp:TextBox ID="newpasswordTb" CssClass="passBox" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                <asp:ImageButton ID="ShowNewPasswordIb" runat="server" CssClass="show-password" OnClick="ShowNewPasswordIb_Click" ImageUrl="~/Assets/Login-Register/ShowsPassword.png" />
                            </div>
                             <asp:Label ID="passErrorLbl" runat="server" CssClass="error-text"></asp:Label>
                            <div class="pwflexRow">
                                <asp:TextBox ID="confpasswordTb" CssClass="passBox" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                <asp:ImageButton ID="ShowConfPasswordIb" runat="server" CssClass="show-password" OnClick="ShowConfPasswordIb_Click" ImageUrl="~/Assets/Login-Register/ShowsPassword.png" />
                            </div>
                            <asp:Label ID="cpassErrorLbl" runat="server" CssClass="error-text"></asp:Label>
                        </div>
                    </div>
                <hr class="line" size="1" />
                </div>
                <div class="bottom-container">
                    <asp:Button ID="setpasswordBtn" CssClass="setpassword-btn" runat="server" OnClick="setpasswordBtn_Click" Text="Set Password" />
                </div>
            </div>
        </form>
    </body>
</html>
