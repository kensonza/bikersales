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

    }

    protected void btnLogin_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        // set password to md5() Encrypted data
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

        // sql select
        //String query = "SELECT count(*) FROM bs_users WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
        String query = "SELECT count(*) FROM bs_users WHERE username = '" + txtUsername.Text + "' AND password = @password";
        SqlCommand cmd = new SqlCommand(query, con);

        // insert encrypted data password
        cmd.Parameters.AddWithValue("@password", pw);
        
        String output = cmd.ExecuteScalar().ToString();

        if(output == "1") {
            //Set Session
            Session["User"] = txtUsername.Text;

            Response.Redirect("~/index.aspx");
        } else {
            Response.Write("<script>alert('Please check your username and password!');</script>");
        }

        con.Close();

    }
}