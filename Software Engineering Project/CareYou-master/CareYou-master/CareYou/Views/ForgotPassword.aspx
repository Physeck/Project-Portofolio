<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CareYou.Views.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/loginstyle.css" rel="stylesheet" />
    <link href="../Style/forgotpwstyle.css" rel="stylesheet" />
</head>
<body style="margin: 0">
        <form id="form1" runat="server">
            <div>
                <div class="loginPage-container">
                    <div class="login-page-left-flexbox">
                        <h1 class="app-title-container">
                            <span class="app-title"><span class="app-title_span0">Care</span><span class="app-title_span1">You</span></span>
                        </h1>
                        <h1 class="findacc-text">Find Your
                                <br />
                            CareYou Account</h1>
                    </div>

                    <div class="loginPagebg-container" style="--src: url(/Assets/Login-Register/Rectangle-RegLogin.png)">
                        <div class="forgpw-flex">
                            <div class="enter-flexrow">
                                <h1 class="entEmail">Enter Your Email address</h1>
                                <h1 class="entSend">We’ll send you link in your email to reset your password</h1>
                            </div>

                            <div class="Lgflex_col">
                                <div class="email-container">
                                    <asp:TextBox ID="emailTb" CssClass="emailBox" runat="server" placeholder="E-mail Address"></asp:TextBox>
                                </div>
                                <asp:Label ID="errorLbl" runat="server" CssClass="error-text"></asp:Label>
                            </div>
                            <div class="Lgflex_col">
                            </div>
                        </div>
                        <div class="forg-bottom-container">
                            <div class="left-container">
                                <asp:Button ID="returnSignin" CssClass="return-btn" runat="server" Text="Return to Sign in" OnClick="returnSignin_Click" />
                                <img class="return-png" src="/Assets/Login-Register/ReturnToSignin.png" />
                            </div>

                            <div class="right-container">
                                <asp:Button ID="requestBtn" CssClass="request-btn" runat="server" Text="Request Reset Password" OnClick="requestBtn_Click" />
                            </div>
                        </div>
                        <hr class="line" size="1" />
                    </div>

                </div>
            </div>
        </form>
    </body>
</html>
