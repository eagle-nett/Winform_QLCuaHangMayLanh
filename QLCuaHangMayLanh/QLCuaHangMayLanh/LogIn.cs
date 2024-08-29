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
    public partial class LogIn : Form
    {
        SqlConnection consql = new SqlConnection(@"Data Source=DESKTOP-10H09NS\MYSQL;Initial Catalog=QLMayLanh;Integrated Security=True");
        public LogIn()
        {
            InitializeComponent();
        }
        bool KTQL(string username, string password)
        {
            try
            {
                consql.Open();
                string select = "select count(*) from TaiKhoanQuanLy where TaiKhoanQL ='" + username + "' and MatKhauQL ='" + password + "'";
                SqlCommand cmd = new SqlCommand(select, consql);
                int count = (int)cmd.ExecuteScalar();
                consql.Close();
                if(count==1)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        bool KTNV(string username, string password)
        {
            try
            {
                consql.Open();
                string select = "select count(*) from TaiKhoanNhanVien where TaiKhoanNV ='" + username + "' and MatKhauNV ='" + password + "'";
                SqlCommand cmd = new SqlCommand(select, consql);
                int count = (int)cmd.ExecuteScalar();
                consql.Close();
                if (count == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (KTQL(txtusername.Text, txtpassword.Text) == true)
            {
                Admin ad = new Admin();
                this.Hide();
                ad.ShowDialog();
                this.Show();

            }
            else if (KTNV(txtusername.Text, txtpassword.Text) == true)
            {
                NhanVien nv = new NhanVien();
                this.Hide();
                nv.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không đúng");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
