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

public partial class AdminAddArtist : System.Web.UI.Page
{
    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                BindArtistsRptr();
            }

        }
        else
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
       

    }

    private void BindArtistsRptr()
    {
         String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
         using (SqlConnection con = new SqlConnection(CS))
         {
             using (SqlCommand cmd = new SqlCommand("select * from Artist", con))
             {
                 using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                 {
                     DataTable dtArtist = new DataTable();
                     sda.Fill(dtArtist);
                     rptrArtists.DataSource = dtArtist;
                     rptrArtists.DataBind();
                 }
             }
         }
       
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (checkCat(ArtistName.Text))
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "This Category already exists";


        }
        else
        {
            String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Artist(ArtistName) Values('" + ArtistName.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                ArtistName.Text = String.Empty;
            }
            BindArtistsRptr();
        }
    }

    public bool checkCat(string artist)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT ArtistName FROM Artist WHERE ArtistName=@Artist");
        cmd.Parameters.AddWithValue("@Artist", artist);
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