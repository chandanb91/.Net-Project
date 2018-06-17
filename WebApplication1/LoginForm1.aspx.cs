using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace WebApplication1
{
    public partial class LoginForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnNewReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewRegistration.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Session["Name"] = txtUserID.Text;
            GetSessionRegID();
            //Session["Reg"] = ;
            //Response.Redirect("LoggedInform.aspx");
            if(txtUserID.Text == "admin" && txtPassword.Text == "9123456789")
            {
                Response.Redirect("ReportsGrid.aspx");
            }

            if (AuthenticateUser(txtUserID.Text,txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserID.Text, false);
            }
            else
            {
                lblMessage.Text = "Invalid UserName and/or Password";
            }
            

        }

        private void GetSessionRegID()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select REGISTRATION_ID FROM STUDENT_MASTER WHERE NAME =@TextboxValue", con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TextboxValue", SqlDbType.VarChar).Value = txtUserID.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["RegID"] = dt.Rows[0][0].ToString();
                }
                else
                {
                    
                }
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // ConfigurationManager class is in System.Configuration namespace
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            // SqlConnection is in System.Data.SqlClient namespace
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // FormsAuthentication is in System.Web.Security
               // string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                // SqlParameter is in System.Data namespace
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", password);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                return ReturnCode == 1;
            }
        }

    }
}