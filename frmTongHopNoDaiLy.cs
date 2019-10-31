using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho.Controller;

namespace QuanLyKho
{
    public partial class frmTongHopNoDaiLy : Form
    {
        DuNo type = DuNo.BanSi;
        public frmTongHopNoDaiLy(DuNo _type)
        {
            type = _type;
            InitializeComponent();
        }
        PhieuBanController PB = new PhieuBanController();
        KhachHangController KH = new KhachHangController();
        private void frmTongHopNoKhachHang_Load(object sender, EventArgs e)
        {
            if (type == DuNo.BanSi)
            {
                KH.HienthiDaiLyDataGridviewComboBox(colID);
                PB.HienThiTongHopNoDaiLy(bindingNavigator1, dataGridView2);
                BusinessObject.Util.AdjustColumnOrder(ref dataGridView2);
            }
            else
            {
                KH.HienthiKhachHangDataGridviewComboBox(colID);
                PB.HienThiTongHopNoKhachHang(bindingNavigator1, dataGridView2);
                BusinessObject.Util.AdjustColumnOrder(ref dataGridView2);
            }
        }
        frmDuNoKhachHang duno = null;
        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (duno == null || duno.IsDisposed)
            {
                DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
                duno = new frmDuNoKhachHang(row["ID_KHACH_HANG"].ToString(), type);
                duno.WindowState = FormWindowState.Maximized;
                duno.MdiParent = this.MdiParent;
                foreach (var f in this.MdiParent.MdiChildren)
                {
                    if (f != duno)
                        f.Close();
                }
                duno.Show();
            }
            else
                duno.Activate();
        }
    }
}
