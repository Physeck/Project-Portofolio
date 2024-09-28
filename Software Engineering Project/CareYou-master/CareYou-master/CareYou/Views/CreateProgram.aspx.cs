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
    public partial class CreateProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendreqBtn_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserID"];
            String topic = TopicTB.Text;
            String title = TitleTB.Text;
            String name = NameTB.Text;
            String beneficiary = BeneficiaryTB.Text;
            String desc = descTB.Text;
            String type = TypeDDL.SelectedValue;
            String location = LocTB.Text;
            int target;
            if (!Int32.TryParse(targetTb.Text, out target))
            {
                target = 0;
            }
            String deadline = dateTb.Text;
            HttpPostedFile programImg = InsertImage.PostedFile;
            HttpPostedFile idImg = InsertID.PostedFile;
            bool confirmation = ConfirmationCB.Checked;
            
            Response<Program> response = ProgramController.createProgram(userId, topic, title, name, beneficiary, desc, type, location, target, deadline, programImg, idImg, confirmation);
            if (response.Success)
            {
                Response.Redirect("RequestSubmitted.aspx");
            }
            else
            {
                if (response.Field.Equals("topic"))
                {
                    topicErrorLbl.Text = response.Message;
                }
                else
                {
                    topicErrorLbl.Text = "";
                }
                if (response.Field.Equals("title"))
                {
                    titleErrorLbl.Text = response.Message;
                }
                else
                {
                    titleErrorLbl.Text = "";
                }
                if (response.Field.Equals("name"))
                {
                    nameErrorLbl.Text = response.Message;
                }
                else
                {
                    nameErrorLbl.Text = "";
                }
                if (response.Field.Equals("beneficiary"))
                {
                    benefeciaryErrorLbl.Text = response.Message;
                }
                else
                {
                    benefeciaryErrorLbl.Text = "";
                }
                if (response.Field.Equals("desc"))
                {
                    descErrorLbl.Text = response.Message;
                }
                else
                {
                    descErrorLbl.Text = "";
                }
                if (response.Field.Equals("type"))
                {
                    typeErrorLbl.Text = response.Message;
                }
                else
                {
                    typeErrorLbl.Text = "";
                }
                if (response.Field.Equals("location"))
                {
                    locErrorLbl.Text = response.Message;
                }
                else
                {
                    locErrorLbl.Text = "";
                }
                if (response.Field.Equals("target"))
                {
                    TargetErrorLbl.Text = response.Message;
                }
                else
                {
                    TargetErrorLbl.Text = "";
                }
                if (response.Field.Equals("deadline"))
                {
                    DeadlineErrorLbl.Text = response.Message;
                }
                else
                {
                    DeadlineErrorLbl.Text = "";
                }
                if (response.Field.Equals("programImage"))
                {
                    ImageErrorLbl.Text = response.Message;
                }
                else
                {
                    ImageErrorLbl.Text = "";
                }
                if (response.Field.Equals("idImage"))
                {
                    IDErrorLbl.Text = response.Message;
                }
                else
                {
                    IDErrorLbl.Text = "";
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