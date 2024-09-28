<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/navbar.Master" AutoEventWireup="true" CodeBehind="ProgramDetailBreakdown.aspx.cs" Inherits="CareYou.Views.ProgramDetailBreakdown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/programbreakdownstyle.css" rel="stylesheet" />
    <link href="../Style/paymentstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <% if (deleteClicked)
            { %>
        <div id="deletePopup" class="modal">
            <div class="delete-modal" style="--src: url(/Assets/ProgramDetail/delete-popup.svg)">
                <div class="delete-flexbox">
                    <h1 class="delete-title">Warning!</h1>
                    <div class="delete-col">
                        <h1 class="delete-text">Deleting your CareYou campaign will permanently remove all data and access to funds. Ensure all supporters are informed before proceeding.</h1>
                        <div class="delete-btn-row">
                            <asp:Button ID="delBtnY" CssClass="delete-buttons" runat="server" Text="Yes" OnClick="delBtnY_Click" />
                            <asp:Button ID="delBtnN" CssClass="delete-buttons" runat="server" Text="No" OnClick="delBtnN_Click" />
                        </div>
                    </div>
                </div>
                <img class="warning-img" src="/Assets/ProgramDetail/warning.png" alt="alt text" />
            </div>
        </div>
        <% } %>
        <% if (withdrawClicked)
            { %>
        <div id="withdrawPopup" class="modal" style="overflow-y:scroll">
                <div class="payment-container" style="position:absolute; margin-top: 0; top:10.885vw; height:fit-content">
                    <div class="payment-container-flexbox">
                        <h1 class="container-title">Withdraw Amount</h1>
                        <div class="amount_box">
                            <h1 class="currency">Rp</h1>
                            <asp:TextBox CssClass="currency-amount" MaxLength="18" ID="AmountTB" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        </div>
                        <h1 class="container-desc">We want to remind you that a platform fee of 4% is applied to each donation made. This fee helps us maintain and improve our services, ensuring that we can continue to support a wide range of projects and creators.</h1>
                    </div>
                    <div class="payment-container-flexbox">
                        <h1 class="container-title">Withdraw Method</h1>
                        <div id="methodList" class="method-list-flexbox" runat="server">
                            <div class="gopay-container">
                                <div class="method-content-container">
                                    <div class="button-text-container">
                                        <asp:RadioButton ID="GoPayRB" runat="server" GroupName="paymentMethod" CssClass="radio-button" />
                                        <h1 class="method-text">GoPay</h1>
                                    </div>
                                    <img class="method-img" src="/Assets/TransactionMethod/GoPay.png" alt="alt text" />
                                </div>
                            </div>
                            <div class="ovo-dana-container">
                                <div class="method-content-container">
                                    <div class="button-text-container">
                                        <asp:RadioButton ID="OvoRB" runat="server" GroupName="paymentMethod" CssClass="radio-button" />
                                        <h1 class="method-text">OVO</h1>
                                    </div>
                                    <img class="method-img" src="/Assets/TransactionMethod/Ovo.png" alt="alt text" />
                                </div>
                            </div>
                            <div class="ovo-dana-container">
                                <div class="method-content-container">
                                    <div class="button-text-container">
                                        <asp:RadioButton ID="DanaRB" runat="server" GroupName="paymentMethod" CssClass="radio-button" />
                                        <h1 class="method-text">DANA</h1>
                                    </div>
                                    <img class="method-img" src="/Assets/TransactionMethod/Dana.png" alt="alt text" />
                                </div>
                            </div>
                            <div class="cc-container">
                                <div class="method-content-container">
                                    <div class="button-text-container">
                                        <asp:RadioButton ID="CreditCardRB" runat="server" GroupName="paymentMethod" CssClass="radio-button" />
                                        <h1 class="method-text">Credit Card</h1>
                                    </div>
                                    <img class="cc-img" src="/Assets/TransactionMethod/CreditCard.png" alt="alt text" />
                                </div>
                            </div>
                        </div>
                        <div id="CCForm" class="cc-form-container" runat="server">
                            <asp:TextBox ID="CCNameTB" runat="server" Placeholder="Name on card" CssClass="cc-name"></asp:TextBox>
                            <div class="form-flexbox-line">
                                <asp:TextBox ID="CCNumberTB" runat="server" MaxLength="16" Placeholder="Card Number" CssClass="card-number-container" monkeypress="return isNumberKey(event)"></asp:TextBox>
                                <asp:TextBox ID="CCCVVTB" runat="server" MaxLength="3" Placeholder="CVV" CssClass="cc-cvv" monkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="form-flexbox-line">
                                <div class="cc-expire">
                                    <asp:TextBox ID="CCExpireMonthTB" runat="server" MaxLength="2" Placeholder="MM" CssClass="cc-expire-text" monkeypress="return isNumberKey(event)" onblur="validateNumber(this)"></asp:TextBox>
                                    <span class="date-separator">/</span>
                                    <asp:TextBox ID="CCExpireYearTB" runat="server" MaxLength="2" Placeholder="YY" CssClass="cc-expire-text" monkeypress="return isNumberKey(event)"></asp:TextBox>

                                </div>

                                <asp:TextBox ID="CCPostcodeTB" MaxLength="10" runat="server" Placeholder="Postal Code" CssClass="cc-postcode" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Label ID="ErrorLbl" runat="server" CssClass="error-label"></asp:Label>
                        <asp:Button ID="ConfirmWithdrawBtn" CssClass="donate-btn" runat="server" Text="Withdraw" OnClick="ConfirmWithdrawBtn_Click" />
                        <h1 class="container-desc1">By choosing the payment method above, you agree to the CareYou Terms of Service and acknowledge the Privacy Notice.</h1>
                        <div class="spacer"></div>
                    </div>
                </div>
                
        </div>
        <% } %>
        <div class="page-container">
            <div class="help-text-flex_col">
                <asp:Label CssClass="title-text" ID="titleLb" runat="server" Text="Label"></asp:Label>
                <h1 class="breakdown-detail-text">Breakdown details</h1>
                <h1 class="deletion-text">Deletion is only available before a withdrawal is made. After deleting, the donations will be refunded</h1>
            </div>

            <div class="goal-container">
                <div class="raise-text-flex_col">
                    <h1 class="raised-text">Raised</h1>
                    <span class="rp-text">Rp. 
                <asp:Label ID="raisedLb" CssClass="rp-text" runat="server" Text="Label"></asp:Label></span>
                    <span class="rp-goal-text"><span>Rp. </span>
                        <asp:Label ID="targetLb" CssClass="rp-goal-text" runat="server" Text="Label"></asp:Label><span> goal</span></span>

                </div>
                <div class="progress-bar">
                    <div id="progressBar" runat="server" class="progress-bar-inner"></div>
                </div>
            </div>
            <div class="details-container">
                <div class="balance-container">
                    <div class="balance-text-flex_col">
                        <h1 class="balance-text">Balance</h1>
                        <span class="rp-balance-text"><span>Rp </span>
                            <asp:Label ID="balanceLb" runat="server" Text="Label"></asp:Label></span>
                    </div>
                </div>
                <div class="balance-container">
                    <div class="transferred-text-flex_col">
                        <h1 class="balance-text">Transferred</h1>
                        <span class="rp-balance-text"><span>Rp </span>
                            <asp:Label ID="transferredLb" runat="server" Text="Label"></asp:Label></span>
                    </div>
                </div>

                <div class="balance-container">
                    <div class="processed-text-flex_col">
                        <h1 class="balance-text">Processed</h1>
                        <span class="rp-balance-text"><span>Rp </span>
                            <asp:Label ID="processedLb" runat="server" Text="Label"></asp:Label></span>
                    </div>
                </div>

                <div class="balance-container">
                    <div class="fees-text-flex_col">
                        <h1 class="balance-text">Transaction Fees</h1>
                        <span class="rp-balance-text"><span>Rp </span>
                            <asp:Label ID="feeLb" runat="server" Text="Label"></asp:Label></span>
                    </div>
                </div>
            </div>

            <div class="buttons-container">
                <asp:Button ID="withdrawBtn" CssClass="withdrawbtn" runat="server" Text="Withdraw Donation" OnClick="withdrawBtn_Click" />
                <asp:Button ID="deleteBtn" CssClass="deletebtn" runat="server" Text="Delete Program" OnClick="deleteBtn_Click" />
                <asp:Label ID="nodeleteLb" runat="server" CssClass="non-deletebtn" Text="Delete Program" Visible="false"></asp:Label>
                <asp:Button ID="editBtn" CssClass="editbtn" runat="server" Text="Edit Program Details" OnClick="editBtn_Click" />
            </div>
        </div>
    </section>

    <script>
        var delModal = document.getElementById("deletePopup");
        var delContent = document.querySelector(".delete-modal");
        var wtdModal = document.getElementById("withdrawPopup");
        var wtdContent = document.querySelector(".payment-container");

        document.addEventListener("click", function (event) {
            if (event.target !== delContent && delContent !== null && !delContent.contains(event.target)) {
                delModal.style.display = "none";
            }else if(event.target !== wtdContent && wtdContent!== null && !wtdContent.contains(event.target)){
                wtdModal.style.display = "none";
            }
        });

        window.onload = function () {
            var creditCardRB = document.getElementById('<%= CreditCardRB.ClientID %>');
            var ccForm = document.getElementById('<%= CCForm.ClientID %>');
            var radioButtons = document.getElementsByClassName('radio-button');

            function updateCCFormVisibility() {
                if (creditCardRB.checked) {
                    ccForm.classList.remove('hidden');
                } else {
                    ccForm.classList.add('hidden');
                }
            }

            for (var i = 0; i < radioButtons.length; i++) {
                radioButtons[i].onchange = updateCCFormVisibility;
            }
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function validateNumber(input) {
            var value = parseInt(input.value, 10);
            if (value > 12) {
                input.value = '12';
            }
        }
    </script>
</asp:Content>
