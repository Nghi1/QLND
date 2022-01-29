
namespace DeAnGK_Lttt
{
    partial class ReportForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetQuanLy = new DeAnGK_Lttt.DataSetQuanLy();
            this.DangKyCVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DangKyCVTableAdapter = new DeAnGK_Lttt.DataSetQuanLyTableAdapters.DangKyCVTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetQuanLy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DangKyCVBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DangKyCVBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DeAnGK_Lttt.ReportQuanLy.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(533, 292);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetQuanLy
            // 
            this.DataSetQuanLy.DataSetName = "DataSetQuanLy";
            this.DataSetQuanLy.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DangKyCVBindingSource
            // 
            this.DangKyCVBindingSource.DataMember = "DangKyCV";
            this.DangKyCVBindingSource.DataSource = this.DataSetQuanLy;
            // 
            // DangKyCVTableAdapter
            // 
            this.DangKyCVTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReportForm1";
            this.Text = "ReportForm1";
            this.Load += new System.EventHandler(this.ReportForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetQuanLy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DangKyCVBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DangKyCVBindingSource;
        private DataSetQuanLy DataSetQuanLy;
        private DataSetQuanLyTableAdapters.DangKyCVTableAdapter DangKyCVTableAdapter;
    }
}