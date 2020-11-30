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
            viewBrandCat();
        }

    }

    protected void viewBrandCat() {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String query = "SELECT * FROM production.categories WHERE category_id =" + Request.QueryString["bcid"];
        SqlCommand cmd = new SqlCommand(query, con);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            txtBrandCat.Text = reader["category_name"].ToString();
        }

        con.Close();
    }

    // Edit Brand Cancel
    protected void btnEditBrandCatCancel_Click(object sender, EventArgs e) {
        Response.Write("<script>window.close()</script>");
        //Response.Write("window.close()");
        //Response.Write("</script>");
    }

    // Save Edit Brand Cat
    protected void btnEditBrandCatSave_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());

        if (FileUploadImageBrandCat.PostedFile.FileName == "") {
            con.Open();

            String queryUpdate = "UPDATE production.categories SET category_name = @brand, date_modify = getdate() WHERE category_id =" + Request.QueryString["bcid"];
            SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);

            String brand = txtBrandCat.Text;

            cmdUpdate.Parameters.AddWithValue("@brand", brand);


            int y = cmdUpdate.ExecuteNonQuery();
            if (y > 0) {
                //Response.Write("<script>alert('Success!')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["bcid"] + " has been updated successfully','success')", true);
            }

            con.Close();
        } else if (FileUploadImageBrandCat.PostedFile.ContentType == "image/jpeg" || FileUploadImageBrandCat.PostedFile.ContentType == "image/png") {
            con.Open();

            // DELETE user image on path folder
            String queryImagePath = "SELECT category_image FROM production.categories WHERE category_id =" + Request.QueryString["bcid"];
            SqlCommand cmdImagePath = new SqlCommand(queryImagePath, con);

            String delImgPath = "";

            SqlDataReader reader = cmdImagePath.ExecuteReader();
            while (reader.Read()) {
                delImgPath = reader["category_image"].ToString();
            }

            String imagePath = Server.MapPath("~/img/brand_categories/" + delImgPath);
            if (File.Exists(imagePath)) {
                File.Delete(imagePath);
            }

            con.Close();

            con.Open();

            //Image Path
            String imagepath = "~/img/brand_categories/" + FileUploadImageBrandCat.PostedFile.FileName;
            FileUploadImageBrandCat.SaveAs(Server.MapPath(imagepath));

            // Image Details
            String imageName = FileUploadImageBrandCat.PostedFile.FileName;
            String imageSize = FileUploadImageBrandCat.PostedFile.ContentLength.ToString();
            String imageType = FileUploadImageBrandCat.PostedFile.ContentType;

            String brand = txtBrandCat.Text;

            // Update user image
            String query = "UPDATE production.categories SET category_name = @name, category_image = @image, category_image_size = @size, category_image_type = @type, date_modify = getdate() WHERE category_id =" + Request.QueryString["bcid"];
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", brand);
            cmd.Parameters.AddWithValue("@image", imageName);
            cmd.Parameters.AddWithValue("@size", imageSize);
            cmd.Parameters.AddWithValue("@type", imageType);

            int y = cmd.ExecuteNonQuery();
            if (y > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["bcid"] + " has been updated successfully','success')", true);
            }

            con.Close();
        }

    }








}