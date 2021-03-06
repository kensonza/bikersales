﻿using System;
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
        // Connection
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());

        if (Session["User"] == null) {
            Response.Redirect("~/login.aspx");
        }

        // Get Session Name
        getSession.Text = Session["User"].ToString();

        // Post GridVIew
        if (!IsPostBack) {
            GVBindBSeller();
        }

        // Total Products
        con.Open();

        string queryTotalProducts = "SELECT count(*) as bilang FROM production.products";

        using (SqlCommand cmd = new SqlCommand(queryTotalProducts)) {
            using (SqlDataAdapter sda = new SqlDataAdapter()) {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet()) {
                    sda.Fill(ds);
                    totalProducts.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }

        con.Close();

        // Low Stock Products
        con.Open();

        int setLowStockProd = 6;
        
        string queryLowStockProd = "SELECT count(*) as bilang FROM production.products pp LEFT JOIN production.stocks ps ON pp.product_id = ps.product_id WHERE quantity > 0 AND quantity <=" + setLowStockProd;

        using (SqlCommand cmd = new SqlCommand(queryLowStockProd)) {
            using (SqlDataAdapter sda = new SqlDataAdapter()) {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet()) {
                    sda.Fill(ds);
                    lowstockProd.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }

        con.Close();

        // Out of Stock Products
        con.Open();

        string queryOutofStockProd = "SELECT count(*) as bilang FROM production.products pp LEFT JOIN production.stocks ps ON pp.product_id = ps.product_id WHERE quantity = 0";

        using (SqlCommand cmd = new SqlCommand(queryOutofStockProd)) {
            using (SqlDataAdapter sda = new SqlDataAdapter()) {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet()) {
                    sda.Fill(ds);
                    outofstockProd.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }

        con.Close();

        // ReStock Products
        //con.Open();

        //string queryRestockProd = "SELECT count(*) as restocks, datepart(week, date_created) Resolve_Week FROM production.stocks Group by datepart(week, date_created), year(date_created)";
        //string queryRestockProd = "SELECT count(*) as restocks FROM production.restocks GROUP BY datepart(week, date_created), year(date_created)";
        //using (SqlCommand cmd = new SqlCommand(queryRestockProd)) {
        //    using (SqlDataAdapter sda = new SqlDataAdapter()) {
        //        cmd.Connection = con;
        //        sda.SelectCommand = cmd;
        //        using (DataSet ds = new DataSet()) {
        //            sda.Fill(ds);
        //            restockProd.Text = ds.Tables[0].Rows[0][0].ToString();
        //        }
        //    }
        //}

        //con.Close();



    }

    // Logout
    protected void btnLogout_Click(object sender, EventArgs e) {
        Session.Remove("User");
        Response.Redirect("~/login.aspx");
    }

    protected void GVBindBSeller() {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT TOP 10 " +
                           "pp.product_id as prod_id, " +
                           "pp.sku as sku, " +
                           "pp.product_name as prod_name, " +
                           "pp.model_year as model_year, " +
                           "sum(soi.quantity) as quantity, " +
                           "sum(soi.list_price) as price " +
                           "FROM production.products pp " +
                           "INNER JOIN sales.order_items soi ON pp.product_id = soi.product_id " +
                           "LEFT JOIN sales.orders so ON soi.order_id = so.order_id " +
                           "WHERE so.order_status = 4 " +
                           "GROUP BY " +
                           "pp.product_id, " +
                           "pp.sku, " +
                           "pp.product_name, " +
                           "pp.model_year, " +
                           "soi.list_price " +
                           "order by 6 desc";
            SqlCommand cmd = new SqlCommand(query, con);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0) {
                GVBSeller.DataSource = ds;
                GVBSeller.DataBind();
            }
        }
    }

        // Pagination New
        protected void GVBSeller_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GVBSeller.PageIndex = e.NewPageIndex;
            GVBindBSeller();
        }













}