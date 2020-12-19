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

    

    // View Products Gridview (Table)
    protected void GVbind() {
        
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString())) {
            con.Open();
            String query = "SELECT pp.product_id AS product_id, " +
                           "pp.category_id AS cat_id, " +
                           "pp.brand_id AS brand_id, " +
                           "pp.product_image AS prod_image, " +
                           "pc.category_name AS cat_name, " +
                           "pb.brand_name AS brand_name, " +
                           "pp.product_name AS prod_name, " +
                           "pp.model_year AS model_year, " +
                           "pp.date_created AS date_created, " +
                           "pp.date_modify AS date_modify " +
                           "FROM production.products pp " +
                           "LEFT JOIN production.brands pb ON pp.brand_id = pb.brand_id " +
                           "LEFT JOIN production.categories pc ON pp.category_id = pc.category_id";
            SqlCommand cmd = new SqlCommand(query, con);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0) {
                GridViewProducts.DataSource = ds;
                GridViewProducts.DataBind();
            }
        }


    }

    // Pagination
    protected void GridViewProducts_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        GridViewProducts.PageIndex = e.NewPageIndex;
        GVbind();
    }






}