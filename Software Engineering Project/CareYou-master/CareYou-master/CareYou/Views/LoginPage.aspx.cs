using CareYou.Controller;
using CareYou.DataClass;
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
    public partial class LoginPage : System.Web.UI.Page
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

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String email = emailTb.Text;
            String password = passwordTb.Text;
            Response<User> response = userController.doLogin(email, password);


            if (response.Message == "")
            {
                User user = response.Payload;
                Session["user"] = user;
                Session["UserID"] = user.UserID;
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Value = user.UserID.ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                if (user.Role == "admin")
                {
                    Response.Redirect("DashboardPage.aspx");
                }
                Response.Redirect("Home.aspx");

            }
            else
            {
                if(response.Field == "email")
                {
                    emailErrorLbl.Text = response.Message;
                }
                else
                {
                    emailErrorLbl.Text = "";
                }
                if(response.Field == "User" || response.Field == "password")
                {
                    errorLbl.Text = response.Message;
                }
                else
                {
                    errorLbl.Text = "";
                }
                
            }
        }
    }
}