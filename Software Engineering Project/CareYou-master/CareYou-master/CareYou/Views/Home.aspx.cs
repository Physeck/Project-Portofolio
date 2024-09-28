using CareYou.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<dynamic> socialPrograms = ProgramHandler.getFiveFirstSocialProgramsForHome();

                SocialProgramRepeater.DataSource = socialPrograms;
                SocialProgramRepeater.DataBind();

                List<dynamic> projectPrograms = ProgramHandler.getFiveFirstProjectProgramsForHome();

                ProjectProgramRepeater.DataSource = projectPrograms;
                ProjectProgramRepeater.DataBind();
            }
        }

        protected void ViewMoreBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DonatePage.aspx");
        }

        protected void FundraiseBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FundraisePage.aspx");
        }
    }
}