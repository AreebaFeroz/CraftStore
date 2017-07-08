using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminAddArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArtistsRptr();
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