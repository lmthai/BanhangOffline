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
        public static DataTable tbGioHang = new DataTable();
        int SP_ID;
        SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GioHang"] != null)
                {
                    tbGioHang = Session["GioHang"] as DataTable;
                }
                else
                {
                    tbGioHang.Rows.Clear();
                    tbGioHang.Columns.Clear();
                    tbGioHang.Columns.Add("idSP", typeof(int));
                    tbGioHang.Columns.Add("TenSP", typeof(string));
                    tbGioHang.Columns.Add("Gia", typeof(decimal));
                    tbGioHang.Columns.Add("SoLuong", typeof(int));
                    tbGioHang.Columns.Add("TongTien", typeof(decimal), "SoLuong * Gia");
                }
                lbGiohang.Text = "Giỏ hàng (" + tbGioHang.Rows.Count + ")";
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
        private void GetSanpham(int Comp_ID)
        {
            try
            {
                myCon.Open();
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
                            //txtSanphamName.Text = myDr.GetValue(1).ToString();
                            //txtSanphamMa.Text = myDr.GetValue(2).ToString();
                            //txtSanphamDVT.Text = myDr.GetValue(3).ToString();
                            //txtDongia.Text = myDr.GetValue(4).ToString();
                            //lblSPID.Text = Comp_ID.ToString();
                            //Image1.ImageUrl= "~/Images/" + myDr.GetValue(5).ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in GetSanpham: " + ex.Message; }
            finally { myCon.Close(); }
        }

        protected void listSanphams_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XemSanpham")
            {
                SP_ID = Convert.ToInt32(e.CommandArgument);


                //txtSanphamName.Text = "";
                //txtSanphamMa.Text = "";
                //txtSanphamDVT.Text = "";
                //txtDongia.Text = "";

                GetSanpham(SP_ID);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openSPDetail();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { openSPDetail(); });", true);
            }
        }
        protected void ShowNhom(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            //string curItem = ListNhom.SelectedItem.ToString();
            DoGridView();

        }
        //protected void btnChonSanpham_Click(object sender, EventArgs e)
        //{
        //    int idSP = int.Parse(lblSPID.Text);
        //    string strTenSP = txtSanphamName.Text;
        //    decimal Gia = decimal.Parse(txtDongia.Text);

        //    foreach (DataRow row in tbGioHang.Rows)
        //    {//Kiem tr neu mat hang da co roi thi tang so luong len 1
        //        if ((int)row["idSP"] == idSP)
        //        {
        //            row["SoLuong"] = (int)row["SoLuong"] + 1;
        //            goto GioHang;
        //        }
        //    }
        //    tbGioHang.Rows.Add(idSP, strTenSP, Gia, 1);
        //    GioHang:
        //    lbGiohang.Text = "Giỏ hàng (" + tbGioHang.Rows.Count + ")";
        //    Session["GioHang"] = tbGioHang;

        //}

        protected void lbGiohang_Click(object sender, EventArgs e)
        {
            //GridView1.DataSource = tbGioHang;
            //GridView1.DataBind();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { openGiohang(); });", true);

        }

        //protected void GridView1_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        //{
        //    //SP_ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //    tbGioHang.Rows[e.RowIndex].Delete();
        //    lbGiohang.Text = "Giỏ hàng (" + tbGioHang.Rows.Count + ")";

        //    GridView1.DataSource = tbGioHang;
        //    GridView1.DataBind();
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$(function() { openGiohang(); });", true);
        //}

        protected void btnDathang_Click(object sender, EventArgs e)
        {
            string user = (string)Session["username"];
            if (string.IsNullOrEmpty(user) == true)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}