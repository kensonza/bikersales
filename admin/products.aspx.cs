using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.SessionState;
// Adding Image
using System.IO;
// Adding for Password Encrypt
using System.Security.Cryptography;
using System.Text;
// Adding SQL Connection
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

        if (Session["User"] == null) {
            Response.Redirect("~/login.aspx");
        }

        // Get Session Name
        getSession.Text = Session["User"].ToString();

        // Post GridVIew
        if (!IsPostBack) {
            GVbind();


            // Add Product, Categories DropDownList
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
                string queryCat = "SELECT category_id, category_name FROM production.categories";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryCat)) {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader()) {
                        while (sdr.Read()) {
                            ListItem item = new ListItem();
                            item.Text = sdr["category_name"].ToString();
                            item.Value = sdr["category_id"].ToString();
                            //item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                            DDLCategory.Items.Add(item);
                        }
                    }
                }
                //con.Close();
            
            // Add Product, Brand DropDownList
                string queryBrand = "SELECT brand_id, brand_name FROM production.brands";
                //con.Open();
                using (SqlCommand cmd = new SqlCommand(queryBrand)) {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataReader sdr = cmd.ExecuteReader()) {
                        while (sdr.Read()) {
                            ListItem item = new ListItem();
                            item.Text = sdr["brand_name"].ToString();
                            item.Value = sdr["brand_id"].ToString();
                            //item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                            DDLBrand.Items.Add(item);
                        }
                    }
                }
                con.Close();
            }

            //DDLCategory.Items.Insert(0, new ListItem("", "0"));
            //DDLBrand.Items.Insert(0, new ListItem("", "0"));
        }

    }

    // Logout Session
    protected void btnLogout_Click(object sender, EventArgs e) {

        Session.Remove("User");
        Response.Redirect("~/login.aspx");
    }

    //Search Brand   
    protected void btnSearch_Click(object sender, EventArgs e) {

        if (txtSearch.Text == "") {
            GVbind();
        } else {
            // SQL Connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
            con.Open();

            SqlCommand sqlcomm = new SqlCommand();

            // Search User Query
            //String query = "SELECT * FROM production.products WHERE product_name LIKE '%" + txtSearch.Text + "%'";
            String query = "SELECT pp.product_id AS product_id, " +
                           "pp.sku AS sku, " +
                           "pp.category_id AS cat_id, " +
                           "pp.brand_id AS brand_id, " +
                           "pp.product_image AS prod_image, " +
                           "pc.category_name AS cat_name, " +
                           "pb.brand_name AS brand_name, " +
                           "pp.product_name AS prod_name, " +
                           "pp.model_year AS model_year, " +
                           "pp.list_price AS price, " +
                           "pp.date_created AS date_created, " +
                           "pp.date_modify AS date_modify " +
                           "FROM production.products pp " +
                           "LEFT JOIN production.brands pb ON pp.brand_id = pb.brand_id " +
                           "LEFT JOIN production.categories pc ON pp.category_id = pc.category_id " +
                           "WHERE product_id LIKE '%" + txtSearch.Text + "%'" +
                           "OR sku LIKE '%" + txtSearch.Text + "%'" +
                           "OR product_name LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridViewProducts.DataSource = dt;
            GridViewProducts.DataBind();

            if (dt.Rows.Count == 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Warning','No Data found','error')", true);
                GVbind();
            }

            con.Close();
        }
    }

    // View Products Gridview (Table)
    protected void GVbind() {
        
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT pp.product_id AS product_id, " +
                           "pp.sku AS sku, " +
                           "pp.category_id AS cat_id, " +
                           "pp.brand_id AS brand_id, " +
                           "pp.product_image AS prod_image, " +
                           "pc.category_name AS cat_name, " +
                           "pb.brand_name AS brand_name, " +
                           "pp.product_name AS prod_name, " +
                           "pp.model_year AS model_year, " +
                           "pp.list_price AS price, " +
                           "pp.date_created AS date_created, " +
                           "pp.date_modify AS date_modify " +
                           "FROM production.products pp " +
                           "LEFT JOIN production.brands pb ON pp.brand_id = pb.brand_id " +
                           "LEFT JOIN production.categories pc ON pp.category_id = pc.category_id";
            SqlCommand cmd = new SqlCommand(query, con);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0) {
                GridViewProducts.DataSource = ds;
                GridViewProducts.DataBind();
            }
        }


    }

    // Add Product
    protected void btnAddProd_Click(object sender, EventArgs e) {
        // SQL Connection
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String sku = txtSKU.Text;
        String prod_name = txtProdName.Text;
        String cat = DDLCategory.Text;
        String brand = DDLBrand.Text;
        String model_year = txtModelYear.Text;
        String price = txtPrice.Text;

        if (String.IsNullOrEmpty(sku)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','SKU is required!','error')", true);

        } else if (String.IsNullOrEmpty(prod_name)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Product Name is required!','error')", true);

        } else if (String.IsNullOrEmpty(cat)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Category is required!','error')", true);

        } else if (String.IsNullOrEmpty(brand)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Brand is required!','error')", true);
        
        }  else if (String.IsNullOrEmpty(model_year)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Model Year is required!','error')", true);

        } else if (String.IsNullOrEmpty(price)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Price is required!','error')", true);

        } else if (fileUploadImageProd.PostedFile.ContentType == "image/jpeg" || fileUploadImageProd.PostedFile.ContentType == "image/png") {

            //Image Path
            String imagepath = "~/img/products/" + fileUploadImageProd.PostedFile.FileName;
            fileUploadImageProd.SaveAs(Server.MapPath(imagepath));

            // Image Details
            String imageName = fileUploadImageProd.PostedFile.FileName;
            String imageSize = fileUploadImageProd.PostedFile.ContentLength.ToString();
            String imageType = fileUploadImageProd.PostedFile.ContentType;

            // Insert Brand Image
            String query = "INSERT INTO production.products (sku, product_name, brand_id, category_id, model_year, list_price, product_image, product_image_size, product_image_type, date_created) " +
                           "VALUES('" + txtSKU.Text + "', '" + txtProdName.Text + "', '" + DDLBrand.Text + "', '" + DDLCategory.Text + "', '" + txtModelYear.Text + "', '" + txtPrice.Text + "', @image, @size, @type, getdate())";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@image", imageName);
            cmd.Parameters.AddWithValue("@size", imageSize);
            cmd.Parameters.AddWithValue("@type", imageType);

            int y = cmd.ExecuteNonQuery();
            if (y > 0) {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','" + txtSKU.Text + " has been added','success')", true);
                GVbind();
            }

        } else {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Cancelled','Invalid image file.','error')", true);
        }

        con.Close();
    }


    // Delete Brand
    protected void GridViewProducts_RowDeleting(object sender, GridViewDeleteEventArgs e) {

        int pid = Convert.ToInt32(GridViewProducts.DataKeys[e.RowIndex].Value.ToString());

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            // Open connection for image path delete
            con.Open();

            // DELETE Product image on path folder
            String queryImagePath = "SELECT product_image FROM production.products WHERE product_id = '" + pid + "'";
            SqlCommand cmdImagePath = new SqlCommand(queryImagePath, con);

            String delImgPath = "";

            SqlDataReader reader = cmdImagePath.ExecuteReader();
            while (reader.Read()) {
                delImgPath = reader["product_image"].ToString();
            }

            String imagePath = Server.MapPath("~/img/products/" + delImgPath);
            if (File.Exists(imagePath)) {
                File.Delete(imagePath);
            }

            con.Close();

            // Open connection for product db delete
            con.Open();

            // DELETE product
            String query = "DELETE FROM production.products WHERE product_id = '" + pid + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            int t = cmd.ExecuteNonQuery();
            if (t > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Deleted!','Record " + pid + " has been deleted','success')", true);
                GVbind();
            }
            con.Close();

        }

    }







    // Pagination
    protected void GridViewProducts_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        GridViewProducts.PageIndex = e.NewPageIndex;
        GVbind();
    }






}