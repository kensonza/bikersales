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

    // Add Brand
    protected void btnAddBrand_Click(object sender, EventArgs e) {
        Response.Write("<script>alert('Brand Added Test')</script>");
    }

    // View Users Gridview (Table)
    protected void GVbind() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT * FROM production.brands";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true) {
                GridViewBrand.DataSource = dr;
                GridViewBrand.DataBind();
            }
        }


    }
}