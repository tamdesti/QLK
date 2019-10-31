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
    public partial class frmTongHopNoCongTy : Form
    {
        public frmTongHopNoCongTy()
        {
            InitializeComponent();
        }
        PhieuNhapController PN = new PhieuNhapController();
        NhaCungCapController NCC = new NhaCungCapController();
        private void frmTongHopNoCongTy_Load(object sender, EventArgs e)
        {
            NCC.HienthiDataGridviewComboBox(colID);
            PN.HienThiTongHopNoCongTy(bindingNavigator1, dataGridView1);
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView1);
        }
        frmDuNo duno = null;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (duno == null || duno.IsDisposed)
            {
                DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
                duno = new frmDuNo(row["ID_NHA_CUNG_CAP"].ToString());
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
