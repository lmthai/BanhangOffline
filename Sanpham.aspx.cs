using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanhangOffline
{
    public partial class Sanpham : System.Web.UI.Page
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
                    lblSanphamNew.Visible = false;
                    lblSanphamUpd.Visible = true;
                    btnAddSanpham.Visible = false;
                    btnUpdSanpham.Visible = true;
                }
                else
                {
                    lblSanphamNew.Visible = true;
                    lblSanphamUpd.Visible = false;
                    btnAddSanpham.Visible = true;
                    btnUpdSanpham.Visible = false;
                }
                GetNhomForDLL();
            }

        }
        protected void btnAddSanpham_Click(object sender, EventArgs e)
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand myCom = new SqlCommand("dbo.usp_InsSanpham", myCon))
                {
                    myCom.CommandType = CommandType.StoredProcedure;
                    myCom.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = txtSanphamName.Text;
                    myCom.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = txtSanphamMa.Text;
                    myCom.Parameters.Add("@Dvt", SqlDbType.NVarChar).Value = txtSanphamDVT.Text;
                    myCom.Parameters.Add("@Gia", SqlDbType.Decimal).Value = decimal.Parse(txtDongia.Text);
                    myCom.Parameters.Add("@NhomID", SqlDbType.Int).Value = int.Parse(ddlNhom.SelectedValue);

                    myCom.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in btnAddSanpham_Click: " + ex.Message; }
            finally { myCon.Close(); }
            Response.Redirect("Quanly.aspx");
        }
        private void GetNhomForDLL()
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand cmd = new SqlCommand("dbo.usp_GetNhoms", myCon))
                {
                    SqlDataReader myDr = cmd.ExecuteReader();

                    ddlNhom.DataSource = myDr;
                    ddlNhom.DataTextField = "Tennhom";
                    ddlNhom.DataValueField = "Manhom";
                    ddlNhom.DataBind();
                    ddlNhom.Items.Insert(0, new ListItem("-- Chọn nhóm --", "0"));

                    myDr.Close();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in GetNhomForDLL: " + ex.Message; }
            finally { myCon.Close(); }
        }
        protected void btnUpdSanpham_Click(object sender, EventArgs e)
        {
            UpdSanpham();
            Response.Redirect("Quanly.aspx");
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
                            ddlNhom.SelectedValue = myDr.GetValue(6).ToString();
                            lblSPID.Text = Comp_ID.ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in GetSanpham: " + ex.Message; }
            finally { myCon.Close(); }
        }
        private void UpdSanpham()
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand cmd = new SqlCommand("dbo.usp_UpdSanpham", myCon))
                {
                    cmd.Connection = myCon;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(lblSPID.Text);
                    cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = txtSanphamName.Text;
                    cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = txtSanphamMa.Text;
                    cmd.Parameters.Add("@Dvt", SqlDbType.NVarChar).Value = txtSanphamDVT.Text;
                    cmd.Parameters.Add("@Gia", SqlDbType.Decimal).Value = txtDongia.Text;
                    cmd.Parameters.Add("@NhomID", SqlDbType.Int).Value = ddlNhom.SelectedValue;


                    int rows = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in UpdSanpham: " + ex.Message; }
            finally { myCon.Close(); }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quanly.aspx");
        }
    }
}