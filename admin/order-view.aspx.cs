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

        if (!IsPostBack) {
            viewOrders();
            GVbind();
        }

    }

    protected void viewOrders() {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        //String query = "SELECT * FROM production.brands WHERE brand_id =" + Request.QueryString["bid"];
        String query = "SELECT so.order_id AS order_id, " +
                       "CONCAT(sc.first_name, ' ', sc.last_name) AS name, " +
                       "CONCAT(sc.street, ' ', sc.city, ' ', sc.state) AS address, " +
                       "sc.phone AS phone, " +
                       "sc.email AS email, " +
                       "pc.category_name AS category, " +
                       "pb.brand_name AS brand, " +
                       "pp.product_name AS model, " +
                       "soi.list_price AS price, " +
                       "soi.quantity AS quantity, " +
                       "soi.quantity* soi.list_price AS total_price, " +
                       "CASE " +
                            "WHEN so.order_status = 1 THEN 'New' " +
                            "WHEN so.order_status = 2 THEN 'Pending' " +
                            "WHEN so.order_status = 3 THEN 'Cancelled' " +
                            "WHEN so.order_status = 4 THEN 'Delivered' " +
                       "END AS order_status, " +
                       "so.order_date AS order_date, " +
                       "so.required_date AS approved_date, " +
                       "so.shipped_date AS shipping_date " +
                       "FROM sales.orders so " +
                       "INNER JOIN sales.order_items soi ON so.order_id = soi.order_id " +
                       "LEFT JOIN sales.customers sc ON so.customer_id = sc.customer_id " +
                       "LEFT JOIN production.products pp ON soi.product_id = pp.product_id " +
                       "LEFT JOIN production.categories pc ON pp.category_id = pc.category_id " +
                       "LEFT JOIN production.brands pb ON pp.brand_id = pb.brand_id " +
                       "WHERE so.order_id =" + Request.QueryString["ordid"];

        SqlCommand cmd = new SqlCommand(query, con);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            txtOrdNum.Text = reader["order_id"].ToString();
            txtCustName.Text = reader["name"].ToString();
            txtAddress.Text = reader["address"].ToString();
            txtPhone.Text = reader["phone"].ToString();
            txtEmail.Text = reader["email"].ToString();
        }

        con.Close();
    }

    // View Gridview (Table)
    protected void GVbind() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            //String query = "SELECT * FROM sales.customers";
            String query = "SELECT so.order_id AS order_id, " +
                           "CONCAT(sc.first_name, ' ', sc.last_name) AS name, " +
                           "CONCAT(sc.street, ' ', sc.city, ' ', sc.state) AS address, " +
                           "sc.phone AS phone, " +
                           "sc.email AS email, " +
                           "pc.category_name AS category, " +
                           "pb.brand_name AS brand, " +
                           "pp.product_name AS model, " +
                           "soi.list_price AS price, " +
                           "soi.quantity AS quantity, " +
                           "soi.quantity* soi.list_price AS total_price, " +
                           "CASE " +
                                "WHEN so.order_status = 1 THEN 'New' " +
                                "WHEN so.order_status = 2 THEN 'Pending' " +
                                "WHEN so.order_status = 3 THEN 'Cancelled' " +
                                "WHEN so.order_status = 4 THEN 'Delivered' " +
                           "END AS order_status, " +
                           "so.order_date AS order_date, " +
                           "so.required_date AS approved_date, " +
                           "so.shipped_date AS shipping_date " +
                           "FROM sales.orders so " +
                           "INNER JOIN sales.order_items soi ON so.order_id = soi.order_id " +
                           "LEFT JOIN sales.customers sc ON so.customer_id = sc.customer_id " +
                           "LEFT JOIN production.products pp ON soi.product_id = pp.product_id " +
                           "LEFT JOIN production.categories pc ON pp.category_id = pc.category_id " +
                           "LEFT JOIN production.brands pb ON pp.brand_id = pb.brand_id " +
                           "WHERE so.order_id =" + Request.QueryString["ordid"];
            SqlCommand cmd = new SqlCommand(query, con);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0) {
                GVOrders.DataSource = ds;
                GVOrders.DataBind();
            }
        }


    }

    // Pagination
    protected void GVOrders_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        GVOrders.PageIndex = e.NewPageIndex;
        GVbind();
    }



}