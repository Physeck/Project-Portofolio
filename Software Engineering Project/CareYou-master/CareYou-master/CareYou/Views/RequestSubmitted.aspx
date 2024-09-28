<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="RequestSubmitted.aspx.cs" Inherits="CareYou.Views.RequestSubmitted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/paymentsuccessStyle.css" rel="stylesheet" />
    <script>
        window.onload = function () {
            setTimeout(function () {
                document.getElementById('successImage').classList.add('visible');
            }, 400);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="payment-success-flexbox" style="margin: 29.219vw auto 29.219vw">
        <div class="payment-success-container">
            <div class="payment-success-checkmark-container">
                <img id="successImage" class="image" src="../Assets/TransactionMethod/Success-after.png" alt="alt text" />
            </div>
            <div class="payment-success-textbox">
                <h1 class="payment-success-desc">Your request for data verification form has been successfully submitted.</h1>
                <h1 class="payment-success-desc">Your form will be processed shortly. Please check registered email for further updates.</h1>
            </div>
        </div>
    </div>
</asp:Content>
