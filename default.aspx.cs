using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanhangOffline
{
    public partial class _default : System.Web.UI.Page
    {
        int SP_ID;
        SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GioHang"] != null)
                {
                    DBClass.tbGioHang = Session["GioHang"] as DataTable;
                }
                else
                {
                    DBClass.tbGioHang.Rows.Clear();
                    DBClass.tbGioHang.Columns.Clear();
                    DBClass.tbGioHang.Columns.Add("idSP", typeof(int));
                    DBClass.tbGioHang.Columns.Add("TenSP", typeof(string));
                    DBClass.tbGioHang.Columns.Add("Gia", typeof(decimal));
                    DBClass.tbGioHang.Columns.Add("SoLuong", typeof(int));
                    DBClass.tbGioHang.Columns.Add("TongTien", typeof(decimal), "SoLuong * Gia");
                }
                lbGiohang.Text = "Giỏ hàng (" + DBClass.tbGioHang.Rows.Count + ")";
                DoGridView();
            }
        }
        private void DoGridView()
        {
            try
            {
                myCon.Open();
                int nhomID = 0;
                if (ListNhom.SelectedIndex > -1)
                {
                    nhomID = Convert.ToInt32(ListNhom.SelectedItem.Value);
                }
                using (SqlCommand myCom = new SqlCommand("dbo.usp_GetProducts", myCon))
                {
                    myCom.Parameters.Add("@NhomID", sqlDbType:SqlDbType.VarChar).Value=nhomID;
                    myCom.Connection = myCon;
                    myCom.CommandType = CommandType.StoredProcedure;

                    SqlDataReader myDr = myCom.ExecuteReader();

                    listSanphams.DataSource = myDr;
                    listSanphams.DataBind();

                    myDr.Close();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in Companies doGridView: " + ex.Message; }
            finally { myCon.Close(); }
        }

        protected void listSanphams_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XemSanpham")
            {
                SP_ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ViewSP.aspx?id=" + SP_ID);
            }
        }
        protected void ShowNhom(object sender, EventArgs e)
        {
            DoGridView();

        }

        protected void lbGiohang_Click(object sender, EventArgs e)
        {
            Response.Redirect("Giohang.aspx");
        }
    }
}