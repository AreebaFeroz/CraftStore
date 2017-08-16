using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCartProducts();
        }
    }



    private void BindCartProducts()
    {
        if (Request.Cookies["OrderID"] != null)
        {
            string CookieData = Request.Cookies["OrderID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');
            if (CookieDataArray.Length > 0)
            {
                h2NoItems.InnerText = "MY CART (" + CookieDataArray.Length + " Items)";
                DataTable dtBrands = new DataTable();
                Int64 CartTotal = 0;
                Int64 Total = 0;
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string ProductID = CookieDataArray[i].ToString().Split('-')[0];
                    

                    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        using (SqlCommand cmd = new SqlCommand("select ProductName from Products where ProductID=" + ProductID + "", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {

                                sda.Fill(dtBrands);

                            }

                        }
                    }

                }

                rptrCartProducts.DataSource = dtBrands;
                rptrCartProducts.DataBind();
            }

            else
{
//TODO Show Empty Cart
h2NoItems.InnerText = "Your Shopping Cart is Empty";

}
}
else
{
//TODO Show Empty Cart
h2NoItems.InnerText = "Your Shopping Cart is Empty";


}
        }
    }











    
