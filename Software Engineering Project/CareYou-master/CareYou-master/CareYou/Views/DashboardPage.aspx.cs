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
    public partial class DashboardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserCount.Text = userHandler.GetUsersCount().ToString();
            NewUserCount.Text = userHandler.GetNewUsersCount().ToString();
            TotalDonation.Text = transactionHandler.getSumOfDonations();
            ActiveProgram.Text = ProgramHandler.GetActiveProgramCount().ToString();
        }
    }
}