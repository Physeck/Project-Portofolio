<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="PaymentSuccess.aspx.cs" Inherits="CareYou.Views.PaymentSuccess" %>
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
          <h1 class="payment-success-title">Thank You for Your Generous Donation!</h1>
          <h1 class="payment-success-desc">Your generous contribution has been successfully processed. Thank your support. Every contribution brings us one step closer to our goal.<br /></h1>
        </div>
      </div>
      <div class="comment-container">
        <div class="comment-flexbox">
          <h1 class="comment-title">Leave a comment</h1>
          <h1 class="comment-desc">We would love to hear from you! If you have any words of support or encouragement for this program, please share them below. Your message can inspire others and spread positivity.</h1>
            <asp:TextBox ID="CommentTB" TextMode="MultiLine" CssClass="comment-textbox" style="resize:none" runat="server"></asp:TextBox>
           <asp:Button ID="SubmitBtn" CssClass="submit-btn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />
        </div>
      </div>
    </div>
    <div class="back-flexbox">
        <asp:ImageButton ID="BackBtn" runat="server" CssClass="back-btn" ImageUrl="~/Assets/TransactionMethod/back-btn.png" OnClick="BackBtn_Click" />
      <h1 class="back-desc">Back to the program page</h1>
    </div>
  </section>
</asp:Content>
