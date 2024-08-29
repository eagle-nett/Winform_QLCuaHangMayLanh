using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangMayLanh
{
    public partial class NhanVien : Form
    {
        Trangchu tc = new Trangchu();
        Taohoadon thd = new Taohoadon();
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            thd.Visible = false;
            tc.Visible = true;
            panel3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tc.Visible = false;
            thd.Visible = false;
            panel3.Visible = true;
            SanPham sp = new SanPham();
            sp.SetDatabaseLogon("sa", "naocavang", @"DESKTOP-10H09NS\MYSQL", "QLMayLanh");
            crystalReportViewer1.ReportSource = sp;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tc.Visible = false;
            thd.Visible = false;
            panel3.Visible = true;
            khrpt kh = new khrpt();
            kh.SetDatabaseLogon("sa", "naocavang", @"DESKTOP-10H09NS\MYSQL", "QLMayLanh");
            crystalReportViewer1.ReportSource = kh;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tc.Visible = false;
            panel3.Visible = false;
            thd.Visible = true;
        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
