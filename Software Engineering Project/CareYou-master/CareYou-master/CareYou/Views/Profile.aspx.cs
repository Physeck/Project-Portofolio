using CareYou.Controller;
using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareYou.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        public User curr = null;
        public int totalDonate = 0;
        public int rank = 0;
        public userBadgeData badgeOfUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //User user = (User)Session["user"];
            //int id = Convert.ToInt32(user.UserID);

            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            int id = Convert.ToInt32(Request.QueryString["id"]);

            curr = userRepo.GetUserById(id);
            totalDonate = userController.getTotalDonationFromUserID(id);


            if (curr.Role.Equals("user"))
            {
                rank = userController.getUserRank(id);
            }

            badgeOfUser = badgeController.getBadgeByUserID(id);
            uPBadges.DataSource = badgeOfUser.badges;
            uPBadges.DataBind();

            if (badgeOfUser.totalBadge != 0)
            {
                noBadgeLbl.Visible = false;
            }
            else
            {
                noBadgeLbl.Visible = true;
            }

            if(curr.Programs.Count == 0)
            {
                pViewPrgrm.Visible = false;
            }

            if (curr.Role.Equals("user"))
            {
                rank = userController.getUserRank(id);
                PLogo.Style["display"] = "none";
            }else if (curr.Role.Equals("organization"))
            {
                rank = userController.getOrganizationRank(id);
                if(curr.Organization == null)
                {
                    PLogo.Style["display"] = "none";
                }
            }
        }

        protected void pViewPrgrm_Click(object sender, EventArgs e)
        {
            Response.Redirect("FundraisePage.aspx?id=" + curr.UserID);
        }
    }
}