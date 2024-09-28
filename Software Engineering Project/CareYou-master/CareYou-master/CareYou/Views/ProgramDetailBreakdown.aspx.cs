using CareYou.Controller;
using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class ProgramDetailBreakdown : System.Web.UI.Page
    {
        public bool deleteClicked;
        public bool withdrawClicked;
        protected void Page_Load(object sender, EventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            Program program = ProgramHandler.getProgramById(programId);
            User user = (User)Session["User"];
            CCForm.Attributes["class"] = CreditCardRB.Checked ? "cc-form-container" : "cc-form-container hidden";
            if (!IsPostBack)
            {
                deleteClicked = false;
                withdrawClicked = false;
            }
            if(program != null && ProgramController.isOwner(programId, user.UserID))
            {
                editBtn.Visible = true;
                withdrawBtn.Visible = true;
                deleteBtn.Visible = true;
                titleLb.Text = program.ProgramTitle;
                raisedLb.Text = string.Format("{0:N0}", program.ProgramRaised);
                targetLb.Text = string.Format("{0:N0}", program.ProgramTarget);
                progressBar.Style["width"] = ProgramHandler.getProgramProgress(programId) + "%";
                balanceLb.Text = string.Format("{0:N0}", program.ProgramRaised);
                transferredLb.Text = processedLb.Text = string.Format("{0:N0}", program.Withdrawn);
                feeLb.Text = string.Format("{0:N0}", 0.04 * program.ProgramRaised);
                if(ProgramHandler.isWithdrawn(programId))
                {
                    deleteBtn.Visible = false;
                    nodeleteLb.Visible = true;
                }

            }
            else
            {
                editBtn.Visible = false;
                withdrawBtn.Visible = false;
                deleteBtn.Visible = false;
            }
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProgramDetails.aspx?id=" + Request.QueryString["id"]);
        }

        protected void withdrawBtn_Click(object sender, EventArgs e)
        {
            withdrawClicked = true;
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            deleteClicked = true;
        }

        protected void delBtnY_Click(object sender, EventArgs e)
        {
            // Logic Delete
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            ProgramHandler.deleteProgram(programId);
            Response.Redirect("FundraisePage.aspx");
        }

        protected void delBtnN_Click(object sender, EventArgs e)
        {
            deleteClicked = false;
        }

        protected void ConfirmWithdrawBtn_Click(object sender, EventArgs e)
        {
            String strAmount = AmountTB.Text;
            string selectedPaymentMethod = "";
            string errorMsg = "";
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            int userId = Convert.ToInt32(Session["UserID"]);
            int transactionId = 0;
            foreach (Control control in methodList.Controls)
            {
                if (control is RadioButton radioButton && radioButton.GroupName == "paymentMethod")
                {
                    if (radioButton.Checked)
                    {
                        selectedPaymentMethod = radioButton.ID;
                        break;
                    }
                }
            }
            if (selectedPaymentMethod.Equals("CreditCardRB"))
            {
                string ccName = CCNameTB.Text;
                string ccNumber = CCNumberTB.Text;
                string ccExpireMonth = CCExpireMonthTB.Text;
                string ccExpireYear = CCExpireYearTB.Text;
                string ccCVV = CCCVVTB.Text;
                string ccPostcode = CCPostcodeTB.Text;
                var payment = PaymentController.doWithdrawWithCC(strAmount, ccName, ccNumber, ccExpireMonth, ccExpireYear, ccCVV, ccPostcode, userId, programId);
                errorMsg = payment.response;

            }
            else
            {
                if (selectedPaymentMethod.Equals("GoPayRB"))
                {
                    var payment = PaymentController.doWithdraw(strAmount, userId, programId, "gopay");
                    errorMsg = payment.response;
                }
                else if (selectedPaymentMethod.Equals("OvoRB"))
                {
                    var payment = PaymentController.doWithdraw(strAmount, userId, programId, "ovo");
                    errorMsg = payment.response;
                }
                else if (selectedPaymentMethod.Equals("DanaRB"))
                {
                    var payment = PaymentController.doWithdraw(strAmount, userId, programId, "dana");
                    errorMsg = payment.response;
                }
                else
                {
                    errorMsg = "Please select a payment method";
                }

            }

            if (errorMsg == "")
            {

                ErrorLbl.Text = "";
                Response.Redirect("WithdrawSuccess.aspx?programId=" + programId);
            }
            else
            {
                ErrorLbl.Text = errorMsg;
                withdrawClicked = true;
            }
            
        }
    }
}