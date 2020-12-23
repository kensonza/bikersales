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

        // Validation Script (Login)
        btnLogin.Attributes.Add("onclick", "javascript:return validationCheck()");
    
    }

    protected void btnLogin_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

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

        // Login SQL Query
        String query = "SELECT * FROM bs_users WHERE username = '" + txtUsername.Text + "' AND password = @password";
        SqlCommand cmd = new SqlCommand(query, con);

        // Select Encrypted User Password
        cmd.Parameters.AddWithValue("@password", pw);

        //String output = cmd.ExecuteScalar().ToString();

        String tokid = "";
        String fname = "";
        String lname = "";
        String uname = "";
        String pword = "";
        String status = "";
        String role = "";

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            
            tokid = reader["token_id"].ToString();
            fname = reader["fname"].ToString();
            lname = reader["lname"].ToString();
            uname = reader["username"].ToString();
            pword = reader["password"].ToString();
            status = reader["status"].ToString();
            role = reader["role"].ToString();
        
        }

        if (txtUsername.Text == uname && pw == pword && status == "active" && role == "admin") {
            
            //Set Session for Admin
            Session["TokId"] = tokid;
            Session["FName"] = fname;
            Session["LName"] = lname;
            Session["User"] = txtUsername.Text;
            Response.Redirect("~/admin/index.aspx?tokid=" + tokid);
            //Response.Write("<script>alert('" + role + "')</script>");
        
        } else if (txtUsername.Text == uname && pw == pword && status == "active" && role == "member") {
            
            //Set Session for Member
            Session["TokId"] = tokid;
            Session["FName"] = fname;
            Session["LName"] = lname;
            Session["User"] = txtUsername.Text;
            Response.Redirect("~/member/index.aspx?tokid=" + tokid);
        
        } else if (txtUsername.Text != uname && pw != pword) {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Invalid Username or Password!','error')", true);

        } else if(txtUsername.Text == "" && txtPassword.Text == "") {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Invalid Username or Password!','error')", true);

        } else if (status == "inactive") {

            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('','Your account has been disabled!','error')", true);

        }

        con.Close();

    }
}