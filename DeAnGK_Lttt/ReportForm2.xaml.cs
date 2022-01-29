using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeAnGK_Lttt
{
    /// <summary>
    /// Interaction logic for ReportForm2.xaml
    /// </summary>
    public partial class ReportForm2 : Window
    {
        public ReportForm2()
        {
            InitializeComponent();
            _reportViewer.Load += _reportViewer_Load;
        }
        private bool _isReportViewerLoaded;
        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void _reportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 =
                            new Microsoft.Reporting.WinForms.ReportDataSource();

                QLNguoiDungDataSet1 dataset = new QLNguoiDungDataSet1();
                dataset.BeginInit();

                reportDataSource1.Name = "DataSetDK";
                reportDataSource1.Value = dataset.DangKyCV;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this._reportViewer.LocalReport.ReportEmbeddedResource =
                            "DeAnGK_Lttt.ReportQuanLy.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                QLNguoiDungDataSet1TableAdapters.DangKyCVTableAdapter datasetAdapter =
                            new QLNguoiDungDataSet1TableAdapters.DangKyCVTableAdapter();

                datasetAdapter.ClearBeforeFill = true;
                datasetAdapter.Fill(dataset.DangKyCV);

                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }
    }
}
