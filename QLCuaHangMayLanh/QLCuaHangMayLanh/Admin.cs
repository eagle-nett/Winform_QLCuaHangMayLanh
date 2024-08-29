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
    public partial class Admin : Form
    {
        bool sidebarExpand;
        bool homeCollapse;

        public Admin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
                
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                   
                    sidebarTimer.Stop();
                }
            }

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void Hometimer_Tick(object sender, EventArgs e)
        {
            if (homeCollapse)
            {
                panelQL.Height += 10;
                if (panelQL.Height == panelQL.MaximumSize.Height)
                {
                    homeCollapse = false;
                    Hometimer.Stop();
                }
            }
            else
            {
                panelQL.Height -= 10;
                if (panelQL.Height == panelQL.MinimumSize.Height)
                {
                    homeCollapse = true;
                    Hometimer.Stop();
                }
            }
        }

        private void QuanLyContainer_Click(object sender, EventArgs e)
        {
            Hometimer.Start();
            
        }
        private void panelQL_Click(object sender, EventArgs e)
        {
            Hometimer.Start();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            qlNhanVien2.Visible = true;
            //trangchu1.Visible = false;
            quanLySanPham1.Visible = false;
            khachHang1.Visible = false;
            panel3.Visible = false;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //trangchu1.Visible = true;
            qlNhanVien2.Visible = false;
            quanLySanPham1.Visible = false;
            khachHang1.Visible = false;
            panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // trangchu1.Visible = true ;
            qlNhanVien2.Visible = false;
            quanLySanPham1.Visible = false;
            khachHang1.Visible = false;
            panel3.Visible = false;
        }

        private void trangchuQl1_Load(object sender, EventArgs e)
        {

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            //trangchu1.Visible = false;

            qlNhanVien2.Visible = false;
            quanLySanPham1.Visible = true;
            khachHang1.Visible = false;
            panel3.Visible = false;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
           // trangchu1.Visible = false;
            qlNhanVien2.Visible = false;
            quanLySanPham1.Visible = false;
            khachHang1.Visible = true;
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // trangchu1.Visible = false;
            qlNhanVien2.Visible = false;
            quanLySanPham1.Visible = false;
            khachHang1.Visible = false;
            panel3.Visible = true;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            hdlann ds = new hdlann();
            crystalReportViewer1.ReportSource = ds;
            ds.SetDatabaseLogon("sa", "naocavang", @"DESKTOP-10H09NS\MYSQL", "QLMayLanh");
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
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
