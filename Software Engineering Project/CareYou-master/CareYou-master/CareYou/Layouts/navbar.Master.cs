using System;
using CareYou.Handler;
using CareYou.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views.Layouts
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage = Page.AppRelativeVirtualPath;


            if (currentPage.Equals("~/Views/Home.aspx", StringComparison.OrdinalIgnoreCase))
            {
                HomeBtn.CssClass = "navbar_btn_selected";
            }
            else if (currentPage.Equals("~/Views/DonatePage.aspx", StringComparison.OrdinalIgnoreCase))
            {
                DonateBtn.CssClass = "navbar_btn_selected";
            }
            else if (currentPage.Equals("~/Views/History.aspx", StringComparison.OrdinalIgnoreCase))
            {
                HistoryBtn.CssClass = "navbar_btn_selected";
            }
            else if (currentPage.Equals("~/Views/TopDonation.aspx", StringComparison.OrdinalIgnoreCase))
            {
                TopDonationBtn.CssClass = "navbar_btn_selected";
            }
            else if (currentPage.Equals("~/Views/FundraisePage.aspx", StringComparison.OrdinalIgnoreCase))
            {
                FundraiseBtn.CssClass = "navbar_btn_selected";
            }

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                ProfileBtn.Visible = false;
                SignInBtn.Visible = true;
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
                    ProfileBtn.Visible = true;
                    SignInBtn.Visible = false;
                    if (user.Role == "organization")
                    {
                        int userId = Convert.ToInt32(Session["UserID"]);
                        Organization org = OrganizationHandler.GetOrganizationByUserId(userId);
                        if (org == null)
                        {
                            notifContainer.Attributes["class"] = "notif-container show";
                        }
                    }
                }

            }
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home.aspx");
        }

        protected void DonateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/DonatePage.aspx");
        }

        protected void HistoryBtn_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/History.aspx");
            }
            else
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

        }

        protected void TopDonationBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TopDonation.aspx");
        }

        protected void FundraiseBtn_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/FundraisePage.aspx");
            }
            else
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
                
        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void ProfileBtn_Click(object sender, ImageClickEventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            Response.Redirect("~/Views/UpdateProfile.aspx");
        }
    }
}