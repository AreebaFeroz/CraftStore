using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Data;
public partial class Signup : System.Web.UI.Page
{
    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        if (username.Text != "" && email.Text != "" && password.Text != "" && confirm_password.Text != "")
        {
            if (checkEmail(email.Text))
            {
                ErrorMessage.ForeColor = Color.Red;
                ErrorMessage.Text = "This email address account already exists";

            }
            else
            {
                if (password.Text == confirm_password.Text)
                {
                    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Customer(CustomerEmail, CustomerPassword, CustomerName, CustomerAddress) Values('" + email.Text + "','" + password.Text + "','" + username.Text + "','" + contact_number.Text + "')", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        ErrorMessage.Text = "Successfully registered";
                        ErrorMessage.ForeColor = Color.Green;
                        Response.Redirect("~/Login.aspx");

                    }
                }
                else
                {
                    ErrorMessage.ForeColor = Color.Red;
                    ErrorMessage.Text = "Passwords do not match";
                }
            }
        }
        else
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "All fields are mandatory";
        }
    }


















    public bool checkEmail(string email)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT CustomerEmail FROM Customer WHERE CustomerEmail=@Email");
        cmd.Parameters.AddWithValue("@Email", email);
        dt = access.SelectFromDatabase(cmd);
        if (dt.Rows.Count > 0)
        {
            retval = true;
        }
        else
        {
            retval = false;
        }
        return retval;
    }











}