﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;



public partial class SubCategory : System.Web.UI.Page
{

    Accessible access = new Accessible();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMainCategory();
            BindSubCatRptr();
        }
    }

    private void BindSubCatRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select A.*,B.* from SubCategory A inner join Category B on B.CategoryID=A.CategoryID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtSubCat = new DataTable();
                    sda.Fill(dtSubCat);
                    rptrSubCat.DataSource = dtSubCat;
                    rptrSubCat.DataBind();
                }

            }
        }
        
    }

    private void BindMainCategory()
    {
         String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
         using (SqlConnection con = new SqlConnection(CS))
         {
             SqlCommand cmd = new SqlCommand("select * from Category" , con);
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
             }
         }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        

            if (checkSub(SubCatName.Text))
            {
                ErrorMessage.ForeColor = Color.Red;
                ErrorMessage.Text = "This subcategory already exists";
  

            }
            else
            {
                String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SubCategory(SubCategoryName,CategoryID) Values('" + SubCatName.Text + "','" + ddlCategory.SelectedItem.Value + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SubCatName.Text = string.Empty;
                    ddlCategory.ClearSelection();
                    ddlCategory.Items.FindByValue("0").Selected = true;
                }
                BindSubCatRptr();
            }
        
    }

    public bool checkSub(string subcat)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT SubCategoryName FROM SubCategory WHERE SubCategoryName=@Subcat");
        cmd.Parameters.AddWithValue("@Subcat", subcat);
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