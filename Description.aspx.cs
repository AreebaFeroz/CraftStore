﻿using System;
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
     Accessible access = new Accessible();
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

         SqlCommand cmd = new SqlCommand("select * from Products where ProductID=" + ProductID + "");
         DataTable images = new DataTable();
         images = access.SelectFromDatabase(cmd);
         rptrImages.DataSource = images;
         rptrImages.DataBind();
            
    }


    private void BindProductDetails()
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);
        SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.* from Products A inner join Category B on B.CategoryID=A.CategoryID inner join SubCategory C on C.SubCategoryID=A.SubCategoryID inner join Artist D on D.ArtistID=A.ArtistID where ProductID=" + ProductID + "");

        //SqlCommand cmd = new SqlCommand("select * from Products where ProductID=" + ProductID + "");
        DataTable dtProducts = new DataTable();
        dtProducts = access.SelectFromDatabase(cmd);
        rptrProductDetails.DataSource = dtProducts;
        rptrProductDetails.DataBind();    
    }



    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);


        if (Session["user"] != null)
        {
            if (Request.Cookies["OrderID"] != null)
            {
                string CookiePID = Request.Cookies["OrderID"].Value.Split('=')[1];
                CookiePID = CookiePID + "," + ProductID;

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
            Response.Redirect("~/Description.aspx?ProductID=" + ProductID);
        }

        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }


}