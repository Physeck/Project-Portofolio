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
    public partial class AdminProgramDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            String type = Convert.ToString(Request.QueryString["type"]);
            if (type.Equals("new"))
            {
                Program program = ProgramHandler.getProgramById(programId);
                TopicTB.Text = program.ProgramTopic;
                TitleTB.Text = program.ProgramTitle;
                NameTB.Text = program.FundraiserName;
                BeneficiaryTB.Text = program.BeneficiaryName;
                descTB.Text = program.ProgramDesc;
                TypeDDL.SelectedValue = program.ProgramType;
                TypeDDL.Text = program.ProgramType;
                LocTB.Text = program.ProgramLoc;
                targetTb.Text = program.ProgramTarget.ToString();
                dateTb.Text = program.EndDate.ToString();
                imageboxLb.Text = program.ProgramImage;
                idImageBoxLb.Text = program.FundraiserNationalID;
            }
            else if(type.Equals("edit"))
            {
                pageTitle.InnerHtml = "Verify Program Changes";
                ProgramChanges program = ProgramHandler.getProgramChangesById(programId);
                TopicTB.Text = program.Program.ProgramTopic;
                TitleTB.Text = program.Program.ProgramTitle;
                nameCtn.Visible = false;
                beneficiaryCtn.Visible = false;
                descTB.Text = program.ChangesDesc;
                typeCtn.Visible = false;
                locCtn.Visible = false;
                targetTb.Text = program.ChangesTarget.ToString();
                dateTb.Text = program.ChangesEndDate.ToString();
                imageboxLb.Text = program.ChangesImage;
                idCardCtn.Visible = false;
            }
            
        }

        protected void AccBtn_Click(object sender, EventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            String type = Convert.ToString(Request.QueryString["type"]);
            if (type.Equals("new"))
            {
                ProgramHandler.acceptProgram(programId);
            }
            else if (type.Equals("edit"))
            {
                ProgramHandler.acceptProgramChanges(programId);
            }
            Response.Redirect("DashboardPage.aspx");
        }

        protected void RejectBtn_Click(object sender, EventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            String type = Convert.ToString(Request.QueryString["type"]);
            if (type.Equals("new"))
            {
                ProgramHandler.deleteProgram(programId);
            }else if(type.Equals("edit"))
            {
                ProgramHandler.deleteProgramChanges(programId);
            }
            
            Response.Redirect("DashboardPage.aspx");
        }
    }
}