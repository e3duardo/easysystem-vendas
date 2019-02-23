using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restore
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog1 = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonProcurar_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Arquivo de Backup (.bak)|*.bak";
            openFileDialog1.Title = "Abrir Arquivo de Backup";
            //saveFileDialog1.OverwritePrompt = false;
            openFileDialog1.ShowDialog();
            comboBox1.Text = openFileDialog1.FileName;
        }

        private void buttonRestaurar_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text != "")
            {
                Execute(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("Por favor, selecione um arquivo!");
            }
        }


        public void Execute(string file)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                //comando.CommandText = "RESTORE FILELISTONLY FROM DISK = @back";
                comando.CommandText = "USE master RESTORE DATABASE VendaBD FROM DISK = @back";

                comando.Parameters.AddWithValue("@back", file);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
