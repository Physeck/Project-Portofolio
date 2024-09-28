using CareYou.Handler;
using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class AdminProgramReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int programId = Convert.ToInt32(Request.QueryString["id"]);
                Program program = programRepo.getProgramById(programId);
                var reports = ProgramHandler.getAllPendingReports(program);
                ReportRepeater.DataSource = reports;
                ReportRepeater.DataBind();
            }
        }

        protected void ResolveButton_Click(object sender, EventArgs e)
        {
            Button resolveButton = (Button)sender;
            int reportId = Convert.ToInt32(resolveButton.CommandArgument);

            ReportHandler.ApproveReport(reportId);
            int programId = Convert.ToInt32(Request.QueryString["id"]);
            Program program = programRepo.getProgramById(programId);
            var reports = ProgramHandler.getAllPendingReports(program);
            ReportRepeater.DataSource = reports;
            ReportRepeater.DataBind();
        }

        
    }
}