<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="WithdrawSuccess.aspx.cs" Inherits="CareYou.Views.WithdrawSuccess" %>
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
  <section class="payment-success">
    <div class="payment-success-flexbox">
      <div class="payment-success-container">
        <div class="payment-success-checkmark-container"><img id="successImage" class="image" src="../Assets/TransactionMethod/Success-after.png" alt="alt text" /></div>
        <div class="payment-success-textbox">
          <h1 class="payment-success-title">Withdrawal Success</h1>
          <h1 class="payment-success-desc">Your Withdrawal is successful !<br />Please check your balance by going to the details page again.</h1>
        </div>
      </div>
    </div>
    <div class="back-flexbox">
        <asp:ImageButton ID="BackBtn" runat="server" CssClass="back-btn" ImageUrl="~/Assets/TransactionMethod/back-btn.png" OnClick="BackBtn_Click" />
      <h1 class="back-desc">Back to the program page</h1>
    </div>
  </section>
</asp:Content>
