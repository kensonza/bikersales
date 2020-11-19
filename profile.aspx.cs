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
        if (Session["User"] == null) {
            Response.Redirect("~/login.aspx");
        }

        // Get Session Username
        getSession.Text = Session["User"].ToString();


        // Profile Module (Connect to DB)
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String query = "SELECT * FROM bs_users WHERE username = '" + getSession.Text + "'";
        SqlCommand cmd = new SqlCommand(query, con);

        // Set String for Concatinate Name
        string fname = "";
        string lname = "";

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            fname = reader["fname"].ToString();
            lname = reader["lname"].ToString();
            txtEmail.Text = reader["email"].ToString();
            txtPassword.Text = reader["password"].ToString();
            txtStatus.Text = reader["status"].ToString();
        }
 
        txtFName.Text = fname + " " + lname;
        con.Close();

        
    }

    // Change Password
    [WebMethod(EnableSession = true)]
    //public static string changepassword(string password, string session) {
    public static string changepassword(string password) {

        //string s = (string)HttpContext.Current.Session["User"];

        //Response.Write('s');

        //String mySession;

        //mySession = Session["User"].ToString();

        String msg = "";

        // Change Password Modal (Connect to DB)
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        //String query = "UPDATE bs_users SET password = @pw WHERE username = 's'";
        String query = "UPDATE bs_users SET password = @pw WHERE id = '26'";
        SqlCommand cmd = new SqlCommand(query, con);

        // Update password string to the sql query
        cmd.Parameters.AddWithValue("@pw", password);
        //cmd.Parameters.AddWithValue("@ses", session);

        int i = cmd.ExecuteNonQuery();
        if (i == 1) {
            msg = "true";
        } else {
            msg = "false";
        }

        return msg;

    }


    protected void btnLogout_Click(object sender, EventArgs e) {
        Session.Remove("User");
        Response.Redirect("~/login.aspx");
    }


    protected void btnUpdateProfile_Click(object sender, EventArgs e) {
    
    }
}