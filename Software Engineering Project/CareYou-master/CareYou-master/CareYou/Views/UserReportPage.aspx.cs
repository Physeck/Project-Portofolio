using CareYou.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class UserReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var allProgramWithReports = ProgramHandler.getAllProgramsWithReports();
            PendingRepeater.DataSource = allProgramWithReports;
            PendingRepeater.DataBind();
        }
    }
}