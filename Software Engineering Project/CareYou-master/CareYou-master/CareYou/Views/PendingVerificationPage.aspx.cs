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
    public partial class PendingVerificationPage : System.Web.UI.Page
    {
        static String type;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                type = "none";
                BindPrograms(type);
            }
        }

        private void BindPrograms(String type)
        {
            if (type == "none")
            {
                var allPendingPrograms = ProgramHandler.getAllPendingPrograms(type);
                PendingRepeater.DataSource = allPendingPrograms;
                PendingRepeater.DataBind();

                var allPendingOrganization = OrganizationHandler.getAllPendingOrganizations();
                OrganizationRepeater.DataSource = allPendingOrganization;
                OrganizationRepeater.DataBind();
            }
            else if (type == "new")
            {
                var allPendingPrograms = ProgramHandler.getAllPendingPrograms(type);
                PendingRepeater.DataSource = allPendingPrograms;
                PendingRepeater.DataBind();
                OrganizationRepeater.DataSource = null;
                OrganizationRepeater.DataBind();
            }
            else if (type == "edit")
            {
                var allPendingPrograms = ProgramHandler.getAllPendingPrograms(type);
                PendingRepeater.DataSource = allPendingPrograms;
                PendingRepeater.DataBind();
                OrganizationRepeater.DataSource = null;
                OrganizationRepeater.DataBind();
            }
            else if (type == "org")
            {
                PendingRepeater.DataSource = null;
                PendingRepeater.DataBind();
                var allPendingOrganization = OrganizationHandler.getAllPendingOrganizations();
                OrganizationRepeater.DataSource = allPendingOrganization;
                OrganizationRepeater.DataBind();
            }
                
        }

        protected void FilterDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterDDL.SelectedValue == "none")
            {
                type = "none";
                BindPrograms(type);
            }else if(FilterDDL.SelectedValue == "new")
            {
                type = "new";
                BindPrograms(type);
            }
            else if (FilterDDL.SelectedValue == "edit")
            {
                type = "edit";
                BindPrograms(type);
            }
            else if (FilterDDL.SelectedValue == "org")
            {
                type = "org";
                BindPrograms(type);
            }
        }
    }
}