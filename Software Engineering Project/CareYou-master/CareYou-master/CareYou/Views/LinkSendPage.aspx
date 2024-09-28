<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkSendPage.aspx.cs" Inherits="CareYou.Views.LinkSendPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/loginstyle.css" rel="stylesheet" />
    <link href="../Style/linksendstyle.css" rel="stylesheet" />
    <link href="../Style/forgotpwstyle.css" rel="stylesheet" />

</head>
<body style="margin: 0">
        <form id="form1" runat="server">
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
                        <div class="linksend-flex">

                            <div class="checkemail-flexrow">
                                <h1 class="entEmail">Check Your Email Inbox</h1>
                                <h1 class="entSend"><span>We sent an email to </span><asp:HyperLink ID="emailLink" style="text-decoration:underline" runat="server"></asp:HyperLink><span> with password reset link.</span> 
                                    <br />
                                    
                                    If you don't see it after a few minutes, check your spam folder.
                                </h1>
                            </div>
                        </div>
                            <div class="link-bottom-container">
                                <div class="leftbtn-container">
                                    <asp:Button ID="returnSignin" CssClass="return-btn" runat="server" Text="Return to Sign in" OnClick="returnSignin_Click"    />
                                    <img class="return-png" src="/Assets/Login-Register/ReturnToSignin.png" />
                                </div>
                            </div>
                        <hr class="line" size="1" />

                    </div>
                </div>
        </form>
    </body>
</html>
