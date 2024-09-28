using CareYou.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            int transactionId = Convert.ToInt32(Request.QueryString["trId"]);
            int programId = Convert.ToInt32(Request.QueryString["programId"]);
            String comment = CommentTB.Text;
            PaymentController.addComment(transactionId, comment);
            Response.Redirect("ProgramDetail.aspx?id=" + programId);
        }

        protected void BackBtn_Click(object sender, ImageClickEventArgs e)
        {
            int programId = Convert.ToInt32(Request.QueryString["programId"]);
            Response.Redirect("ProgramDetail.aspx?id=" + programId);
        }
    }
}