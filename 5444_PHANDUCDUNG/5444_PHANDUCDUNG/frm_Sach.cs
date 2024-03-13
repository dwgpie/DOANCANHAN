using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5444_PHANDUCDUNG
{
    public partial class frm_Sach : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();

        public frm_Sach()
        {
            InitializeComponent();
        }

        public void LoadSach()
        {
            string sql = "Select * from SACH";
            data_SACH.DataSource = lopchung.LoadDL(sql);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert into SACH values ('" + txt_MaSach.Text + "', N'" + txt_TenSach.Text + "', N'" + txt_SoLuong.Text + "', N'" + txt_XuatBan.Text + "')";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Thêm Sách thành công");
            else MessageBox.Show("Thêm Sách thất bại");
            LoadSach();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete SACH where MASACH = '" + txt_MaSach.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Xoá Sách thành công");
            else MessageBox.Show("Xoá Sách thất bại");
            LoadSach();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update SACH set TENSACH = N'" + txt_TenSach.Text + "',SOLUONG = N'" + txt_SoLuong.Text + "',XUATBAN = N'" + txt_XuatBan.Text + "' where MASACH ='" + txt_MaSach.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Cập nhật Sách thành công");
            else MessageBox.Show("Cập nhật Sách thất bại");
            LoadSach();
        }

        private void btn_Thoát_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn đóng không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frm_Sach_Load(object sender, EventArgs e)
        {
            LoadSach();

        }

        private void data_SACH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaSach.Text = data_SACH.CurrentRow.Cells["MASACH"].Value.ToString();
            txt_TenSach.Text = data_SACH.CurrentRow.Cells["TENSACH"].Value.ToString();
            txt_SoLuong.Text = data_SACH.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txt_XuatBan.Text = data_SACH.CurrentRow.Cells["XUATBAN"].Value.ToString();

        }
    }
}
