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
        }

    }

    // Logout Session
    protected void btnLogout_Click(object sender, EventArgs e) {
        
        Session.Remove("User");
        Response.Redirect("~/login.aspx");
    }

    // View Users Gridview (Table)
    protected void GVbind() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT * FROM production.brands";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            //String image = "";
            
            //while (reader.Read()) {
            //    image = reader["image"].ToString();
            //}

            // View Profile Image
            //Image1.ImageUrl = "~/img/brand/" + image;

            if (dr.HasRows == true) {
                GridViewBrand.DataSource = dr;
                GridViewBrand.DataBind();
            }
        }


    }

    // Add Brand
    protected void btnAddBrand_Click(object sender, EventArgs e) {
        // SQL Connection
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        if (fileUploadImageBrand.PostedFile.ContentType == "image/jpeg" || fileUploadImageBrand.PostedFile.ContentType == "image/png") {

            //Image Path
            String imagepath = "~/img/brand/" + fileUploadImageBrand.PostedFile.FileName;
            fileUploadImageBrand.SaveAs(Server.MapPath(imagepath));

            // Image Details
            String imageName = fileUploadImageBrand.PostedFile.FileName;
            String imageSize = fileUploadImageBrand.PostedFile.ContentLength.ToString();
            String imageType = fileUploadImageBrand.PostedFile.ContentType;

            // Insert Brand Image
            String query = "INSERT INTO production.brands (brand_name, brand_image, brand_image_size, brand_image_type, date_created) VALUES('" + txtBrand.Text + "', @image, @size, @type, getdate())";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@image", imageName);
            cmd.Parameters.AddWithValue("@size", imageSize);
            cmd.Parameters.AddWithValue("@type", imageType);

            int y = cmd.ExecuteNonQuery();
            if (y > 0) {
                //Response.Write('<script>alert("Save Successfully")</script>');
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','" + txtBrand.Text + " has been added','success')", true);
                GVbind();
            }
        
        }

        con.Close();
    }





























}