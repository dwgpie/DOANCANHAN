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
    public partial class frm_KhachHang : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();

        public frm_KhachHang()
        {
            InitializeComponent();
        }

        public void LoadKH()
        {
            string sql = "Select * from KHACHHANG";
            data_KH.DataSource = lopchung.LoadDL(sql);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert into KHACHHANG values ('" + txt_MaKH.Text + "', N'" + txt_HoTen.Text + "', N'" + txt_DiaChi.Text + "', Convert(datetime,'" + date_NgaySinh.Text + "',103), N'" + cb_TheLoaiSach.SelectedValue + "', Convert(datetime,'" + date_NgayMuon.Text + "',103), Convert(datetime,'" + date_NgayTra.Text + "',103))";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Thêm Khách Hàng thành công");
            else MessageBox.Show("Thêm Khách Hàng thất bại");
            LoadKH();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKH();
            string sql = "Select * from SACH";
            cb_TheLoaiSach.DataSource = lopchung.LoadDL(sql);
            cb_TheLoaiSach.DisplayMember = "TENSACH";
            cb_TheLoaiSach.ValueMember = "MASACH";

        }

        private void data_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaKH.Text = data_KH.CurrentRow.Cells["MAKH"].Value.ToString();
            txt_HoTen.Text = data_KH.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_DiaChi.Text = data_KH.CurrentRow.Cells["DIACHI"].Value.ToString();
            date_NgaySinh.Text = data_KH.CurrentRow.Cells["NGAYSINH"].Value.ToString();
            cb_TheLoaiSach.SelectedValue = data_KH.CurrentRow.Cells["MASACH"].Value.ToString();
            date_NgayMuon.Text = data_KH.CurrentRow.Cells["NGAYMUON"].Value.ToString();
            date_NgayTra.Text = data_KH.CurrentRow.Cells["NGAYTRA"].Value.ToString();

        }

        private void btn_Dem_Click(object sender, EventArgs e)
        {
            string sql = "Select COUNT (*) from KHACHHANG";
            int sosv = (int)lopchung.LayGT(sql);
            txt_SoKH.Text = sosv.ToString();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete KHACHHANG where MAKH = '" + txt_MaKH.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Xoá Khách Hàng thành công");
            else MessageBox.Show("Xoá Khách Hàng thất bại");
            LoadKH();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update KHACHHANG set HOTEN = N'" + txt_HoTen.Text + "',DIACHI = N'" + txt_DiaChi.Text + "',NGAYSINH = Convert(datetime,'" + date_NgaySinh.Text + "',103),NGAYMUON = Convert(datetime,'" + date_NgayMuon.Text + "',103), NGAYTRA = Convert(datetime,'" + date_NgayTra.Text + "',103),MASACH = '" + cb_TheLoaiSach.SelectedValue + "' where MAKH ='" + txt_MaKH.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1) MessageBox.Show("Cập nhật Khách Hàng thành công");
            else MessageBox.Show("Cập nhật Khách Hàng thất bại");
            LoadKH();
        }

        private void btn_Thoát_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn đóng không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
