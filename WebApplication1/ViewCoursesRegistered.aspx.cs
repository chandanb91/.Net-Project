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
    public partial class ViewCoursesRegistered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetData();
            }
            if (Session["Name"] != null)
            {
                lblMessage.Text = Session["Name"].ToString();
            }

            if(Session["RegID"] != null)
            {
                string RegID = Session["RegID"].ToString();
            }
 
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Are you sure want to do this? This cannot be undone.');";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Course_cd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM course_registration WHERE registration_id ='" + Session["RegID"].ToString() + "' and course_cd = '"+ Course_cd +"'"))
                {
                    //cmd.Parameters.AddWithValue("@Reg_ID", RegID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.GetData();
            lblSuccess.Text = "Course Withdrawn";
        }

        void GetData()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select cm.COURSE_CD,COURSE_NAME, DURATION from " +
                    " COURSE_MASTER cm inner join COURSE_REGISTRATION on " +
                    " cm.COURSE_CD = COURSE_REGISTRATION.COURSE_CD " +
                    " inner join STUDENT_MASTER on " +
                    " STUDENT_MASTER.REGISTRATION_ID = COURSE_REGISTRATION.REGISTRATION_ID where student_master.registration_id='" + Session["RegID"].ToString() + "'", con))
                {

                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

            }
            //return dt;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedInForm.aspx");
        }
    }
}