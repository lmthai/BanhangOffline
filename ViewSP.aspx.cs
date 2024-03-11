using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanhangOffline
{
    public partial class ViewSP : System.Web.UI.Page
    {
        int SP_ID;
        SqlConnection myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSanphamName.Text = "";
                txtSanphamMa.Text = "";
                txtSanphamDVT.Text = "";
                txtDongia.Text = "";

                string ma = Request.QueryString["ID"].ToString();
                SP_ID = Convert.ToInt32(ma);
                if (SP_ID > 0)
                {
                    GetSanpham(SP_ID);
                }
            }
        }
        private void GetSanpham(int Comp_ID)
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand myCmd = new SqlCommand("dbo.usp_GetSanpham", myCon))
                {
                    myCmd.Connection = myCon;
                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.Parameters.Add("@ID", SqlDbType.Int).Value = Comp_ID;
                    SqlDataReader myDr = myCmd.ExecuteReader();

                    if (myDr.HasRows)
                    {
                        while (myDr.Read())
                        {
                            txtSanphamName.Text = myDr.GetValue(1).ToString();
                            txtSanphamMa.Text = myDr.GetValue(2).ToString();
                            txtSanphamDVT.Text = myDr.GetValue(3).ToString();
                            txtDongia.Text = myDr.GetValue(4).ToString();
                            txtSoluong.Text = "1";
                            lblSPID.Text = Comp_ID.ToString();
                            Image1.ImageUrl = "~/Images/" + myDr.GetValue(5).ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in GetSanpham: " + ex.Message; }
            finally { myCon.Close(); }
        }
        protected void btnChonSanpham_Click(object sender, EventArgs e)
        {
            int idSP = int.Parse(lblSPID.Text);
            if(int.TryParse(txtSoluong.Text, out int SL))
            {
                if (SL == 0) SL = 1;
                string strTenSP = txtSanphamName.Text;
                decimal Gia = decimal.Parse(txtDongia.Text);

                foreach (DataRow row in DBClass.tbGioHang.Rows)
                {//Kiem tr neu mat hang da co roi thi tang so luong len 1
                    if ((int)row["idSP"] == idSP)
                    {
                        row["SoLuong"] = (int)row["SoLuong"] + SL;
                        goto GioHang;
                    }
                }
                DBClass.tbGioHang.Rows.Add(idSP, strTenSP, Gia, SL);
                GioHang:
                Session["GioHang"] = DBClass.tbGioHang;
                Response.Redirect("default.aspx");
            }
            else
            {
                lblMessage.Text = "Nhập sai số lượng";
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}