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

public partial class _Default : System.Web.UI.Page {

    
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

        // Validation Script (New User)
        btnAddUser.Attributes.Add("onclick", "javascript:return validationCheck()"); 
    }

    // Logout
    protected void btnLogout_Click(object sender, EventArgs e) {
        Session.Remove("User");
        Response.Redirect("~/login.aspx");
    }

    //Search Users   
    protected void btnSearch_Click(object sender, EventArgs e) {
        
        if(txtSearch.Text == "") {
            GVbind();
        } else { 
            // SQL Connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
            con.Open();
        
            SqlCommand sqlcomm = new SqlCommand();

            // Search User Query
            String query = "SELECT * FROM bs_users WHERE fname LIKE '%" + txtSearch.Text + "%' OR lname LIKE '%" + txtSearch.Text + "%' OR username LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridViewUsers.DataSource = dt;
            GridViewUsers.DataBind();

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
            String query = "SELECT * FROM bs_users ORDER BY role ASC ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true) {
                    GridViewUsers.DataSource = dr;
                    GridViewUsers.DataBind();
                }
        }


    }

    // Add User
    protected void btnAddUser_Click(object sender, EventArgs e) {
        // SQL Connection
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        if (fileUploadImageUser.PostedFile.ContentType == "image/jpeg" || fileUploadImageUser.PostedFile.ContentType == "image/png") {

            // Create random(token_id) for users
            String randToken = "";
            Random r = new Random();
            int num = r.Next();
            randToken = num.ToString();

            //Image Path
            String imagepath = "~/img/users/" + fileUploadImageUser.PostedFile.FileName;
            fileUploadImageUser.SaveAs(Server.MapPath(imagepath));
            
            // Image Details
            String imageName = fileUploadImageUser.PostedFile.FileName;
            String imageSize = fileUploadImageUser.PostedFile.ContentLength.ToString();
            String imageType = fileUploadImageUser.PostedFile.ContentType;
            

            // Insert User Image
            String queryImage = "INSERT INTO bs_users_image (token_id, image, size, type, date_created) VALUES(@tokenID, @image, @size, @type, getdate())";
            SqlCommand cmdUsersImage = new SqlCommand(queryImage, con);

            cmdUsersImage.Parameters.AddWithValue("@tokenID", randToken);
            cmdUsersImage.Parameters.AddWithValue("@image", imageName);
            cmdUsersImage.Parameters.AddWithValue("@size", imageSize);
            cmdUsersImage.Parameters.AddWithValue("@type", imageType);

            int y = cmdUsersImage.ExecuteNonQuery();
            if (y > 0) {
                //Response.Write('<script>alert("Save Successfully")</script>');    
            }


            // Set Password to md5() Encrypted data
            String pw = "";
            String password = txtPassword.Text;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++) {
                encryptdata.Append(encrypt[i].ToString());
            }
            pw = encryptdata.ToString();


            // Insert Users Query
            String query = "INSERT INTO bs_users (token_id, fname, lname, email, username, password, status, date_created, role) VALUES(@tokenID, '" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtEmail.Text + "', '" + txtUsername.Text + "', @password, 'active', getdate(), '" + DropDownListRole.Text + "')";
            SqlCommand cmdUsers = new SqlCommand(query, con);

            cmdUsers.Parameters.AddWithValue("@tokenID", randToken);
            cmdUsers.Parameters.AddWithValue("@password", pw);

            int x = cmdUsers.ExecuteNonQuery();
            if (x > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + randToken + " has been added','success')", true);
                //GridViewUsers.EditIndex = +1;
                //GVbind();
                Response.Redirect("~/admin/users.aspx");
            }

        } else {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Cancelled','Invalid image file.','error')", true);
            //Response.Write("<script>alert('Invalid Image file')</script>"); 
        }

        con.Close();
    }

    //Edit User
    protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e) {
        String id = GridViewUsers.SelectedRow.Cells[0].Text;
        Response.Redirect("edit-user.aspx?tokenid=" + id);
    }

    // Delete User
    protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e) {

        int token_id = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value.ToString());

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();

            String query = "DELETE FROM bs_users WHERE token_id = '" + token_id + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            int t = cmd.ExecuteNonQuery();
            if (t > 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Deleted!','Record " + token_id + " has been deleted','success')", true);
                //GridViewUsers.EditIndex = -1;
                GVbind();
            }


            String queryImage = "DELETE FROM bs_users_image WHERE token_id = '" + token_id + "'";
            SqlCommand cmdImage = new SqlCommand(queryImage, con);

            int q = cmdImage.ExecuteNonQuery();
            if (q > 0) {
                //Response.Write("<script>alert('" + id + "')</script>");
            }
        }

    }    
}