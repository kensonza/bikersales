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
        if (Session["User"] == null)
        {
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

    // View Gridview (Table)
    protected void GVbind() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT so.order_id AS order_id, CONCAT(sc.first_name, ' ', sc.last_name) AS name, SUM(soi.quantity) AS quantity, SUM(soi.quantity * soi.list_price) AS total_price, " +
                            "CASE " +
                                "WHEN so.order_status = 1 THEN 'New' " +
                                "WHEN so.order_status = 2 THEN 'Pending' " +
                                "WHEN so.order_status = 3 THEN 'Cancelled' " +
                                "WHEN so.order_status = 4 THEN 'Delivered' " +
                            "END AS Order_Status, " +
                            "so.order_date AS order_date, so.required_date AS approved_date, so.shipped_date AS shipping_date " +
                            "FROM sales.orders so " +
                            "INNER JOIN sales.order_items soi ON so.order_id = soi.order_id " +
                            "LEFT JOIN sales.customers sc ON so.customer_id = sc.customer_id " +
                            "GROUP BY so.order_id, sc.first_name, sc.last_name, so.order_status, " +
                            "so.order_date, so.required_date, so.shipped_date";
            SqlCommand cmd = new SqlCommand(query, con);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0) {
                GridViewOrder.DataSource = ds;
                GridViewOrder.DataBind();
            }
        }


    }

    // Pagination
    protected void GridViewOrder_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        GridViewOrder.PageIndex = e.NewPageIndex;
        GVbind();
    }

}