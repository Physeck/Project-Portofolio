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
    public partial class OrganizationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendreqBtn_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserID"];
            String name = NameTB.Text;
            String type = TypeTB.Text;
            String location = LocTB.Text;
            String phone = NumberTB.Text;
            String email = EmailTB.Text;
            String website = WebsiteTB.Text;
            String leaderName = LeaderTB.Text;
            HttpPostedFile cert = InsertImage.PostedFile;
            bool confirmation = ConfirmationCB.Checked;
            Response<Organization> response;
            if(website == "")
            {
                response = OrganizationController.createOrganization(userId, name, type, location, phone, email, leaderName, cert, confirmation);
            }
            else
            {
                response = OrganizationController.createOrganization(userId, name, type, location, phone, email, website, leaderName, cert, confirmation);
            }

            if (response.Success)
            {
                Response.Redirect("RequestSubmitted.aspx");
            }
            else
            {
                if(response.Field.Equals("name"))
                {
                    nameErrorLbl.Text = response.Message;
                }
                else
                {
                    nameErrorLbl.Text = "";
                }

                if(response.Field.Equals("type"))
                {
                    typeErrorLbl.Text = response.Message;
                }
                else
                {
                    typeErrorLbl.Text = "";
                }

                if(response.Field.Equals("location"))
                {
                    locErrorLbl.Text = response.Message;
                }
                else
                {
                    locErrorLbl.Text = "";
                }

                if(response.Field.Equals("email"))
                {
                    emailErrorLbl.Text = response.Message;
                }
                else
                {
                    emailErrorLbl.Text = "";
                }

                if(response.Field.Equals("phone"))
                {
                    numberErrorLbl.Text = response.Message;
                }
                else
                {
                    numberErrorLbl.Text = "";
                }
                if(response.Field.Equals("leaderName"))
                {
                    leaderErrorLbl.Text = response.Message;
                }
                else
                {
                    leaderErrorLbl.Text = "";
                }
                if (response.Field.Equals("cert"))
                {
                    ImageErrorLbl.Text = response.Message;
                }
                else
                {
                    ImageErrorLbl.Text = "";
                }
                if (response.Field.Equals("confirmation"))
                {
                    ConfirmErrorLbl.Text = response.Message;
                }
                else
                {
                    ConfirmErrorLbl.Text = "";
                }
            }
        }
    }
}