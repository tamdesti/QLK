using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.BusinessObject
{
    class Util
    {
        public static void AddSTTColumn(ref DataTable dt, ref BindingSource bs, ref BindingNavigator bn, ref DataGridView dg)
        {
            if (dt.Columns.IndexOf("STT") == -1)
            {
                dt.Columns.Add("STT");
            }
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            bs.DataSource = dt;
            bn.BindingSource = bs;
            dg.DataSource = bs;
            dg.Columns["STT"].DisplayIndex = 0;
            dg.Columns["STT"].Width = 30;
            Font font = new Font("Arial", 8.5F, FontStyle.Bold);
            dg.ColumnHeadersDefaultCellStyle.Font = font;
            dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void AdjustColumnOrder(ref DataGridView dg)
        {
            dg.AutoGenerateColumns = false;
            foreach (DataGridViewColumn col in dg.Columns)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
