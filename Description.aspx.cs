using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Description : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductID"] != null)
        {
            if (!IsPostBack)
            {
                BindProductImages();
                BindProductDetails();
            }
        }
        else
        {
            Response.Redirect("~/ImageDisplay.aspx");
        }
    }


    private void BindProductImages()
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);

        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Products where ProductID=" + ProductID + "", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    

                    DataTable images = new DataTable();
                    sda.Fill(images);
                    rptrImages.DataSource = images;
                    rptrImages.DataBind();
                }

            }
        }
    }


    private void BindProductDetails()
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);

        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Products where ProductID=" + ProductID + "", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrProductDetails.DataSource = dtBrands;
                    rptrProductDetails.DataBind();
                }

            }
        }
    }



    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);

        if (Request.Cookies["OrderID"] != null)
        {
            string CookiePID = Request.Cookies["OrderID"].Value.Split('=')[1];
            CookiePID = CookiePID + "," + ProductID ;

            HttpCookie Order = new HttpCookie("OrderID");
            Order.Values["OrderID"] = CookiePID;
            Order.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(Order);
        }
        else
        {
            HttpCookie Order = new HttpCookie("OrderID");
            Order.Values["OrderID"] = ProductID.ToString();
            Order.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(Order);
        }
        Response.Redirect("~/Description.aspx?ProductID="+ProductID);
    }


}