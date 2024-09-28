<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="CareYou.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/loginstyle.css" rel="stylesheet" />
    <link href="../Style/resetpasswordstyle.css" rel="stylesheet" />
    <link href="../Style/registerstyle.css" rel="stylesheet" />
</head>
<body style="margin: 0">
        <form id="form1" runat="server">
            <div>
                <div class="login-page-left-flexbox">
                    <h1 class="app-title-container">
                        <span class="app-title"><span class="app-title_span0">Care</span><span class="app-title_span1">You</span></span>
                    </h1>
                    <h1 class="welcome-text">Welcome to CareYou !</h1>
                    <h1 class="sign-in-text">Create an Account</h1>
                </div>


                <div class="loginPagebg-container" style="--src: url(/Assets/Login-Register/Rectangle-RegLogin.png)">
                    <div class="loginPage-form">

                        <div class="Lgflex_col">
                            <div class="loginPage-form-title">
                                <h1 class="acc-det">Account Details</h1>
                            </div>
                            <div class="name-row">
                                <div class="first-name-container">
                                    <asp:TextBox ID="fnameTb" CssClass="firstnameBox" runat="server" placeholder="First Name"></asp:TextBox>
                                </div>
                                <div class="last-name-container">
                                    <asp:TextBox ID="lnameTb" CssClass="lastnameBox" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Label ID="nameErrorLbl" runat="server" CssClass="error-text"></asp:Label>
                            <div class="email-container">
                                <asp:TextBox ID="emailTb" CssClass="emailBox" runat="server" placeholder="E-mail Address"></asp:TextBox>
                            </div>
                            <asp:Label ID="emailErrorLbl" runat="server" CssClass="error-text"></asp:Label>


                            <div class="pwflexRow">
                                <asp:TextBox ID="passwordTb" CssClass="passBox" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                <asp:ImageButton ID="ShowPasswordIB" runat="server" CssClass="show-password" OnClick="ShowPasswordIB_Click" ImageUrl="~/Assets/Login-Register/ShowsPassword.png" />
                            </div>
                            <asp:Label ID="passErrorLbl" runat="server" CssClass="error-text"></asp:Label>
                            <div class="pwflexRow">
                                <asp:TextBox ID="confpasswordTb" CssClass="passBox" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                <asp:ImageButton ID="ShowConfPasswordIb" runat="server" CssClass="show-password" OnClick="ShowConfPasswordIb_Click" ImageUrl="~/Assets/Login-Register/ShowsPassword.png" />
                            </div>
                            <asp:Label ID="ErrorLbl" runat="server" CssClass="error-text"></asp:Label>
                            <div class="barRowforg_sign">
                                <div class="flex_rowbar">
                                    <h1 class="noAcc">Already Have Account?</h1>
                                    <a href="/Views/LoginPage.aspx" class="forgPass">Sign In</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr class="line" size="1" />
                    <div class="bottom-container">
                        <div class="agree-flexRow">
                            <h1 class="byclick">By clicking the Sign Up button below, you agree to the CareYou</h1>
                            <h1 class="tos">Terms of Service</h1>
                        </div>
                        <asp:Button ID="loginBtn" CssClass="login-btn" runat="server" OnClick="loginBtn_Click" Text="Sign Up" />
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>
