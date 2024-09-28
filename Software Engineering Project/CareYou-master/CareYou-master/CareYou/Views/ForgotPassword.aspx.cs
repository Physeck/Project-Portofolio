using CareYou.Controller;
using CareYou.DataClass;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void returnSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void requestBtn_Click(object sender, EventArgs e)
        {
            String email = emailTb.Text;
            Response<User> response = userController.doForgotPassword(email);
            if (response.Message == "")
            {
                Response.Redirect("LinkSendPage.aspx?email=" + email);
            }
            else
            {
                errorLbl.Text = response.Message;
            }
        }
    }
}