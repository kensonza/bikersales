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
            //String query = "SELECT * FROM production.brands WHERE brand_name LIKE '%" + txtSearch.Text + "%'";
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
                            "WHERE so.order_id LIKE '%" + txtSearch.Text + "%' OR sc.first_name LIKE '%" + txtSearch.Text + "%' OR sc.last_name LIKE '%" + txtSearch.Text + "%' " +
                            "GROUP BY so.order_id, sc.first_name, sc.last_name, so.order_status, " +
                            "so.order_date, so.required_date, so.shipped_date";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridViewOrder.DataSource = dt;
            GridViewOrder.DataBind();

            if (dt.Rows.Count == 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Warning','No Data found','error')", true);
                GVbind();
            }

            con.Close();
        }
    }

    //Search Status Dropdown
    protected void DDLStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        if (DDLStatus.SelectedValue == "") {
            GVbind();
        } else {
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
                           "WHERE so.order_status LIKE '%" + DDLStatus.SelectedValue + "%' " +
                           "GROUP BY so.order_id, sc.first_name, sc.last_name, so.order_status, " +
                           "so.order_date, so.required_date, so.shipped_date";

            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridViewOrder.DataSource = dt;
            GridViewOrder.DataBind();

            con.Close();

        }
    }

    // View Gridview (Table)
    protected void GVbind() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT so.order_id AS order_id, CONCAT(sc.first_name, ' ', sc.last_name) AS name, " +
                           "SUM(soi.quantity) AS quantity, " +
                           "SUM(soi.quantity * soi.list_price) AS total_price, " +
                            "CASE " +
                                "WHEN so.order_status = 1 THEN 'New' " +
                                "WHEN so.order_status = 2 THEN 'Pending' " +
                                "WHEN so.order_status = 3 THEN 'Cancelled' " +
                                "WHEN so.order_status = 4 THEN 'Delivered' " +
                            "END AS Order_Status, " +
                            "so.order_date AS order_date, " +
                            "so.required_date AS approved_date, " +
                            "so.shipped_date AS shipping_date " +
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

                // Total of Quantity and Total Price
                int totalQty = 0;
                double totalPrice = 0;

                foreach (DataRow dr in ds.Tables[0].Rows) {
                    totalQty += Convert.ToInt32(dr["quantity"]);
                    totalPrice += Convert.ToDouble(dr["total_price"]);
                }

                GridViewOrder.Columns[0].FooterText = "Total:";
                GridViewOrder.Columns[2].FooterText = totalQty.ToString();
                GridViewOrder.Columns[3].FooterText = String.Format("{0, 0:C2}", totalPrice);

                GridViewOrder.DataBind();
            }
        }

    }

    // Pagination
    protected void GridViewOrder_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        GridViewOrder.PageIndex = e.NewPageIndex;
        GVbind();
    }

    // Export to Excel
    protected void BtnExcel_Click(object sender, EventArgs e) {
        Response.Clear();
        Response.Buffer = true;
        string filename = "Orders - " + DateTime.Now + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + filename);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter()) {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridViewOrder.AllowPaging = false;
            this.GVbind();

            GridViewOrder.GridLines = GridLines.Both;
            GridViewOrder.HeaderStyle.Font.Bold = true;
            GridViewOrder.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control) {
        // used for Export RenderControl();
    }






}