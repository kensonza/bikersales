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
            String query = "SELECT so.order_id AS order_id, pb.brand_name AS brand, pp.product_name AS product, pc.category_name AS category, soi.list_price AS price, " +
                           "soi.quantity AS qty, soi.quantity* soi.list_price AS total, so.order_status AS order_status, so.order_date AS order_date, so.required_date AS approved_date, " +
                           "so.shipped_date AS shipping_date " +
                           "FROM sales.orders so " +
                           "INNER JOIN sales.order_items soi ON so.order_id = soi.order_id " +
                           "LEFT JOIN sales.customers sc ON so.customer_id = sc.customer_id " +
                           "LEFT JOIN production.products pp ON soi.product_id = pp.product_id " +
                           "LEFT JOIN production.categories pc ON pp.category_id = pc.category_id " +
                           "LEFT JOIN production.brands pb ON pp.brand_id = pb.brand_id";
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