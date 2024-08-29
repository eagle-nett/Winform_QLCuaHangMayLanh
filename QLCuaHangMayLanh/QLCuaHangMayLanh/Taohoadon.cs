using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLCuaHangMayLanh
{
    public partial class Taohoadon : UserControl
    {
        SqlConnection consql = new SqlConnection(@"Data Source=DESKTOP-10H09NS\MYSQL;Initial Catalog=QLMayLanh;Integrated Security=True");
        DataSet dsHD = new DataSet();
        SqlDataAdapter daHD;

        public Taohoadon()
        {
            InitializeComponent();
        }
        void LoadDuLieuHoaDon()
        {
            string str = "select * from HoaDonBan";
            daHD = new SqlDataAdapter(str, consql);
            daHD.Fill(dsHD, "HoaDonBan");
            dataGVNV.DataSource = dsHD.Tables["HoaDonBan"];
            DataColumn[] key = new DataColumn[1];
            key[0] = dsHD.Tables["HoaDonBan"].Columns[0];
            dsHD.Tables["HoaDonBan"].PrimaryKey = key;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtDG.Enabled = txtMaHD.Enabled = txtMaKH.Enabled = txtMaNV.Enabled = txtMaSP.Enabled = txtNgay.Enabled = txtSL.Enabled = true;
            txtMaNV.Focus();
            txtMaNV.Clear();
            txtDG.Clear();
            txtMaHD.Clear();
            txtMaKH.Clear();
            txtMaNV.Clear();
            txtMaSP.Clear();
            txtNgay.Clear();
            txtSL.Clear();
        }

        private void Taohoadon_Load(object sender, EventArgs e)
        {
            LoadDuLieuHoaDon();
            txtMaNV.Enabled = txtDG.Enabled = txtMaHD.Enabled = txtMaKH.Enabled = txtMaSP.Enabled = txtNgay.Enabled = txtSL.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = btnLuu.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtDG.Enabled = txtMaHD.Enabled = txtMaKH.Enabled = txtMaSP.Enabled = txtNgay.Enabled = txtSL.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int a, b;
            a = int.Parse(txtDG.Text);
            b = int.Parse(txtSL.Text);
            if (txtMaNV.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                txtMaNV.Focus();
                return;
            }
            if (txtMaNV.Enabled == true)
            {
                DataRow insert = dsHD.Tables["HoaDonBan"].NewRow();
                insert["MaNhanVien"] = txtMaNV.Text;
                insert["MaHd"] = txtMaHD.Text;
                insert["MaKhachHang"] = txtMaKH.Text;
                insert["MaSanPham"] = txtMaSP.Text;
                insert["NgayLapHd"] = txtNgay.Text;
                insert["SoLuongMua"] = txtSL.Text;
                insert["DonGia"] = txtDG.Text;
                insert["TongTien"] = a * b;
                dsHD.Tables["HoaDonBan"].Rows.Add(insert);
            }
            else
            {
                DataRow update = dsHD.Tables["HoaDonBan"].Rows.Find(txtMaNV.Text);
                if (update != null)
                {
                    update["MaNhanVien"] = txtMaNV.Text;
                    update["MaKhachHang"] = txtMaKH.Text;
                    update["MaSanPham"] = txtMaSP.Text;
                    update["NgayLapHd"] = txtNgay.Text;
                    update["SoLuongMua"] = txtSL.Text;
                    update["DonGia"] = txtDG.Text;
                    update["TongTien"] = a * b;
                }
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(daHD);
            daHD.Update(dsHD, "HoaDonBan");
            MessageBox.Show("Cập nhật thành công");
            btnLuu.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dta = new DataTable();
                SqlDataAdapter dahd = new SqlDataAdapter("select * from HoaDonBan where MaHd='" + txtMaHD.Text + "'", consql);
                dahd.Fill(dta);
                if (dta.Rows.Count > 0)
                {
                    MessageBox.Show("Dữ liệu đang sử dụng không thể xóa");
                    return;
                }
                DataRow updatenew = dsHD.Tables["HoaDonBan"].Rows.Find(txtMaHD.Text);
                if (updatenew != null)
                {
                    updatenew.Delete();
                }
                SqlCommandBuilder cmb = new SqlCommandBuilder(daHD);
                daHD.Update(dsHD, "HoaDonBan");
                MessageBox.Show("Thành Công");
            }
        }
    }
}
