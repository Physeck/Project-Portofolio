<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CareYou.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/loginstyle.css" rel="stylesheet" />
</head>
<body style="margin: 0">
    <form id="form1" runat="server">


        <div class="loginPage-container">
            <div class="login-page-left-flexbox">
                <h1 class="app-title-container">
                    <span class="app-title"><span class="app-title_span0">Care</span><span class="app-title_span1">You</span></span>
                </h1>
                <h1 class="welcome-text">Welcome back !</h1>
                <h1 class="sign-in-text">Sign in to CareYou</h1>
            </div>

            <div class="loginPagebg-container" style="--src: url(/Assets/Login-Register/Rectangle-RegLogin.png)">
                <div class="loginPage-form">
                    <div class="Lgflex_col">

                        <div class="loginPage-form-title">
                            <h1 class="acc-det">Account Details</h1>
                        </div>

                        <div class="email-container">
                            <asp:TextBox ID="emailTb" CssClass="emailBox" TextMode="Email" runat="server" placeholder="E-mail Address"></asp:TextBox>
                        </div>
                         <asp:Label ID="emailErrorLbl" CssClass="error-text" runat="server"></asp:Label>


                        <div class="pwflexRow">

                            <asp:TextBox ID="passwordTb" CssClass="passBox" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <asp:ImageButton ID="ShowPasswordIB" runat="server" CssClass="show-password" OnClick="ShowPasswordIB_Click" ImageUrl="~/Assets/Login-Register/ShowsPassword.png" />
                        </div>
                        <asp:Label ID="errorLbl" CssClass="error-text" runat="server"></asp:Label>

                        <div class="barRowforg_sign">
                            <a href="/Views/ForgotPassword.aspx" class="forgPass">Forgot Password?</a>
                            <div class="flex_rowbar">
                                <h1 class="noAcc">Don’t Have Account?</h1>
                                <a href="/Views/RegisterPage.aspx" class="forgPass">Sign Up</a>
                            </div>
                        </div>
                    </div>
                </div>
                <hr class="line" size="1" />
                <div class="bottom-container">
                    <div class="agree-flexRow">
                        <h1 class="byclick">By clicking the Sign In button below, you agree to the CareYou</h1>
                        <h1 class="tos">Terms of Service</h1>
                    </div>
                    <asp:Button ID="loginBtn" CssClass="login-btn" runat="server" OnClick="loginBtn_Click" Text="Sign In" />
                </div>

            </div>
        </div>

    </form>
</body>


</html>
