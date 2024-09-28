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
    public partial class DonatePage : System.Web.UI.Page
    {
        static String programType;
        static String query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (FilterDDL.SelectedValue == "project")
            {
                programType = "project";
            }
            else if (FilterDDL.SelectedValue == "social")
            {
                programType = "social";
            }
            else
            {
                programType = "none";
            }
            if (!IsPostBack)
            {
                query = "";
                ViewState["ProgramCount"] = 5;
                BindPrograms(programType, query);
            }
        }

        private void BindPrograms(String programType, String query)
        {
            var allPrograms = ProgramHandler.getAllPrograms(programType, query);
            int count = (int)ViewState["ProgramCount"];
            var programs = allPrograms.GetRange(0, Math.Min(count, allPrograms.Count));
            ProgramRepeater.DataSource = programs;
            ProgramRepeater.DataBind();
            ViewMoreBtn.Visible = count < allPrograms.Count;
        }
        protected void SearchBtn_Click(object sender, ImageClickEventArgs e)
        {
            query = SearchBar.Text;
            ViewState["ProgramCount"] = 5;
            BindPrograms(programType, query);
        }

        protected void FilterDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(FilterDDL.SelectedValue == "none")
            {
                programType = "none";
                BindPrograms(programType, query);
            }
            else if(FilterDDL.SelectedValue == "project")
            {
                programType = "project";
                BindPrograms(programType, query);
            }
            else if(FilterDDL.SelectedValue == "social")
            {
                programType = "social";
                BindPrograms(programType, query);
            }
        }

        protected void ViewMoreBtn_Click(object sender, EventArgs e)
        {
            int currentCount = (int)ViewState["ProgramCount"];
            ViewState["ProgramCount"] = currentCount + 5;
            BindPrograms(programType,query);
        }
    }
}