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

    //Search Users   
    protected void btnSearch_Click(object sender, EventArgs e) {

        if (txtSearch.Text == "") {
            GVbind();
        } else {
            // SQL Connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
            con.Open();

            SqlCommand sqlcomm = new SqlCommand();

            // Search User Query
            String query = "SELECT * FROM production.brands WHERE brand_name LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridViewBrand.DataSource = dt;
            GridViewBrand.DataBind();

            if (dt.Rows.Count == 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Warning','No Data found','error')", true);
                GVbind();
            }

            con.Close();
        }
    }

    // View Users Gridview (Table)
    protected void GVbind() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT * FROM production.brands";
            SqlCommand cmd = new SqlCommand(query, con);
            
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            
            if (ds.Tables[0].Rows.Count >0) {
                GridViewBrand.DataSource = ds;
                GridViewBrand.DataBind();
            }
        }


    }

    // Add Brand
    protected void btnAddBrand_Click(object sender, EventArgs e) {
        // SQL Connection
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String brand = txtBrand.Text;

        if (String.IsNullOrEmpty(brand)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Brand Name is required!','error')", true);

        } else if (fileUploadImageBrand.PostedFile.ContentType == "image/jpeg" || fileUploadImageBrand.PostedFile.ContentType == "image/png") {

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
                //Response.Redirect("~/admin/brand.aspx");
            }
        
        } else {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Cancelled','Invalid image file.','error')", true);
            //Response.Write("<script>alert('Invalid Image file')</script>"); 
        }

        con.Close();
    }

    //Edit User
    protected void GridViewBrand_SelectedIndexChanged(object sender, EventArgs e) {
        String bid = GridViewBrand.SelectedRow.Cells[0].Text;

        //Response.Redirect("edit-brand.aspx?id=" + bid);
        //Response.Write("<script type='text/javascript>window.open('google.com');</script>");
        //Response.Write("<script>alert('" + id + "')</script>");
        String strRedirectURL = "";
        strRedirectURL = "edit-brand.aspx?bid=" + bid;
        Response.Write("<script>");
        Response.Write("window.open('" + strRedirectURL + "','mywindow','width=900,height=625 resizable=yes')");
        Response.Write("</script>");


    }

    // Delete Brand
    protected void GridViewBrand_RowDeleting(object sender, GridViewDeleteEventArgs e) {

        int bid = Convert.ToInt32(GridViewBrand.DataKeys[e.RowIndex].Value.ToString());

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            // Open connection for image path delete
            con.Open();

            // DELETE brand image on path folder
            String queryImagePath = "SELECT brand_image FROM production.brands WHERE brand_id = '" + bid + "'";
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

            // Open connection for brand db delete
            con.Open();

            // DELETE user
            String query = "DELETE FROM production.brands WHERE brand_id = '" + bid + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            int t = cmd.ExecuteNonQuery();
            if (t > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Deleted!','Record " + bid + " has been deleted','success')", true);
                //GridViewUsers.EditIndex = -1;
                GVbind();
            }
            con.Close();

        }

    }



























}