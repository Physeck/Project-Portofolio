using CareYou.Controller;
using CareYou.DataClass;
using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class EditProgramDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            Program program = ProgramHandler.getProgramById(programId);
            if(program != null && !IsPostBack)
            {
                TitleLb.Text = program.ProgramTitle;
                TopicLb.Text = program.ProgramTopic;
                descTb.Text = program.ProgramDesc;
                targetTb.Text = program.ProgramTarget.ToString();
                DateTime deadline = program.EndDate;
                dateTb.Text = deadline.ToString("yyyy-MM-dd");
                imageboxLb.Text = program.ProgramImage;
            }

        }

        protected void sendreqBtn_Click(object sender, EventArgs e)
        {
            String desc = descTb.Text;
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            int target;
            if (!Int32.TryParse(targetTb.Text, out target)){
                target = 0;
            }
            String deadline = dateTb.Text;
            bool confirmation = ConfirmationCB.Checked;
            HttpPostedFile file = InsertImage.PostedFile;
            Response<ProgramChanges> response = ProgramController.createProgramChanges(confirmation, programId, desc, target, deadline, file);
            if(response.Success)
            {
                Response.Redirect("RequestSubmitted.aspx");
            }
            else
            {
                if(response.Field.Equals("desc"))
                {
                    descErrorLbl.Text = response.Message;
                }
                else
                {
                    descErrorLbl.Text = "";
                }
                if(response.Field.Equals("target"))
                {
                    TargetErrorLbl.Text = response.Message;
                }
                else
                {
                    TargetErrorLbl.Text = "";
                }
                if(response.Field.Equals("deadline"))
                {
                    DeadlineErrorLbl.Text = response.Message;
                }
                else
                {
                    DeadlineErrorLbl.Text = "";
                }
                if(response.Field.Equals("confirmation"))
                {
                    ConfirmErrorLbl.Text = response.Message;
                }
                else
                {
                    ConfirmErrorLbl.Text = "";
                }
            }
        }

        protected void BackBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ProgramDetailBreakdown.aspx?id=" + Request.QueryString["id"]);
        }
    }
}