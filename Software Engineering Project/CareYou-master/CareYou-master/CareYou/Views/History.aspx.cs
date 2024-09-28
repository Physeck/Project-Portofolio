using CareYou.Controller;
using CareYou.Handler;
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
    public partial class History1 : System.Web.UI.Page
    {
        public User curr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            curr = (User)Session["user"];

            //curr = userHandler.GetUserById(1);
            if (!Page.IsPostBack)
            {
                history2Above.DataSource = transactionHandler.getTransactionBasedOnUserID(curr.UserID);
                DataBind();

                if(transactionHandler.getTransactionBasedOnUserID(curr.UserID).Count == 0)
                {
                    noTrans.Visible = true;
                }
                else
                {
                    noTrans.Visible = false;
                }

            }
        }

        protected void dateDDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Transaction> temp = transactionController.getTransactionBasedOnDateAndTypeAndUserID(dateDDH.SelectedIndex, typeDDH.SelectedValue, curr);
            history2Above.DataSource = transactionController.getTransactionBasedOnDateAndTypeAndUserID(dateDDH.SelectedIndex, typeDDH.SelectedValue, curr);
            DataBind();

            if (transactionController.getTransactionBasedOnDateAndTypeAndUserID(dateDDH.SelectedIndex, typeDDH.SelectedValue, curr).Count == 0)
            {
                noTrans.Visible = true;
            }
            else
            {
                noTrans.Visible = false;
            }

            //if (date.Equals("All"))
            //{
            //    history2Above.DataSource = transactionRepo.getTransactionByUserID(curr.UserID);
            //    DataBind();
            //}
            //else if(date.Equals("3 Days Ago"))
            //{
            //    history2Above.DataSource = transactionController.getTransactionBasedOnDateAndUserID(DateTime.Now.AddDays(-3), curr.UserID);
            //    DataBind();
            //}
            //else if(date.Equals("1 Week Ago"))
            //{
            //    history2Above.DataSource = transactionController.getTransactionBasedOnDateAndUserID(DateTime.Now.AddDays(-7), curr.UserID);
            //    DataBind();
            //}
            //else if (date.Equals("3 Week Ago"))
            //{
            //    history2Above.DataSource = transactionController.getTransactionBasedOnDateAndUserID(DateTime.Now.AddDays(-21), curr.UserID);
            //    DataBind();
            //}
            //else if (date.Equals("1 Month Ago"))
            //{
            //    history2Above.DataSource = transactionController.getTransactionBasedOnDateAndUserID(DateTime.Now.AddMonths(-1), curr.UserID);
            //    DataBind();
            //}
            //else if (date.Equals("3 Month Ago"))
            //{
            //    history2Above.DataSource = transactionController.getTransactionBasedOnDateAndUserID(DateTime.Now.AddMonths(-3), curr.UserID);
            //    DataBind();
            //}
        }

        protected void typeDDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            history2Above.DataSource = transactionController.getTransactionBasedOnDateAndTypeAndUserID(dateDDH.SelectedIndex, typeDDH.SelectedValue, curr);
            DataBind();

            if (transactionController.getTransactionBasedOnDateAndTypeAndUserID(dateDDH.SelectedIndex, typeDDH.SelectedValue, curr).Count == 0)
            {
                noTrans.Visible = true;
            }
            else
            {
                noTrans.Visible = false;
            }
        }

        protected void history2Above_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("detail"))
            {
                Response.Redirect("~/Views/ProgramDetail.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}