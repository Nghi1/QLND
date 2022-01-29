using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeAnGK_Lttt
{
    public partial class ReportForm1 : Form
    {
        public ReportForm1()
        {
            InitializeComponent();
        }

        private void ReportForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetQuanLy.DangKyCV' table. You can move, or remove it, as needed.
            this.DangKyCVTableAdapter.Fill(this.DataSetQuanLy.DangKyCV);

            this.reportViewer1.RefreshReport();
        }
    }
}
