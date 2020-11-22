using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.SessionState;
// Adding for Password Encrypt
using System.Security.Cryptography;
using System.Text;
// Adding SQL Connection
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Session["User"] == null) {
            Response.Redirect("~/login.aspx");
        }

        // Get Session Name
        getSession.Text = Session["User"].ToString();

        if (!IsPostBack) {
            viewEdit();
        }

        // Validation Script (Image)
        btnImage.Attributes.Add("onclick", "javascript:return validationCheck()");

    }

    // Logout Session
    protected void btnLogout_Click(object sender, EventArgs e) {
        Session.Remove("User");
        Response.Redirect("~/login.aspx");
    }


    protected void viewEdit() {
        // Profile Module (Connect to DB)
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String query = "SELECT * FROM bs_users WHERE token_id =" + Request.QueryString["tokenid"];
        SqlCommand cmd = new SqlCommand(query, con);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            txtFname.Text = reader["fname"].ToString();
            txtLname.Text = reader["lname"].ToString();
            txtEmail.Text = reader["email"].ToString();
            DropDownListStatus.Text = reader["status"].ToString();
            DropDownListRole.Text = reader["role"].ToString();
            txtUsername.Text = reader["username"].ToString();
            
        }
        
        con.Close();
        
    }

    protected void btnEditUser_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String queryUpdate = "UPDATE bs_users SET fname = @fname, lname = @lname, email = @email, status = @status, role = @role, date_modify = getdate() WHERE token_id =" + Request.QueryString["tokenid"];
        SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);

        String fname = txtFname.Text;
        String lname = txtLname.Text;
        String email = txtEmail.Text;
        String status = DropDownListStatus.Text;
        String role = DropDownListRole.Text;
        

        cmdUpdate.Parameters.AddWithValue("@fname", fname);
        cmdUpdate.Parameters.AddWithValue("@lname", lname);
        cmdUpdate.Parameters.AddWithValue("@email", email);
        cmdUpdate.Parameters.AddWithValue("@status", status);
        cmdUpdate.Parameters.AddWithValue("@role", role);

        int y = cmdUpdate.ExecuteNonQuery();
        if (y > 0) {
            //Response.Write("<script>alert('Success!')</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["tokenid"] + " has been updated successfully','success')", true);
        }
        con.Close();
    }


    // User Change Password
    protected void btnCP_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String password = txtPword.Text;
        String cpassword = txtCPword.Text;

        if (String.IsNullOrEmpty(password) && String.IsNullOrEmpty(cpassword)) {
        
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Please fill all the fields','error')", true);
        
        } else if (password != cpassword) {
            
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Password not match!','error')", true);
        
        }
        else {
            // set password to md5() Encrypted data
            String encrptPassword = txtPword.Text;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(encrptPassword));
            StringBuilder encryptdata = new StringBuilder();
            
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++) {
                encryptdata.Append(encrypt[i].ToString());
            }
            String pw = encryptdata.ToString();

            String query = "UPDATE bs_users SET password = @pw, date_modify = getdate() WHERE token_id =" + Request.QueryString["tokenid"];
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@pw", pw);

            int y = cmd.ExecuteNonQuery();
            if (y > 0) {
                //Response.Write("<script>alert('Success!')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','" + Request.QueryString["tokenid"] + " Password has been updated successfully','success')", true);
            }

            // Update user date modify
            String queryUpdateUser = "UPDATE bs_users SET date_modify = getdate() WHERE token_id =" + Request.QueryString["tokenid"];
            SqlCommand cmdUpdateUser = new SqlCommand(queryUpdateUser, con);
            int x = cmdUpdateUser.ExecuteNonQuery();
            if (x > 0) {

            }
        }

        con.Close();
    }

    // Edit User Cancel
    protected void btnEditUserCancel_Click(object sender, EventArgs e) {
        Response.Redirect("~/admin/users.aspx");
    }


    // Update User Image
    protected void btnImage_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();


        if (FileUploadImage.PostedFile.ContentType == "image/jpeg" || FileUploadImage.PostedFile.ContentType == "image/png") {

            //Image Path
            String imagepath = "~/img/users/" + FileUploadImage.PostedFile.FileName;
            FileUploadImage.SaveAs(Server.MapPath(imagepath));

            // Image Details
            String imageName = FileUploadImage.PostedFile.FileName;
            //String imageType = FileUploadImage.PostedFile.ContentType;
            String imageSize = FileUploadImage.PostedFile.ContentLength.ToString();

            // Update user image
            String query = "UPDATE bs_users_image SET image = @image, size = @size, date_modify = getdate() WHERE token_id =" + Request.QueryString["tokenid"];
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@image", imageName);
            cmd.Parameters.AddWithValue("@size", imageSize);

            int y = cmd.ExecuteNonQuery();
            if (y > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["tokenid"] + " has been updated successfully','success')", true);
            }

            // Update user date modify
            String queryUpdateUser = "UPDATE bs_users SET date_modify = getdate() WHERE token_id =" + Request.QueryString["tokenid"];
            SqlCommand cmdUpdateUser = new SqlCommand(queryUpdateUser, con);
            int x = cmdUpdateUser.ExecuteNonQuery();
            if (x > 0) {

            }

        } else {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Cancelled','Invalid image file.','error')", true);
            //Response.Write("<script>alert('Invalid Image file')</script>");
        }
        con.Close();
    }
}