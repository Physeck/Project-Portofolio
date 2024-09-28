using CareYou.Controller;
using CareYou.DataClass;
using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CareYou.Views
{
    public partial class ProgramDetail : System.Web.UI.Page
    {
        public bool reportClicked;
        public bool reportSubmitted;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reportClicked = false;
                reportSubmitted = false;
            }
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            Program program = ProgramHandler.getProgramById(programId);
            int userId = Convert.ToInt32(Session["UserID"]);
            if (program != null)
            {
                ProgramImage.ImageUrl = "~/Assets/Program/" + program.ProgramImage;
                FundraiserImage.ImageUrl = "~/Assets/Profiles/" + program.User.ProfilePicture;
                FundraiserName.Text = program.FundraiserName;
                BeneficiaryName.Text = program.BeneficiaryName;
                ProgramTitleLbl.Text = program.ProgramTitle;
                ProgramDescLbl.Text = program.ProgramDesc;
                
                ViewState["CommentCount"] = 5;
                BindComments(programId);
                ProgramCreatedLbl.Text = ProgramHandler.getProgramCreatedDate(programId);
                TotalRaisedLbl.Text = string.Format("Rp. {0:N0}", program.ProgramRaised);
                GoalLbl.Text = "raised of " + string.Format("Rp. {0:N0}", program.ProgramTarget) + " goal";
                DonationsCountLbl.Text = ProgramHandler.getDonationsCount(programId).ToString() + " donations";

                progressBar.Style["width"] = ProgramHandler.getProgramProgress(programId) + "%";
                var Top3Donations = ProgramHandler.get3TopDonations(programId);
                if (Top3Donations.Count == 0)
                {
                    TopDonationRepeater.Visible = false;
                    TopDonationLbl.Visible = false;
                }
                else
                {
                    TopDonationRepeater.DataSource = Top3Donations;
                    TopDonationRepeater.DataBind();
                }   
                if(ProgramController.isOwner(programId, userId))
                {
                    DonateBtn.Text = "Details";
                }
                if(OtherCB.Checked)
                {
                    OtherReasonTB.Attributes.Remove("disabled");
                }
                else
                {
                    OtherReasonTB.Attributes.Add("disabled", "true");
                }
            }
        }

        protected void ShowMoreBtn_Click(object sender, EventArgs e)
        {
            int currentCount = (int)ViewState["CommentCount"];
            ViewState["CommentCount"] = currentCount + 5; 
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            BindComments(programId);
        }

        private void BindComments(int programId)
        {
            var allComments = ProgramHandler.getAllComments(programId);
            int count = (int)ViewState["CommentCount"];
            var comments = allComments.GetRange(0, Math.Min(count, allComments.Count));
            CommentRepeater.DataSource = comments;
            CommentRepeater.DataBind();
            ShowMoreBtn.Visible = count < allComments.Count;
        }

        protected void ReportLB_Click(object sender, EventArgs e)
        {
            // Set a flag or variable to indicate that the LinkButton has been clicked
            if (Session["user"] != null)
            {
                reportClicked = true;
                int programId = Convert.ToInt32(Request.QueryString["id"]);
                ViewState["ReportedProgramId"] = programId;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }

        }

        protected void DonateBtn_Click(object sender, EventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            int userId = Convert.ToInt32(Session["UserID"]);
            if (Session["UserID"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else if (ProgramController.isOwner(programId,userId))
            {
                // redirect to details page
                Response.Redirect("ProgramDetailBreakdown.aspx?id=" + Request.QueryString["id"]);
            }
            else
            {
                Response.Redirect("Payment.aspx?id=" + Request.QueryString["id"]);
            }
            
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            reportClicked = true;
            bool ScamFundraise = ScamCB.Checked;
            bool FraudFundraise = FraudCB.Checked;
            bool Thirdparty = ThirdpartyCB.Checked;
            bool Other = OtherCB.Checked;
            string OtherReason = "";
            if (Other)
            {
                OtherReason = OtherReasonTB.Text;
            }
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            Response<ReportedProgram> response = ReportController.CreateReport(programId, ScamFundraise, FraudFundraise, Thirdparty, Other, OtherReason);
            if (response.Message == "")
            {
                reportClicked = false;
                reportSubmitted = true;
            }
            else
            {
                errorLbl.Text = response.Message;
            }
            
        }
    }
}