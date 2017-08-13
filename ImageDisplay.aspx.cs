using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class ImageDisplay : System.Web.UI.Page
{
    Accessible access = new Accessible();
    DataTable images = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        ImagesRptr();
        CategoryRptr();
        SubCategoryRptr();
    }
 

    //private void   ImagesRptr()
    //{
    //    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(CS))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("select * from Products", con))
    //        {
    //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    //            {
    //                DataTable images = new DataTable();
    //                sda.Fill(images);
    //                rptrImages.DataSource = images;
    //                rptrImages.DataBind();
    //            }
    //        }
    //    }

    //}

    private void CategoryRptr()
    {
        SqlCommand cmd = new SqlCommand("select * from Category");
        DataTable dtCat = new DataTable();
        dtCat = access.SelectFromDatabase(cmd);
        rptrCat.DataSource = dtCat;
        rptrCat.DataBind();
    }
    private void SubCategoryRptr()
    {
        SqlCommand cmd = new SqlCommand("select * from SubCategory");
        DataTable dtSubCat = new DataTable();
        dtSubCat = access.SelectFromDatabase(cmd);
       
       
    }


    private void ImagesRptr()
    {
        SqlCommand cmd = new SqlCommand("select * from Products");
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();
    }



   
   
    
}
