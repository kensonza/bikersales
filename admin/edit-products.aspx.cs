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

        if (!IsPostBack) {
            viewProducts();

            // Edit Product, Categories DropDownList
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

                // Edit Product, Brand DropDownList
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

            //DDLCategory.Items.Insert(0, new ListItem("test", "0"));
            //DDLBrand.Items.Insert(0, new ListItem("test2", "0"));

        }

    }

    protected void viewProducts() {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String query = "SELECT pp.product_id AS product_id, " +
                       "pp.sku AS sku, " +
                       "pp.category_id AS cat_id, " +
                       "pp.brand_id AS brand_id, " +
                       "pp.product_image AS prod_image, " +
                       "pc.category_name AS cat_name, " +
                       "pb.brand_name AS brand_name, " +
                       "pp.product_name AS prod_name, " +
                       "pp.product_description AS prod_desc, " +
                       "pp.model_year AS model_year, " +
                       "pp.list_price AS price, " +
                       "pp.date_created AS date_created, " +
                       "pp.date_modify AS date_modify " +
                       "FROM production.products pp " +
                       "LEFT JOIN production.brands pb ON pp.brand_id = pb.brand_id " +
                       "LEFT JOIN production.categories pc ON pp.category_id = pc.category_id " +
                       "WHERE pp.product_id =" + Request.QueryString["pid"];

        SqlCommand cmd = new SqlCommand(query, con);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            txtSKU.Text = reader["sku"].ToString();
            txtProdName.Text = reader["prod_name"].ToString();
            txtDesc.Text = reader["prod_desc"].ToString();
            txtModelYear.Text = reader["model_year"].ToString();
            txtPrice.Text = reader["price"].ToString();

            ListItem listItem = new ListItem();
            // ListItem for Category DropDownList
            listItem.Text = reader["cat_name"].ToString();
            listItem.Value = reader["cat_id"].ToString();
            // ListItem for Brand DropDownList
            listItem.Text = reader["brand_name"].ToString();
            listItem.Value = reader["brand_id"].ToString();

            // Insert Update data from DropDownList (Category and Brand)
            DDLCategory.Items.Insert(0, new ListItem(reader["cat_name"].ToString(), reader["cat_id"].ToString()));
            DDLBrand.Items.Insert(0, new ListItem(reader["brand_name"].ToString(), reader["brand_id"].ToString()));


        }

        con.Close();
    }

    // Edit Product Cancel
    protected void btnEditProductCancel_Click(object sender, EventArgs e) {
        Response.Write("<script>window.close()</script>");
    }


    // Save Edit Brand
    protected void btnEditProductSave_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());

        if (FileUploadImageProduct.PostedFile.FileName == "") {
            con.Open();

            String queryUpdate = "UPDATE production.products SET sku = '" + txtSKU.Text + "', product_name = '" + txtProdName.Text + "', product_description = '" + txtDesc.Text + "', brand_id = '" + DDLBrand.Text + "', category_id = '" + DDLCategory.Text + "', model_year = '" + txtModelYear.Text + "', list_price = '" + txtPrice.Text + "', date_modify = getdate() WHERE product_id =" + Request.QueryString["pid"];
            SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);

            int y = cmdUpdate.ExecuteNonQuery();
            if (y > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["pid"] + " has been updated successfully','success')", true);
            }

            con.Close();
        } else if (FileUploadImageProduct.PostedFile.ContentType == "image/jpeg" || FileUploadImageProduct.PostedFile.ContentType == "image/png") {
            con.Open();

            // DELETE product image on path folder
            String queryImagePath = "SELECT product_image FROM production.products WHERE product_id =" + Request.QueryString["pid"];
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

            con.Open();

            //Image Path
            String imagepath = "~/img/products/" + FileUploadImageProduct.PostedFile.FileName;
            FileUploadImageProduct.SaveAs(Server.MapPath(imagepath));

            // Image Details
            String imageName = FileUploadImageProduct.PostedFile.FileName;
            String imageSize = FileUploadImageProduct.PostedFile.ContentLength.ToString();
            String imageType = FileUploadImageProduct.PostedFile.ContentType;

            // Update product image
            String query = "UPDATE production.products SET sku = '" + txtSKU.Text + "', product_name = '" + txtProdName.Text + "', product_description = '" + txtDesc.Text + "', brand_id = '" + DDLBrand.Text + "', category_id = '" + DDLCategory.Text + "', model_year = '" + txtModelYear.Text + "', list_price = '" + txtPrice.Text + "', product_image = @image, product_image_size = @size, product_image_type = @type, date_modify = getdate() WHERE product_id =" + Request.QueryString["pid"];
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@image", imageName);
            cmd.Parameters.AddWithValue("@size", imageSize);
            cmd.Parameters.AddWithValue("@type", imageType);

            int y = cmd.ExecuteNonQuery();
            if (y > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["pid"] + " has been updated successfully','success')", true);
            }

            con.Close();
        }
    }



}