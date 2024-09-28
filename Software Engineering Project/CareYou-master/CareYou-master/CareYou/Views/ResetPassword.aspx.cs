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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowNewPasswordIb_Click(object sender, ImageClickEventArgs e)
        {
            String password = newpasswordTb.Text;
            newpasswordTb.TextMode = newpasswordTb.TextMode == TextBoxMode.Password ? TextBoxMode.SingleLine : TextBoxMode.Password;
            newpasswordTb.Attributes.Add("value", password);
        }

        protected void ShowConfPasswordIb_Click(object sender, ImageClickEventArgs e)
        {
            String password = confpasswordTb.Text;
            confpasswordTb.TextMode = confpasswordTb.TextMode == TextBoxMode.Password ? TextBoxMode.SingleLine : TextBoxMode.Password;
            confpasswordTb.Attributes.Add("value", password);
        }

        protected void setpasswordBtn_Click(object sender, EventArgs e)
        {
            String newpassword = newpasswordTb.Text;
            String confpassword = confpasswordTb.Text;
            String email = Request.QueryString["email"];
            Response<User> response = userController.doChangePassword(email, newpassword, confpassword);
            if (response.Message == "")
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                if (response.Field == "password")
                {
                    passErrorLbl.Text = response.Message;
                }
                else
                {
                    passErrorLbl.Text = "";
                }
                if (response.Field == "cpassword" || response.Field == "User")
                {
                    cpassErrorLbl.Text = response.Message;
                }
                else
                {
                    cpassErrorLbl.Text = "";
                }
            }
        }
    }
}