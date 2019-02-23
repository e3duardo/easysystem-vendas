using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Comissao
    {
        public Comissao()
        {
        }

        public long Id { get; set; }
        public Library.Funcionario Funcionario { get; set; }
        public Library.Venda Venda { get; set; }
        public string Tipo { get; set; }
        public int Pago { get; set; }
        public int Porcentagem { get; set; }
        public decimal Valor { get; set; }
    }
    public class ComissaoBD
    {
        private ComissaoBD()
        {
        }

        static public void Save(Library.Comissao comissao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Comissao (idFuncionario, idVenda, tipo, pago, porcentagem, valor)" +
                                                    "VALUES (@idFuncionario, @idVenda, @tipo, @pago, @porcentagem, @valor)" +
                                                    "SELECT CAST(scope_identity() AS bigint)";

                
                comando.Parameters.AddWithValue("@tipo", comissao.Tipo);
                comando.Parameters.AddWithValue("@pago", comissao.Pago);
                comando.Parameters.AddWithValue("@porcentagem", comissao.Porcentagem);
                comando.Parameters.AddWithValue("@valor", comissao.Valor);

                if (comissao.Funcionario != null)
                    comando.Parameters.AddWithValue("@idFuncionario", comissao.Funcionario.Id);
                else
                    comando.Parameters.AddWithValue("@idFuncionario", DBNull.Value);

                if (comissao.Venda != null)
                    comando.Parameters.AddWithValue("@idVenda", comissao.Venda.Id);
                else
                    comando.Parameters.AddWithValue("@idVenda", DBNull.Value);

                conexao.Open();

                //comando.ExecuteNonQuery();
                comissao.Id = (long)comando.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void Update(Library.Comissao comissao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Comissao SET idFuncionario = @idFuncionario, idVenda = @idVenda, tipo = @tipo, pago = @pago, porcentagem = @porcentagem, valor = @valor WHERE (id= " + comissao.Id + ")";
                
                comando.Parameters.AddWithValue("@tipo", comissao.Tipo);
                comando.Parameters.AddWithValue("@pago", comissao.Pago);
                comando.Parameters.AddWithValue("@porcentagem", comissao.Porcentagem);
                comando.Parameters.AddWithValue("@valor", comissao.Valor);

                if (comissao.Funcionario != null)
                    comando.Parameters.AddWithValue("@idFuncionario", comissao.Funcionario.Id);
                else
                    comando.Parameters.AddWithValue("@idFuncionario", DBNull.Value);

                if (comissao.Venda != null)
                    comando.Parameters.AddWithValue("@idVenda", comissao.Venda.Id);
                else
                    comando.Parameters.AddWithValue("@idVenda", DBNull.Value);
 
                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void DeleteById(long idComissao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Comissao WHERE id='" + idComissao + "'";

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.Comissao> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Comissao AS cm ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (p == 0)
                        pre = "WHERE ";
                    else
                        pre = "AND ";

                    p++;

                    switch (qi.Campo)
                    {
                        case "cm.id":
                            query += pre + "cm.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "ORDER BY":
                            query += " ORDER BY " + qi.Objeto;
                            break;
                    }
                }

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.Comissao> comissoes = new List<Library.Comissao>();

                while (rdr.Read())
                {
                    Library.Comissao comissao = new Comissao();
                    comissao.Id = (long)rdr["id"];
                    comissao.Tipo = rdr["tipo"].ToString();
                    comissao.Pago = (int)rdr["pago"];
                    comissao.Porcentagem = (int)rdr["porcentagem"];
                    comissao.Valor = (decimal)rdr["valor"];


                    if (!string.IsNullOrEmpty(rdr["idFuncionario"].ToString()))
                        comissao.Funcionario = Library.FuncionarioBD.FindById((long)rdr["idFuncionario"]);
                    else
                        comissao.Funcionario = null;

                    if (!string.IsNullOrEmpty(rdr["idVenda"].ToString()))
                        comissao.Venda = Library.VendaBD.FindVendaById((long)rdr["idVenda"]);
                    else
                        comissao.Venda = null;

                    comissoes.Add(comissao);
                }

                return comissoes;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
            return null;
        }

        static public Library.Comissao FindComissaoById(long idComissao)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Comissao comissao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Comissao WHERE id='" + idComissao + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Comissao");

                if (ds.Tables["Comissao"].Rows.Count == 1)
                {
                    comissao = new Comissao();
                    comissao.Id = (long)ds.Tables["Comissao"].Rows[0]["id"];
                    comissao.Tipo = ds.Tables["Comissao"].Rows[0]["tipo"].ToString();
                    comissao.Pago = (int)ds.Tables["Comissao"].Rows[0]["pago"];
                    comissao.Porcentagem = (int)ds.Tables["Comissao"].Rows[0]["porcentagem"];
                    comissao.Valor = (decimal)ds.Tables["Comissao"].Rows[0]["valor"];

                    if (!string.IsNullOrEmpty(ds.Tables["Comissao"].Rows[0]["idFuncionario"].ToString()))
                        comissao.Funcionario = Library.FuncionarioBD.FindById((long)ds.Tables["Comissao"].Rows[0]["idFuncionario"]);
                    else
                        comissao.Funcionario = null;

                    if (!string.IsNullOrEmpty(ds.Tables["Comissao"].Rows[0]["idVenda"].ToString()))
                        comissao.Venda = Library.VendaBD.FindVendaById((long)ds.Tables["Comissao"].Rows[0]["idVenda"]);
                    else
                        comissao.Venda = null;

                }
                return comissao;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
                dap.Dispose();
                ds.Dispose();
            }
            return null;
        }

        static public long GetNextId()
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "SELECT IDENT_CURRENT('Comissao') AS lastId";

                conexao.Open();
                long lastId = 0;
                long.TryParse(comando.ExecuteScalar().ToString(), out lastId);


                return lastId + 1;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }

    }
}
