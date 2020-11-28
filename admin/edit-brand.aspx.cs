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
            viewEBrand();
        }

    }

    protected void viewEBrand() {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String query = "SELECT * FROM production.brands WHERE brand_id =" + Request.QueryString["bid"];
        SqlCommand cmd = new SqlCommand(query, con);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            txtBrand.Text = reader["brand_name"].ToString();
        }

        con.Close();
    }

    // Edit Brand Cancel
    protected void btnEditBrandCancel_Click(object sender, EventArgs e) {
        Response.Write("<script>");
        Response.Write("window.close()");
        Response.Write("</script>");
    }

    // Save Edit Brand
    protected void btnEditBrandSave_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        
        if(FileUploadImageBrand.PostedFile.FileName == "") {
            con.Open();

            String queryUpdate = "UPDATE production.brands SET brand_name = @brand, date_modify = getdate() WHERE brand_id =" + Request.QueryString["bid"];
            SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);

            String brand = txtBrand.Text;

            cmdUpdate.Parameters.AddWithValue("@brand", brand);


            int y = cmdUpdate.ExecuteNonQuery();
            if (y > 0) {
                //Response.Write("<script>alert('Success!')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["tokenid"] + " has been updated successfully','success')", true);
            }
            
            con.Close();
        } else if (FileUploadImageBrand.PostedFile.ContentType == "image/jpeg" || FileUploadImageBrand.PostedFile.ContentType == "image/png") {
            con.Open();

            // DELETE user image on path folder
            String queryImagePath = "SELECT brand_image FROM production.brands WHERE brand_id =" + Request.QueryString["bid"];
            SqlCommand cmdImagePath = new SqlCommand(queryImagePath, con);

            String delImgPath = "";

            SqlDataReader reader = cmdImagePath.ExecuteReader();
            while (reader.Read()) {
                delImgPath = reader["brand_image"].ToString();
            }

            String imagePath = Server.MapPath("~/img/brand/" + delImgPath);
            if (File.Exists(imagePath)) {
                File.Delete(imagePath);
            }

            con.Close();

            con.Open();

            //Image Path
            String imagepath = "~/img/brand/" + FileUploadImageBrand.PostedFile.FileName;
            FileUploadImageBrand.SaveAs(Server.MapPath(imagepath));

            // Image Details
            String imageName = FileUploadImageBrand.PostedFile.FileName;
            String imageSize = FileUploadImageBrand.PostedFile.ContentLength.ToString();
            String imageType = FileUploadImageBrand.PostedFile.ContentType;

            String brand = txtBrand.Text;

            // Update user image
            String query = "UPDATE production.brands SET brand_name = @name, brand_image = @image, brand_image_size = @size, brand_image_type = @type, date_modify = getdate() WHERE brand_id =" + Request.QueryString["bid"];
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", brand);
            cmd.Parameters.AddWithValue("@image", imageName);
            cmd.Parameters.AddWithValue("@size", imageSize);
            cmd.Parameters.AddWithValue("@type", imageType);

            int y = cmd.ExecuteNonQuery();
            if (y > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["bid"] + " has been updated successfully','success')", true);
            }

            con.Close();
        }
        
    }
}