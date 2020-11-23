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
        
        // Session Check
        if (Session["User"] == null && Session["TokId"] == null  && Session["Fname"] == null && Session["Lname"] == null) {
            Response.Redirect("~/login.aspx");
        }

        // Get Session Username
        getSession.Text = Session["User"].ToString();

        // Profile Module (Connect to DB)
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String query = "SELECT * FROM bs_users bsu LEFT JOIN bs_users_image bsui ON bsu.token_id = bsui.token_id WHERE bsu.username = '" + getSession.Text + "'";
        SqlCommand cmd = new SqlCommand(query, con);

        // Set String for Concatinate Name
        String fname = "";
        String lname = "";
        String imageName = "";
        String ePassword = "";
        

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            imageName = reader["image"].ToString();
            fname = reader["fname"].ToString();
            lname = reader["lname"].ToString();
            txtEmail.Text = reader["email"].ToString();
            txtUsername.Text = reader["username"].ToString();
            ePassword = reader["password"].ToString();
            txtStatus.Text = reader["status"].ToString();
            TxtRole.Text = reader["role"].ToString();
        }

        // View Profile Image
        Image1.ImageUrl = "~/img/users/" + imageName;

        // View Full name using concatenate
        txtFName.Text = fname + " " + lname;

        // Encrypt Password using (*)
        txtPassword.Text = new string('•', ePassword.ToString().Length);

        con.Close();

    }

    protected void btnCP_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String TokID = Session["Tokid"].ToString();
        String password = txtPword.Text;
        String cpassword = txtCPword.Text;

        if (String.IsNullOrEmpty(password) && String.IsNullOrEmpty(cpassword)) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Please fill all the fields','error')", true);

        } else if (password != cpassword) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Password not match!','error')", true);

        } else {
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

            String query = "UPDATE bs_users SET password = @pw, date_modify = getdate() WHERE token_id =" + TokID;
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@pw", pw);

            int y = cmd.ExecuteNonQuery();
            if (y > 0) {
                //Response.Write("<script>alert('Success!')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','" + TokID + " Password has been updated successfully','success')", true);
            }

            // Update user date modify
            String queryUpdateUser = "UPDATE bs_users SET date_modify = getdate() WHERE token_id =" + TokID;
            SqlCommand cmdUpdateUser = new SqlCommand(queryUpdateUser, con);
            int x = cmdUpdateUser.ExecuteNonQuery();
            if (x > 0)  {

            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e) {
        Session.Remove("User");
        Response.Redirect("~/login.aspx");
    }


    protected void btnCancelProfile_Click(object sender, EventArgs e) {
        Response.Redirect("~/admin/index.aspx");
    }


    
}