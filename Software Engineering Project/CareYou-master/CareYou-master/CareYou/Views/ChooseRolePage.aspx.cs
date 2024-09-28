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
    public partial class ChooseRolePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void continue_Click(object sender, EventArgs e)
        {
            String role = RoleDDL.SelectedValue;
            User user = (User)Session["user"];
            if(role == "")
            {
                errorLbl.Text = "Please select a role";
            }
            else if(user != null && role == "1")
            {
                userHandler.changeRole(user, "user");
                Response.Redirect("Home.aspx");
            }else if(user != null && role == "2")
            {
                userHandler.changeRole(user, "organization");
                Response.Redirect("OrganizationForm.aspx");
            }
            else
            {
                errorLbl.Text = "Something went wrong!";
            }
        }
    }
}