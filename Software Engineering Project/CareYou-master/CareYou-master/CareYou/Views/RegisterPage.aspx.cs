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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowPasswordIB_Click(object sender, ImageClickEventArgs e)
        {
            String password = passwordTb.Text;
            passwordTb.TextMode = passwordTb.TextMode == TextBoxMode.Password ? TextBoxMode.SingleLine : TextBoxMode.Password;
            passwordTb.Attributes.Add("value", password);
        }

        protected void ShowConfPasswordIb_Click(object sender, ImageClickEventArgs e)
        {
            String password = confpasswordTb.Text;
            confpasswordTb.TextMode = confpasswordTb.TextMode == TextBoxMode.Password ? TextBoxMode.SingleLine : TextBoxMode.Password;
            confpasswordTb.Attributes.Add("value", password);
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String FirstName = fnameTb.Text;
            String LastName = lnameTb.Text;
            String email = emailTb.Text;
            String password = passwordTb.Text;
            String confpassword = confpasswordTb.Text;
            Response<User> response = userController.doRegister(FirstName, LastName, email, password, confpassword);

            if (response.Message == "")
            {
                User user = response.Payload;
                Session["user"] = user;
                Session["UserID"] = user.UserID;
                Response.Redirect("ChooseRolePage.aspx");
            }else
            {
                if(response.Field == "name")
                {
                    nameErrorLbl.Text = response.Message;
                }
                else
                {
                    nameErrorLbl.Text = "";
                }
                if (response.Field == "email")
                {
                    emailErrorLbl.Text = response.Message;
                }
                else
                {
                    emailErrorLbl.Text = "";
                }
                if (response.Field == "password")
                {
                    passErrorLbl.Text = response.Message;
                }
                else
                {
                    passErrorLbl.Text = "";
                }
                if (response.Field == "User" || response.Field == "cpassword")
                {
                    ErrorLbl.Text = response.Message;
                }
                else
                {
                    ErrorLbl.Text = "";
                }
                
            }

            
        }
    }
}