﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _5444_PHANDUCDUNG
{
    class LOPDUNGCHUNG
    {
        string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\TOP500TG\HocKi2Nam3\END\5444_PHANDUCDUNG\5444_PHANDUCDUNG\QLTHUVIEN.mdf;Integrated Security=True";
        SqlConnection conn;
        public LOPDUNGCHUNG()
        {
            conn = new SqlConnection(chuoikn);
        }
        public int ThemXoaSua(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            return kq;
        }
        public DataTable LoadDL(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object LayGT(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object kq = comm.ExecuteScalar();
            conn.Close();
            return kq;
        }
    }
}
