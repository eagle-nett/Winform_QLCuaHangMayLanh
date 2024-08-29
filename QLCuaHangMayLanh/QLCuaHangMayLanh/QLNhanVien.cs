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
    public partial class QLNhanVien : UserControl
    {
        SqlConnection consql = new SqlConnection(@"Data Source=DESKTOP-10H09NS\MYSQL;Initial Catalog=QLMayLanh;Integrated Security=True");
        DataSet dsNV = new DataSet();
        SqlDataAdapter daNV;
        public QLNhanVien()
        {
            InitializeComponent();
        }
        void LoadDuLieuNhanVien()
        {
            string str = "select * from ThongTinNhanVien";
            daNV = new SqlDataAdapter(str, consql);
            daNV.Fill(dsNV, "ThongTinNhanVien");
            dataGVNV.DataSource = dsNV.Tables["ThongTinNhanVien"];
            DataColumn[] key = new DataColumn[1];
            key[0] = dsNV.Tables["ThongTinNhanVien"].Columns[0];
            dsNV.Tables["ThongTinNhanVien"].PrimaryKey = key;
        }
        void Loadcombobox()
        {
            string[] gt = { "Nam", "Nữ","Khác" };
            string[] maql = { "QA","TT","TD" };
            foreach(string s in gt)
            {
                cbGioiTinh.Items.Add(s);
            }    
            foreach(string a in maql)
            {
                cbMaQL.Items.Add(a);
            }    
        }
        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            Loadcombobox();
            LoadDuLieuNhanVien();
            txtMaNV.Enabled = txtTenNV.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = btnLuu.Enabled = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaNV.Enabled = txtTenNV.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = true;
            cbGioiTinh.Enabled = cbMaQL.Enabled = true;
            txtMaNV.Focus();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        private void dataGVNV_SelectionChanged(object sender, EventArgs e)
        {
            btn_sua.Enabled = btn_xoa.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
           txtTenNV.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = true;
            cbGioiTinh.Enabled = cbMaQL.Enabled = true;
            txtMaNV.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text==string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                txtMaNV.Focus();
                return;
            }    
            if(cbMaQL.Text==string.Empty)
            {
                MessageBox.Show("Vui lòng chọn mã của quản lý");
                return;
            }    
            if(txtMaNV.Enabled==true)
            {
                DataRow insert = dsNV.Tables["ThongTinNhanVien"].NewRow();
                insert["MaNhanVien"] = txtMaNV.Text;
                insert["TenNhanVien"] = txtTenNV.Text;
                insert["MaQuanLy"] = cbMaQL.Text;
                insert["DiaChi"] = txtDiaChi.Text;
                insert["GioiTinh"] = cbGioiTinh.Text;
                insert["Sdt"] = txtSDT.Text;
                dsNV.Tables["ThongTinNhanVien"].Rows.Add(insert);
            }
            else
            {
                DataRow update = dsNV.Tables["ThongTinNhanVien"].Rows.Find(txtMaNV.Text);
                if (update != null)
                {
                    update["TenNhanVien"] = txtTenNV.Text;
                    update["MaQuanLy"] = cbMaQL.Text;
                    update["DiaChi"] = txtDiaChi.Text;
                    update["GioiTinh"] = cbGioiTinh.Text;
                    update["Sdt"] = txtSDT.Text;
                }    
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(daNV);
            daNV.Update(dsNV, "ThongTinNhanVien");
            MessageBox.Show("Cập nhật thành công");
            btnLuu.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dta = new DataTable();
                SqlDataAdapter danv = new SqlDataAdapter("select * from ThongTinNhanVien where MaNhanVien='" + txtMaNV.Text + "'", consql);
                danv.Fill(dta);
                if(dta.Rows.Count>0)
                {
                    MessageBox.Show("Dữ liệu đang sử dụng không thể xóa");
                    return;
                }
                DataRow updatenew = dsNV.Tables["ThongTinNhanVien"].Rows.Find(txtMaNV.Text);
                if(updatenew!=null)
                {
                    updatenew.Delete();
                }
                SqlCommandBuilder cmb = new SqlCommandBuilder(daNV);
                daNV.Update(dsNV, "ThongTinNhanVien");
                MessageBox.Show("Thành Công");
            }    
        }
    }

}
