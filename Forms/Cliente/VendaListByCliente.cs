using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;

namespace Forms.Cliente
{
    public partial class VendaListByCliente : Form
    {
        public VendaListByCliente()
        {
            InitializeComponent();
        }

        private void carregar()
        {
            try
            {
                List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced();

                this.dataGridViewResultado.Rows.Clear();
                foreach (Library.Cliente c in clientes)
                {
                    List<Library.VendaParcela> vendasparcelas = Library.ClienteBD.GetParcelasAtrasadasById(c.Id);

                    foreach (Library.VendaParcela vp in vendasparcelas)
                    {
                        this.dataGridViewResultado.Rows.Add(c.Nome, vp.Data, vp.Valor);
                    }
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        private void VendaListByCliente_Load(object sender, EventArgs e)
        {
            carregar();
        }

        private void VendaListByCliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
