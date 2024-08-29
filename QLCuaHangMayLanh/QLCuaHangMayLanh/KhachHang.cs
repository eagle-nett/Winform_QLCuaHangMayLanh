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
    public partial class KhachHang : UserControl
    {
        SqlConnection consql = new SqlConnection(@"Data Source=DESKTOP-10H09NS\MYSQL;Initial Catalog=QLMayLanh;Integrated Security=True");
        DataSet dsKH = new DataSet();
        SqlDataAdapter daKH;
        public KhachHang()
        {
            InitializeComponent();
        }
        void LoadDuLieuNhanVien()
        {
            string str = "select * from KhachHang";
            daKH = new SqlDataAdapter(str, consql);
            daKH.Fill(dsKH, "KhachHang");
            dataGVKH.DataSource = dsKH.Tables["KhachHang"];
            DataColumn[] key = new DataColumn[1];
            key[0] = dsKH.Tables["KhachHang"].Columns[0];
            dsKH.Tables["KhachHang"].PrimaryKey = key;
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadDuLieuNhanVien();
            txtMaKH.Enabled = txtTenKH.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtEmail.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = btnLuu.Enabled = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaKH.Enabled = txtTenKH.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtEmail.Enabled = true;
            txtMaKH.Focus();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
        }

        private void dataGVKH_SelectionChanged(object sender, EventArgs e)
        {
            btn_sua.Enabled = btn_xoa.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTenKH.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtEmail.Enabled = true;
            txtMaKH.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                txtMaKH.Focus();
                return;
            }
            if (txtMaKH.Enabled == true)
            {
                DataRow insert = dsKH.Tables["KhachHang"].NewRow();
                insert["MaKhachHang"] = txtMaKH.Text;
                insert["HoTen"] = txtTenKH.Text;
                insert["DiaChi"] = txtDiaChi.Text;
                insert["DienThoai"] = txtSDT.Text;
                insert["Email"] = txtEmail.Text;
                dsKH.Tables["KhachHang"].Rows.Add(insert);
            }
            else
            {
                DataRow update = dsKH.Tables["KhachHang"].Rows.Find(txtMaKH.Text);
                if (update != null)
                {
                    update["HoTen"] = txtTenKH.Text;
                    update["DiaChi"] = txtDiaChi.Text;
                    update["DienThoai"] = txtSDT.Text;
                    update["Email"] = txtEmail.Text;
                }
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(daKH);
            daKH.Update(dsKH, "KhachHang");
            MessageBox.Show("Cập nhật thành công");
            btnLuu.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
               
                DataRow updatenew = dsKH.Tables["KhachHang"].Rows.Find(txtMaKH.Text);
                if (updatenew != null)
                {
                    updatenew.Delete();
                }
                SqlCommandBuilder cmb = new SqlCommandBuilder(daKH);
                daKH.Update(dsKH, "KhachHang");
                MessageBox.Show("Thành Công");
            }

        }
    }
}
