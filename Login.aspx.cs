using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanhangOffline
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopConnection"].ConnectionString);
            myCon.Open();
            string qry = "SELECT * FROM Nguoidung WHERE UserName='" + TextBox1.Text + "' AND Pass='" + TextBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, myCon);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["username"] = TextBox1.Text;
                Response.Redirect ("default.aspx");
            }
            else
            {
                Label1.Text = "UserId & Password Is not correct. Try again..!!";
            }
        }
    }
}