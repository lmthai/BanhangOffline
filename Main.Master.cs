using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanhangOffline
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = (string)Session["username"];
            if (user == "admin")
                Quanly.Visible = true;
            else Quanly.Visible = false;
            if (string.IsNullOrEmpty(user) == false)
            {
                LoginBtn.Visible = false;
                LogouBtn.Visible = true;
                CurrentUser.Text = user;
            }
            else
            {
                LoginBtn.Visible = true;
                LogouBtn.Visible = false;
                CurrentUser.Text = "";
            }

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LogouBtn_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Response.Redirect("default.aspx");

        }
    }
}