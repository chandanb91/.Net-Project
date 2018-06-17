using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class NewRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calDOB.Visible = false;

                ddlDistrict.DataSource = GetData("spDistricts", null);
                ddlDistrict.DataBind();

                ListItem liDistricts = new ListItem("--Select District--", "-1");
                ddlDistrict.Items.Insert(0, liDistricts);

                ListItem liTaluks = new ListItem("--Select Taluk--", "-1");
                ddlTaluk.Items.Insert(0, liTaluks);

                ddlTaluk.Enabled = false;
            }

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


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

        protected void CalendarImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (calDOB.Visible)
            {
                calDOB.Visible = false;
            }
            else
            {
                calDOB.Visible = true;
            }
        }

        protected void calDOB_SelectionChanged(object sender, EventArgs e)
        {
            txtDOB.Text = calDOB.SelectedDate.ToShortDateString();
            if (calDOB.Visible)
            {
                calDOB.Visible = false;
            }
            else
            {
                calDOB.Visible = true;
            }
        }

        protected void calDOB_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Transparent;
            }

            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Transparent;
            }

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedIndex == 0)
            {
                ddlTaluk.SelectedIndex = 0;
                ddlTaluk.Enabled = false;
            }
            else
            {
                ddlTaluk.Enabled = true;
                SqlParameter parameter = new SqlParameter("@District_cd", ddlDistrict.SelectedIndex);
                DataSet DS = GetData("spTaluks", parameter);
                ddlTaluk.DataSource = DS;
                ddlTaluk.DataBind();

                ListItem liTaluks = new ListItem("--Select Taluk--", "-1");
                ddlTaluk.Items.Insert(0, liTaluks);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {


                string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    char rbtnvalue = default(char);
                    if (rbtnMale.Checked)
                    {
                        rbtnvalue = Convert.ToChar(rbtnMale.Text);
                    }
                    else if (rtbnFemale.Checked)
                    {
                        rbtnvalue = Convert.ToChar(rtbnFemale.Text);
                    }

                    SqlCommand command = new SqlCommand("spREG", con);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter username = new SqlParameter("@Name", txtName.Text);
                    SqlParameter dob = new SqlParameter("@DOB", Convert.ToDateTime(txtDOB.Text));
                    SqlParameter gender = new SqlParameter("@Gender", rbtnvalue);
                    SqlParameter email = new SqlParameter("@Email", txtEmail.Text);
                    SqlParameter mobile = new SqlParameter("@Mobile", txtMobile.Text);
                    SqlParameter address = new SqlParameter("@Address", txtAddress.Text);
                    SqlParameter district_cd = new SqlParameter("@District_Name", ddlDistrict.SelectedItem.Text);
                    SqlParameter taluk_cd = new SqlParameter("@Taluk_Name", ddlTaluk.SelectedItem.Text);

                    //SqlParameter outputParameter = new SqlParameter();
                    //outputParameter.ParameterName = "@Reg_ID";
                    //outputParameter.SqlDbType = SqlDbType.VarChar;
                    //outputParameter.Direction = ParameterDirection.Output;

                    command.Parameters.Add("@Reg_ID", SqlDbType.VarChar, 8).Direction = ParameterDirection.Output;
                    command.Parameters.Add(username);
                    command.Parameters.Add(dob);
                    command.Parameters.Add(gender);
                    command.Parameters.Add(email);
                    command.Parameters.Add(mobile);
                    command.Parameters.Add(address);
                    command.Parameters.Add(district_cd);
                    command.Parameters.Add(taluk_cd);

                    con.Open();
                    int ReturnCode = (int)command.ExecuteNonQuery();
                    if (ReturnCode == -1)
                    {
                        lblMessage.Text = "UserName and/or Mobile No. already in use. Please choose another";
                    }
                    else
                    {
                        lblMessage.Text = "Registration Successful";
                    }

                }
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm1.aspx");
        }

        protected void AddressCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            string str = txtAddress.Text;
            char[] ar = str.ToCharArray();
            for (int i = 0; i < ar.Length; i++)
            {
                int t = (int)ar[i];
                if (t == 45 && (t + 1) == 45)
                {
                    args.IsValid = false;
                }

                if ((t >= 44 && t <= 57) || (t >= 65 && t <= 90) || (t >= 97 && t <= 122) || (t == 32) || (t == 35))
                {
                    args.IsValid = true;
                }

                else
                {
                    args.IsValid = false;
                    break;
                }

            }

        }
    }
}