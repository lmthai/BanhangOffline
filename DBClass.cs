using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanhangOffline
{
    public static class DBClass
    {
        // thu phuong an voi localdb
        public static DataTable tbGioHang = new DataTable();
        public static SqlConnection OpenConn()
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopConnection"].ConnectionString);
            myCon.Open();
            return myCon;
        }
    }
}