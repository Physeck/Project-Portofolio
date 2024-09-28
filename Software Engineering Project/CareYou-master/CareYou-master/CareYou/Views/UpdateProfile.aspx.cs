using CareYou.Controller;
using CareYou.DataClass;
using CareYou.Handler;
using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CareYou.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        public User curr = null;
        public int totalDonate = 0;
        public int rank = 0;
        public userBadgeData badgeOfUser = null;
        static String fileName = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            User user = (User)Session["user"];
            int id = Convert.ToInt32(user.UserID);
            //int id = Convert.ToInt32(Request.QueryString["id"]);

            curr = userRepo.GetUserById(id);
            totalDonate = userController.getTotalDonationFromUserID(id);

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

            if (curr.Role.Equals("user"))
            {
                rank = userController.getUserRank(id);
                uPLogo.Style["display"] = "none";

            }
            else if (curr.Role.Equals("organization"))
            {
                rank = userController.getOrganizationRank(id);
                regComlnk.Visible = false;
                if (curr.Organization == null)
                {
                    uPLogo.Style["display"] = "none";
                }
            }

            if (!Page.IsPostBack)
            {
                showpp.Visible = true;
                updatePP.Visible = false;
                DisableProfilePicUpdate();
                uPPp.Src = "~/Assets/Profiles/" + curr.ProfilePicture;
            }

        }

        protected void UPBtn_Click(object sender, EventArgs e)
        {
            EnableProfilePicUpdate();
            showpp.Visible = false;
            updatePP.Visible = true;
            UPPass.Visible = false;
            cancelChangeUP.Visible = false;
            changePassU.Visible = true;

            PPNameTB.Text = curr.UserName;
            PPEmailTB.Text = curr.UserEmail;
        }

        protected void changePassU_Click(object sender, EventArgs e)
        {
            UPPass.Visible = true;
            changePassU.Visible = false;
            cancelChangeUP.Visible = true;
        }

        protected void cancelChangeUP_Click(object sender, EventArgs e)
        {
            changePassU.Visible = true;
            cancelChangeUP.Visible = false;
            UPPass.Visible = false;
            ePup.Text = "";
            eCPup.Text = "";
            PPPassTB.Attributes.CssStyle.Remove("border");
            PPCPassTB.Attributes.CssStyle.Remove("border");
        }

        protected void DisableProfilePicUpdate()
        {
            // Remove the onclick attribute
            uPPp.Attributes.Remove("onclick");

            // Add a disabled class to change the appearance
            uPPp.Attributes["class"] += " disabled";

            // Disable the file input
            FileUploadControl.Attributes["disabled"] = "true";
        }

        protected void EnableProfilePicUpdate()
        {
            // Add the onclick attribute back
            uPPp.Attributes["onclick"] = "triggerFileInput()";

            // Remove the disabled class to change the appearance
            uPPp.Attributes["class"] = uPPp.Attributes["class"].Replace(" disabled", "").Trim();

            // Enable the file input
            FileUploadControl.Attributes.Remove("disabled");
        }

        protected void updtP2_Click(object sender, EventArgs e)
        {
            
            String name = PPNameTB.Text;
            String email = PPEmailTB.Text;
            String pass = PPPassTB.Text;
            String cPass = PPCPassTB.Text;
            String errormsg = "";
            if (!userController.checkUPNameField(name).Success)
            {
                errormsg = userController.checkUPNameField(name).Message;
                errorName(errormsg);
            }
            else
            {
                eNup.Text = "";
                eNup.ForeColor = System.Drawing.Color.Black;
                PPNameTB.BorderColor = System.Drawing.Color.Black;
                PPNameTB.Attributes.CssStyle.Remove("border");
            }

            if (!userController.checkUPEmailField(email).Success)
            {
                errormsg = userController.checkUPEmailField(email).Message;
                errorEmail(errormsg);
            }
            else
            {
                eEup.Text = "";
                eEup.ForeColor = System.Drawing.Color.Black;
                PPEmailTB.BorderColor = System.Drawing.Color.Black;
                PPEmailTB.Attributes.CssStyle.Remove("border");
            }

            if (UPPass.Visible)
            {
                if (!userController.checkUPPassField(pass).Success)
                {
                    errormsg = userController.checkUPPassField(pass).Message;
                    errorPass(errormsg);
                }
                else
                {
                    ePup.Text = "";
                    ePup.ForeColor = System.Drawing.Color.Black;
                    PPPassTB.BorderColor = System.Drawing.Color.Black;
                    PPPassTB.Attributes.CssStyle.Remove("border");
                }

                if (!userController.checkUPCPassField(cPass, pass).Success)
                {
                    errormsg = userController.checkUPCPassField(cPass, pass).Message;
                    errorCPass(errormsg);
                }
                else
                {
                    eCPup.Text = "";
                    eCPup.ForeColor = System.Drawing.Color.Black;
                    PPCPassTB.BorderColor = System.Drawing.Color.Black;
                    PPCPassTB.Attributes.CssStyle.Remove("border");
                }
            }
            
            if(errormsg == "")
            {
                if (!UPPass.Visible)
                {
                    Response<User> resp = userController.updateProfile(curr, name, email, curr.UserPassword, curr.UserPassword);
                    userHandler.updateProfilePicture(curr, fileName);
                    if (resp.Success)
                    {
                        showpp.Visible = true;
                        updatePP.Visible = false;
                    }
                    else
                    {
                        errormsg = resp.Message;
                        errorName(errormsg);
                    }
                }
                else
                {
                    Response<User> resp = userController.updateProfile(curr, name, email, pass, cPass);
                    userHandler.updateProfilePicture(curr, fileName);
                    if (resp.Success)
                    {
                        showpp.Visible = true;
                        updatePP.Visible = false;
                    }
                    else
                    {
                        errormsg = resp.Message;
                        errorName(errormsg);
                    }
                }
                
            }
            DisableProfilePicUpdate();

            //showpp.Visible = true;
            //updatePP.Visible = false;
        }

        protected void UploadProfilePic(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                string[] validExtensions = { ".gif", ".jpg", ".jpeg", ".png", ".webp" };
                string fileExtension = Path.GetExtension(FileUploadControl.FileName).ToLower();

                if (Array.Exists(validExtensions, ext => ext == fileExtension))
                {
                    string uploadFolder = HttpContext.Current.Server.MapPath("~/Assets/Profiles/");
                    fileName = Path.GetFileName(FileUploadControl.FileName);
                    string filePath = Path.Combine(uploadFolder, fileName);

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    FileUploadControl.SaveAs(filePath);

                    // Update the profile picture src
                    uPPp.Src = "~/Assets/Profiles/" + fileName;
                    
                }
            }
        }

        protected void errorName(String errormsg)
        {

            eNup.Text = errormsg;
            eNup.ForeColor = System.Drawing.Color.Red;
            PPNameTB.Attributes.CssStyle.Add("border", "1px solid red");
        }

        protected void errorEmail(String errormsg)
        {

            eEup.Text = errormsg;
            eEup.ForeColor = System.Drawing.Color.Red;
            PPEmailTB.Attributes.CssStyle.Add("border", "1px solid red");
        }

        protected void errorPass(String errormsg)
        {

            ePup.Text = errormsg;
            ePup.ForeColor = System.Drawing.Color.Red;
            PPPassTB.Attributes.CssStyle.Add("border", "1px solid red");
        }

        protected void errorCPass(String errormsg)
        {

            eCPup.Text = errormsg;
            eCPup.ForeColor = System.Drawing.Color.Red;
            PPCPassTB.Attributes.CssStyle.Add("border", "1px solid red");
        }

        protected void uPLogoutBtn_Click(object sender, EventArgs e)
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

            Response.Redirect("~/Views/Home.aspx");
        }
    }
}