using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        BindCartNumber();
        
    }
    public void BindCartNumber()
    {
        if (Request.Cookies["OrderID"] != null)
        {
            string CookiePID = Request.Cookies["OrderID"].Value.Split('=')[1];
            string[] ProductArray = CookiePID.Split(',');
            int ProductCount = ProductArray.Length;
            pCount.InnerText = ProductCount.ToString();
        }
        else
        {
            pCount.InnerText = 0.ToString();
        }
    }
   
   

    protected void logoutSession(object sender, EventArgs e)
    {

        Session["user"] = null;
        Response.Redirect("~/Home.aspx");
    }
}
