namespace Reports
{
    partial class nota_venda
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
            this.sistemaBDDataSet = new Reports.SistemaBDDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vendaProduto1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendaProduto1TableAdapter = new Reports.SistemaBDDataSetTableAdapters.VendaProduto1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaBDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaProduto1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sistemaBDDataSet
            // 
            this.sistemaBDDataSet.DataSetName = "SistemaBDDataSet";
            this.sistemaBDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.nota_venda.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(852, 566);
            this.reportViewer1.TabIndex = 0;
            // 
            // vendaProduto1BindingSource
            // 
            this.vendaProduto1BindingSource.DataMember = "VendaProduto1";
            this.vendaProduto1BindingSource.DataSource = this.sistemaBDDataSet;
            // 
            // vendaProduto1TableAdapter
            // 
            this.vendaProduto1TableAdapter.ClearBeforeFill = true;
            // 
            // nota_venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 566);
            this.Controls.Add(this.reportViewer1);
            this.Name = "nota_venda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaBDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaProduto1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SistemaBDDataSet sistemaBDDataSet;
        private System.Windows.Forms.BindingSource vendaProduto1BindingSource;
        private Reports.SistemaBDDataSetTableAdapters.VendaProduto1TableAdapter vendaProduto1TableAdapter;
    }
}