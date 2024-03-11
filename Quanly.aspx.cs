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
    public partial class Quanly : System.Web.UI.Page
    {
        int SP_ID;
        //SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopConnection"].ConnectionString);
        SqlConnection myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DoGridView();
            }
        }
        private void DoGridView()
        {
            try
            {
                myCon = DBClass.OpenConn();
                int nhomID = 0;
                if (ListNhom.SelectedIndex > -1)
                {
                    nhomID = Convert.ToInt32(ListNhom.SelectedItem.Value);
                }
                using (SqlCommand myCom = new SqlCommand("dbo.usp_GetProducts", myCon))
                {
                    myCom.Parameters.Add("@NhomID", sqlDbType: SqlDbType.VarChar).Value = nhomID;
                    myCom.Connection = myCon;
                    myCom.CommandType = CommandType.StoredProcedure;

                    SqlDataReader myDr = myCom.ExecuteReader();

                    gvSanphams.DataSource = myDr;
                    gvSanphams.DataBind();

                    myDr.Close();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in Sanpham doGridView: " + ex.Message; }
            finally { myCon.Close(); }
        }
        protected void lbNewSanpham_Click(object sender, EventArgs e)
        {
                Response.Redirect("Sanpham.aspx?id=0");
        }
        protected void gvSanphams_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdSanpham")
            {
                SP_ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Sanpham.aspx?id="+ SP_ID);
            }
        }

        protected void gvSanphams_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            SP_ID = Convert.ToInt32(gvSanphams.DataKeys[e.RowIndex].Value.ToString());

            try
            {
                //myCon.Open();
                myCon = DBClass.OpenConn();
                using (SqlCommand cmd = new SqlCommand("dbo.usp_DelSanpham", myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SP_ID;
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in gvSanphams_RowDeleting: " + ex.Message; }
            finally { myCon.Close(); }
            DoGridView();
        }

        protected void ShowNhom(object sender, EventArgs e)
        {
            DoGridView();
        }
    }
}