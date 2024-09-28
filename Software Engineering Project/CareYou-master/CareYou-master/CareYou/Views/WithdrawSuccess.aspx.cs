using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class WithdrawSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BackBtn_Click(object sender, ImageClickEventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["programId"]);
            Response.Redirect("ProgramDetail.aspx?id=" + programId);
        }
    }
}