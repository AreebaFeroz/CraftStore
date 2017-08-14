using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class AdminAddCategory : System.Web.UI.Page
{

    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategoriesRptr();
        }

    }
    private void BindCategoriesRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Category", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtCategory = new DataTable();
                    sda.Fill(dtCategory);
                    rptrCategories.DataSource = dtCategory;
                    rptrCategories.DataBind();
                }
            }
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (checkCat(CategoryName.Text))
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "This Category already exists";


        }
        else
        {


            String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Category(CategoryName) Values('" + CategoryName.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                CategoryName.Text = String.Empty;
            }
            BindCategoriesRptr();
        }
    }




    public bool checkCat(string cat)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT CategoryName FROM Category WHERE CategoryName=@Cat");
        cmd.Parameters.AddWithValue("@Cat", cat);
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