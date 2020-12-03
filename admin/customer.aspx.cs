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

    // Logout
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
            String query = "SELECT * FROM sales.customers WHERE first_name LIKE '%" + txtSearch.Text + "%' OR last_name LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridViewCustomer.DataSource = dt;
            GridViewCustomer.DataBind();

            if (dt.Rows.Count == 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Warning','No Data found','error')", true);
                GVbind();
            }

            con.Close();
        }
    }

    // View Gridview (Table)
    protected void GVbind() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT * FROM sales.customers";
            SqlCommand cmd = new SqlCommand(query, con);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0) {
                GridViewCustomer.DataSource = ds;
                GridViewCustomer.DataBind();
            }
        }


    }

    // Pagination
    protected void GridViewCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        GridViewCustomer.PageIndex = e.NewPageIndex;
        GVbind();
    }


}