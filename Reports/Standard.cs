using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Reports
{
    public partial class Standard : Form
    {
        public string relatorio {get; set;}

        public Standard()
        {
            InitializeComponent();
            //Set the report processing mode          
            //this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //Assign report file i.e. rdlc             
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "GI.ServiceManager.ServiceReport.rdlc";
            //Add datasets            
            //this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ProcessData", Program.CurrentServiceInstrument.Data.tblServiceReportProcessData));            
            //this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("AccessoryData", Program.CurrentServiceInstrument.Data.tblServiceReportAccessoryData));            
            //this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Summary", Program.CurrentServiceInstrument.Data.tblServiceReportSummary));
            //Create the report parameters and assign values to it            
            //ReportParameter[] rParam = new ReportParameter[2];            
            //rParam[0] = new ReportParameter("rpUnitType", Convert.ToString(Program.CurrentServiceInstrument.Data.tblServiceReportSummary.Rows[0]["UnitType"]));            
            //rParam[1] = new ReportParameter("rpSerialNumber", Convert.ToString(Program.CurrentServiceInstrument.Data.tblServiceReportSummary.Rows[0]["SerialNumber"]));
            //Set report parameters            
            //this.reportViewer1.LocalReport.SetParameters(rParam);
            //Refresh report to render it            
            //this.reportViewer1.RefreshReport();
        }

        private void Standard_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistemaBDDataSet.Venda'. Você pode movê-la ou removê-la conforme necessário.
            this.vendaTableAdapter.Fill(this.sistemaBDDataSet.Venda);
            carregar();            
        }

        public void carregar ()
        {
            try
            {
                this.reportViewer1.ProcessingMode = ProcessingMode.Local;

                switch (relatorio)
                {
                    case "Venda":
                        this.vendaTableAdapter.FillByEntredatas(this.sistemaBDDataSet.Venda, dataTerminoDTP.Value.ToString("yyyy-MM-dd"), dataInicioDTP.Value.ToString("yyyy-MM-dd"));

                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Vendas.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dataInicio", this.vendaBindingSource));

                        this.Text = "Venda";
                        break;
                }


                //ReportParameter[] rParam = new ReportParameter[2];
                //rParam[0] = new ReportParameter("dataInicio", dataInicioDTP.Value.ToString("dd/MM/yyyy"));
                //rParam[1] = new ReportParameter("dataTermino", dataTerminoDTP.Value.ToString("dd/MM/yyyy"));
                //this.reportViewer1.LocalReport.SetParameters(rParam);
                
                this.reportViewer1.RefreshReport();                
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }

        }

        private void dataInicioDTP_ValueChanged(object sender, EventArgs e)
        {
            carregar();
        }

        private void dataTerminoDTP_ValueChanged(object sender, EventArgs e)
        {
            carregar();
        }
    }
}
