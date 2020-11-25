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
            viewEBrand();
        }

    }

    protected void viewEBrand() {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String query = "SELECT * FROM production.brands WHERE brand_id =" + Request.QueryString["bid"];
        SqlCommand cmd = new SqlCommand(query, con);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            txtBrand.Text = reader["brand_name"].ToString();
        }

        con.Close();
    }

    // Edit Brand Cancel
    protected void btnEditBrandCancel_Click(object sender, EventArgs e) {
        Response.Write("<script>");
        Response.Write("window.close()");
        Response.Write("</script>");
    }

    // Save Edit Brand
    protected void btnEditBrandSave_Click(object sender, EventArgs e) {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikerSalesConnection"].ToString());
        con.Open();

        String queryUpdate = "UPDATE production.brands SET brand_name = @brand, date_modify = getdate() WHERE brand_id =" + Request.QueryString["bid"];
        SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);

        String brand = txtBrand.Text;
        
        cmdUpdate.Parameters.AddWithValue("@brand", brand);
        

        int y = cmdUpdate.ExecuteNonQuery();
        if (y > 0) {
            //Response.Write("<script>alert('Success!')</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Success!','Record " + Request.QueryString["tokenid"] + " has been updated successfully','success')", true);
        }
        con.Close();
    }
}