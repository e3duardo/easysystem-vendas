using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Library.Converter;

namespace Reports
{
    public partial class nota_orcamento : Form
    {
        public Library.Condicional Orcamento { get; set; }

        public nota_orcamento()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.orcamentoProduto1TableAdapter.FillByIdOrcamento(this.sistemaBDDataSet.OrcamentoProduto1, this.Orcamento.Id);

            Microsoft.Reporting.WinForms.ReportParameter rp0 = new Microsoft.Reporting.WinForms.ReportParameter("cliente", this.Orcamento.Cliente.Nome);
            Microsoft.Reporting.WinForms.ReportParameter rp1 = new Microsoft.Reporting.WinForms.ReportParameter("endereco", this.Orcamento.Cliente.Endereco);
            Microsoft.Reporting.WinForms.ReportParameter rp2 = new Microsoft.Reporting.WinForms.ReportParameter("bairro", this.Orcamento.Cliente.Bairro);
            Microsoft.Reporting.WinForms.ReportParameter rp3 = new Microsoft.Reporting.WinForms.ReportParameter("cidade", this.Orcamento.Cliente.Cidade);
            Microsoft.Reporting.WinForms.ReportParameter rp4 = new Microsoft.Reporting.WinForms.ReportParameter("estado", this.Orcamento.Cliente.Estado);
            Microsoft.Reporting.WinForms.ReportParameter rp5 = new Microsoft.Reporting.WinForms.ReportParameter("cnpjcpf", this.Orcamento.Cliente.Cpf);
            Microsoft.Reporting.WinForms.ReportParameter rp6 = new Microsoft.Reporting.WinForms.ReportParameter("inscricaoestadual", this.Orcamento.Cliente.InscricaoEstadual);
            Microsoft.Reporting.WinForms.ReportParameter rp7 = new Microsoft.Reporting.WinForms.ReportParameter("idOrcamento", this.Orcamento.Id.ToString());
            Microsoft.Reporting.WinForms.ReportParameter rp8 = new Microsoft.Reporting.WinForms.ReportParameter("data", this.Orcamento.Data.Value.ToString("dd/MM/yyyy"));
            Microsoft.Reporting.WinForms.ReportParameter rp9 = new Microsoft.Reporting.WinForms.ReportParameter("valorTotal", this.Orcamento.Valor.ConvertToMoneyString());

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp0, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9 });

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            this.reportViewer1.RefreshReport();
        }

        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet1", this.orcamentoProduto1BindingSource));
            //this.reportViewer1.RefreshReport();
        }
    }
}
