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

    protected void btnRemoveItem_Click(object sender, EventArgs e)
    {
        string CookiePID = Request.Cookies["OrderID"].Value.Split('=')[1];
        LinkButton btn = (LinkButton)sender;
        string PID = btn.CommandArgument;
        List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
        CookiePIDList.Remove(PID);
        string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
        if (CookiePIDUpdated == "")
        {
            HttpCookie CartProducts = Request.Cookies["OrderID"];
            CartProducts.Values["OrderID"] = null;
            CartProducts.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(CartProducts);

        }
        else
        {
            HttpCookie CartProducts = Request.Cookies["OrderID"];
            CartProducts.Values["OrderID"] = CookiePIDUpdated;
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);

        }
        Response.Redirect("~/Cart.aspx");
    
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
                Int64 Discount = 0;
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string ProductID = CookieDataArray[i].ToString().Split('-')[0];
                    

                    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        using (SqlCommand cmd = new SqlCommand("select * from Products where ProductID=" + ProductID + "", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {

                                sda.Fill(dtBrands);

                            }

                        }
                    }
                    
                    CartTotal += Convert.ToInt64(dtBrands.Rows[i]["Price"]);
                    Discount = (CartTotal * 10) / 100;

                }

                rptrCartProducts.DataSource = dtBrands;
                rptrCartProducts.DataBind();
                divPriceDetails.Visible = true;

                spanCartTotal.InnerText = CartTotal.ToString();
                spanDiscount.InnerText = "Rs. " + Discount.ToString();
                Total = CartTotal - Discount;
                spanTotal.InnerText = "Rs. " + Total.ToString();
                
               
            }

            else
                {
                    //TODO Show Empty Cart
                    h2NoItems.InnerText = "Your Shopping Cart is Empty";
                    divPriceDetails.Visible = false;

                 }
           }
              else
                 {
                   //TODO Show Empty Cart
                         h2NoItems.InnerText = "Your Shopping Cart is Empty";
                         divPriceDetails.Visible = false;


                  }

    }//end of BindCartProducts


















}











    
