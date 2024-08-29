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

    
    public partial class QuanLySanPham : UserControl
    {
        SqlConnection consql = new SqlConnection(@"Data Source=DESKTOP-10H09NS\MYSQL;Initial Catalog=QLMayLanh;Integrated Security=True");
        DataSet dsSP = new DataSet();
        SqlDataAdapter daSP;
        public QuanLySanPham()
        {
            InitializeComponent();
        }
        void LoadDuLieuSanPham()
        {
            string str = "select * from SanPham";
            daSP = new SqlDataAdapter(str, consql);
            daSP.Fill(dsSP, "SanPham");
            dataGVNV.DataSource = dsSP.Tables["SanPham"];
            DataColumn[] key = new DataColumn[1];
            key[0] = dsSP.Tables["SanPham"].Columns[0];
            dsSP.Tables["SanPham"].PrimaryKey = key;
        }
        void Loadcombobox()
        { 
            string[] math = { "Panasonic", "Sharp","LG","Daikin","Funiki","Toshiba","Aqua","Midea","Samsung","Hitachi" };
            foreach (string s in math)
            {
                cbMTH.Items.Add(s);
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaSP.Enabled = txtTenSP.Enabled = txtSL.Enabled = txtDG.Enabled = true;
            cbMTH.Enabled = true;
            txtMaSP.Focus();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSL.Clear();
            txtDG.Clear();
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            Loadcombobox();
            LoadDuLieuSanPham();
            txtMaSP.Enabled = txtTenSP.Enabled = txtDG.Enabled = txtSL.Enabled = false;
            cbMTH.Enabled = false;
            btn_xoa.Enabled = btn_sua.Enabled = btnLuu.Enabled = false;
        }

        private void dataGVNV_SelectionChanged(object sender, EventArgs e)
        {
            btn_sua.Enabled = btn_xoa.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTenSP.Enabled = txtSL.Enabled = txtDG.Enabled = true;
            cbMTH.Enabled = true;
            txtMaSP.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm");
                txtMaSP.Focus();
                return;
            }
            if (cbMTH.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn mã của thương hiệu");
                return;
            }
            if (txtMaSP.Enabled == true)
            {
                DataRow insert = dsSP.Tables["SanPham"].NewRow();
                insert["MaSanPham"] = txtMaSP.Text;
                insert["TenSanPham"] = txtTenSP.Text;
                insert["MaThuongHieu"] = cbMTH.Text;
                insert["SoLuong"] = txtSL.Text;
                insert["DonGia"] = txtDG.Text;
                dsSP.Tables["SanPham"].Rows.Add(insert);
            }
            else
            {
                DataRow update = dsSP.Tables["SanPham"].Rows.Find(txtMaSP.Text);
                if (update != null)
                {
                    update["TenSanPham"] = txtTenSP.Text;
                    update["MaThuongHieu"] = cbMTH.Text;
                    update["SoLuong"] = txtSL.Text;
                    update["DonGia"] = txtDG.Text;
                }
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(daSP);
            daSP.Update(dsSP, "SanPham");
            MessageBox.Show("Cập nhật thành công");
            btnLuu.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dta = new DataTable();
                SqlDataAdapter dasp = new SqlDataAdapter("select * from SanPham where MaSanPham='" + txtMaSP.Text + "'", consql);
                dasp.Fill(dta);
                if (dta.Rows.Count > 0)
                {
                    MessageBox.Show("Dữ liệu đang sử dụng không thể xóa");
                    return;
                }
                DataRow updatenew = dsSP.Tables["SanPham"].Rows.Find(txtMaSP.Text);
                if (updatenew != null)
                {
                    updatenew.Delete();
                }
                SqlCommandBuilder cmb = new SqlCommandBuilder(daSP);
                daSP.Update(dsSP, "SanPham");
                MessageBox.Show("Thành Công");
            }
        }
    }
}
