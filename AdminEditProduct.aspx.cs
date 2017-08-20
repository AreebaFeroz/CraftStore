using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

public partial class AdminEditProduct : System.Web.UI.Page
{

    public int artID,catID;
    Accessible access = new Accessible();
    String CS = ConfigurationManager.ConnectionStrings["CraftStoreDatabaseConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PID"] != null)
                {
                    int PID = Convert.ToInt32(Request.QueryString["PID"]);
                    ExtractData();
                    BindArtistsRptr();
                    BindCategoryRptr();
                    //ddlSubCategory.Enabled = false;
                    lbl_ID.Text = PID.ToString();
                }
                else 
                {
                    Response.Redirect("~/AdminHome.aspx");
                }
            }

        }
        else
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
    }

    public void ExtractData()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            SqlCommand cmd = new SqlCommand("select * from Products where ProductID='" + PID + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                    {
                        txtPName.Text = rdr["ProductName"].ToString();
                        artID = Convert.ToInt32(rdr["ArtistID"]);
                        catID = Convert.ToInt32(rdr["CategoryID"]);
                        txtSelPrice.Text = rdr["Price"].ToString();
                        txtSize.Text = rdr["Size"].ToString();
                        txtQuantity.Text = rdr["InStock"].ToString();
                        colour.Text = rdr["Colour"].ToString();
                        txtDesc.Text = rdr["Description"].ToString();
                        rptrImages.DataSource = dt;
                        rptrImages.DataBind();
                        if (Convert.ToInt32(rdr["FreeDelivery"]) == 1)
                        {
                            cbFD.Checked = true;
                        }
                        if (Convert.ToInt32(rdr["30DayRet"]) == 1)
                        {
                            cb30Ret.Checked = true;
                        }
                        if (Convert.ToInt32(rdr["COD"]) == 1)
                        {
                            cbCOD.Checked = true;
                        }
                    }

        }
    }

    


    private void BindArtistsRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Artist", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlArtist.DataSource = dt;
                ddlArtist.DataTextField = "ArtistName";
                ddlArtist.DataValueField = "ArtistID";
                ddlArtist.DataBind();
               // ddlArtist.SelectedValue = artID.ToString();
                ddlArtist.Items.FindByValue(artID.ToString()).Selected = true;
                //ddlArtist.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }

    }

    private void BindCategoryRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Category", con);
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
                ddlCategory.Items.FindByValue(catID.ToString()).Selected = true;
                //ddlArtist.SelectedValue = catID.ToString();
                //ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlSubCategory.Enabled = true;
            }
        }

    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from SubCategory where CategoryID='" + ddlCategory.SelectedItem.Value + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataValueField = "SubCategoryID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlSubCategory.Enabled = true;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //if (checkProduct(txtPName.Text))
        //{
        //    ErrorMessage.ForeColor = Color.Red;
        //    ErrorMessage.Text = "This Product already exists";


        //}


        //else
        //{
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("procUpdateProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", PID);
                cmd.Parameters.AddWithValue("@ProductName", txtPName.Text);
                cmd.Parameters.AddWithValue("@Price", txtSelPrice.Text);
                cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@SubCategoryID", ddlSubCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@InStock", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Colour", colour.Text);
                cmd.Parameters.AddWithValue("@Size", txtSize.Text);
                cmd.Parameters.AddWithValue("@ArtistID", ddlArtist.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Description", txtDesc.Text);

                if (cbFD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
                }
                if (cb30Ret.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
                }
                if (cbCOD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD", 0.ToString());
                }

                // Read the file and convert it to Byte Array

                string filePath = fuImg01.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = String.Empty;
                //Set the contenttype based on File Extension
                switch (ext)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".gif":
                        contenttype = "image/gif";
                        break;
                }
                if (contenttype != String.Empty)
                {

                    Stream fs = fuImg01.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    //insert the file into database

                    cmd.Parameters.AddWithValue("@ImageType", contenttype);
                    cmd.Parameters.AddWithValue("@Image", bytes);

                }

                con.Open();
                //int k = cmd.ExecuteNonQuery();
                //if (k != 0)
                //{
                //    Message.Text = "Record Inserted Succesfully into the Database";
                //    Message.ForeColor = System.Drawing.Color.CornflowerBlue;
                //}
                //else
                //{
                //    Message.Text = "Record not added";
                //}

                //Int64 ProductID = Convert.ToInt64(cmd.ExecuteScalar());
                txtPName.Text = string.Empty;
                txtSelPrice.Text = string.Empty;
                colour.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtSize.Text = string.Empty;
                txtDesc.Text = string.Empty;
                ddlCategory.ClearSelection();
                //ddlCategory.Items.FindByValue("0").Selected = true;
                ddlSubCategory.ClearSelection();
                //ddlSubCategory.Items.FindByValue("0").Selected = true;
                ddlArtist.ClearSelection();
                //ddlArtist.Items.FindByValue("0").Selected = true;
            }

        //}

    }


    public bool checkProduct(string product)
    {
        DataTable dt = new DataTable();
        bool retval;
        SqlCommand cmd = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName=@Product");
        cmd.Parameters.AddWithValue("@Product", product);
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