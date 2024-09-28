using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Layouts
{
    public partial class AdminNavbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage = Page.AppRelativeVirtualPath;
            if (currentPage.Equals("~/Views/DashboardPage.aspx", StringComparison.OrdinalIgnoreCase))
            {
                DashboardBtn.CssClass = "navbar_btn_selected";
            }else if(currentPage.Equals("~/Views/PendingVerificationPage.aspx", StringComparison.OrdinalIgnoreCase))
            {
                PendingBtn.CssClass = "navbar_btn_selected";
            }else if(currentPage.Equals("~/Views/UserReportPage.aspx", StringComparison.OrdinalIgnoreCase))
            {
                ReportsBtn.CssClass = "navbar_btn_selected";
            }
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = userHandler.GetUserById(id);
                    Session["user"] = user;
                    Session["UserID"] = id;

                }
                else
                {
                    user = (User)Session["user"];
                }
                if (user != null)
                {
                    if (!user.Role.Equals("admin"))
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                }
                
            }

        }

        protected void DashboardBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardPage.aspx");
        }

        protected void PendingBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendingVerificationPage.aspx");
        }

        protected void ReportsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserReportPage.aspx");
        }

        protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["UserID"] = null;
            Session.Remove("user");
            Session.Remove("userID");
            HttpCookie cookie = Request.Cookies["user_cookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("LoginPage.aspx");

        }
    }
}