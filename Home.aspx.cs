using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    Accessible access = new Accessible();
    DataTable images = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            AllImage();
        }

    }


    protected void AllImage()
    {
        SqlCommand cmd = new SqlCommand("Select TOP 3 ProductID,ProductName,Price,Image,Description from Products ORDER BY ProductID");
        images = access.SelectFromDatabase(cmd);
        rptrImages.DataSource = images;
        rptrImages.DataBind();
    }

  

}