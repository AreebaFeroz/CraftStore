using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAddProduct : System.Web.UI.Page
{
    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArtistsRptr();
            BindCategoryRptr();
            ddlSubCategory.Enabled = false;
        }
    }

    private void BindArtistsRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Artist", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlArtist.DataSource = dt;
                ddlArtist.DataTextField = "ArtistName";
                ddlArtist.DataValueField = "ArtistID";
                ddlArtist.DataBind();
                ddlArtist.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }

    }

    private void BindCategoryRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Category", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlSubCategory.Enabled = true;
            }
        }

    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from SubCategory where CategoryID='" + ddlCategory.SelectedItem.Value + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataValueField = "SubCategoryID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlSubCategory.Enabled = true;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("procInsertProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", txtPName.Text);
            cmd.Parameters.AddWithValue("@Price", txtSelPrice.Text);
            cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@SubCategoryID", ddlSubCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@InStock", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@Colour", colour.Text);
            cmd.Parameters.AddWithValue("@Size", txtSize.Text);
            cmd.Parameters.AddWithValue("@ArtistID", ddlArtist.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Description", txtDesc.Text);
  
            if (cbFD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
            }
            if (cb30Ret.Checked == true)
            {
                cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
            }
            if (cbCOD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@COD", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@COD", 0.ToString());
            }
            con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                Message.Text = "Record Inserted Succesfully into the Database";
                Message.ForeColor = System.Drawing.Color.CornflowerBlue;
            }
            else
            {
                Message.Text = "Record not added";
            }

            //Int64 ProductID = Convert.ToInt64(cmd.ExecuteScalar());





        }
    }
}














