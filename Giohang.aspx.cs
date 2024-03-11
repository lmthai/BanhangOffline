using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanhangOffline
{
    public partial class Giohang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tinhtong();
                GridView1.DataSource = DBClass.tbGioHang;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            //SP_ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            DBClass.tbGioHang.Rows[e.RowIndex].Delete();
            Tinhtong();
            GridView1.DataSource = DBClass.tbGioHang;
            GridView1.DataBind();
        }

        protected void btnDathang_Click(object sender, EventArgs e)
        {
            string user = (string)Session["username"];
            if (string.IsNullOrEmpty(user) == true)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Viết tiếp chức năng TẠO ĐƠN HÀNG')", true);
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
        private void Tinhtong()
        {
            decimal tien = 0;
            foreach (DataRow row in DBClass.tbGioHang.Rows)
            {
                tien += (decimal)row["TongTien"];
            }
            Tongtien.Text="Tổng cộng: "+ tien.ToString("### ### ###");
        }
    }
}