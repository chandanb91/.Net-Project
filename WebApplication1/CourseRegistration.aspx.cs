using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                lblUserName.Text = Session["Name"].ToString();
            }

            if (Session["RegID"] != null)
            {
                lblRegIDValue.Text = Session["RegID"].ToString();
            }

            if (!IsPostBack)
            {
                ddlDuration.Enabled = false;
            }

        }

        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }

            DataSet DS = new DataSet();
            da.Fill(DS);

            return DS;
        }

        protected void ddlCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDuration.Enabled = false;
            SqlParameter parameter = new SqlParameter("@Course_Name", ddlCourseName.SelectedItem.Text);
            DataSet DS = GetData("spCourseDuration", parameter);
            ddlDuration.DataSource = DS;
            ddlDuration.DataBind();

            //ListItem liDuration = new ListItem("--Select Duration--", "-1");
            //ddlDuration.Items.Insert(0, liDuration);
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("spCourseRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter regID = new SqlParameter("@Reg_ID", lblRegIDValue.Text);
                SqlParameter courseName = new SqlParameter("@Course_Name", ddlCourseName.SelectedItem.Text);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@Course_cd";
                outputParameter.SqlDbType = SqlDbType.Decimal;
                outputParameter.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(regID);
                cmd.Parameters.Add(courseName);
                cmd.Parameters.Add(outputParameter);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                if (ReturnCode == 1)
                {
                    lblMessage.Text = "Course Registered";
                }
                else
                {
                    lblMessage.Text = "Error/Already Enrolled";
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedInForm.aspx");
        }
    }
}