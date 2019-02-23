using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class CaixaTransacao
    {
        public CaixaTransacao()
        {
        }

        public long Id { get; set; }
        public Library.Caixa Caixa { get; set; }
        public TimeSpan? Hora { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public Library.Despesa Despesa { get; set; }
        public Library.Venda Venda { get; set; }
        public Library.VendaParcela VendaParcela { get; set; }
        public Library.Comissao Comissao { get; set; }
        public Library.Cheque Cheque { get; set; }
        public Library.Cartao Cartao { get; set; }
    }
    public class CaixaTransacaoBD
    {
        private CaixaTransacaoBD()
        {
        }

        static public void Save(Library.CaixaTransacao caixaTransacao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO CaixaTransacao (idCaixa, hora, tipo, valor, idDespesa, idVenda, idVendaParcela, idComissao, idCheque, idCartao) VALUES (@idCaixa, @hora, @tipo, @valor, @idDespesa, @idVenda, @idVendaParcela, @idComissao, @idCheque, @idCartao)"
                + "SELECT CAST(scope_identity() AS bigint)";

                if (caixaTransacao.Caixa != null)
                    comando.Parameters.AddWithValue("@idCaixa", caixaTransacao.Caixa.Id);
                else
                    comando.Parameters.AddWithValue("@idCaixa", DBNull.Value);

                comando.Parameters.AddWithValue("@hora", caixaTransacao.Hora);
                comando.Parameters.AddWithValue("@tipo", caixaTransacao.Tipo);
                comando.Parameters.AddWithValue("@valor", caixaTransacao.Valor);

                if (caixaTransacao.Despesa != null)
                    comando.Parameters.AddWithValue("@idDespesa", caixaTransacao.Despesa.Id);
                else
                    comando.Parameters.AddWithValue("@idDespesa", DBNull.Value);

                if (caixaTransacao.Venda != null)
                    comando.Parameters.AddWithValue("@idVenda", caixaTransacao.Venda.Id);
                else
                    comando.Parameters.AddWithValue("@idVenda", DBNull.Value);

                if (caixaTransacao.VendaParcela != null)
                    comando.Parameters.AddWithValue("@idVendaParcela", caixaTransacao.VendaParcela.Id);
                else
                    comando.Parameters.AddWithValue("@idVendaParcela", DBNull.Value);

                if (caixaTransacao.Comissao != null)
                    comando.Parameters.AddWithValue("@idComissao", caixaTransacao.Comissao.Id);
                else
                    comando.Parameters.AddWithValue("@idComissao", DBNull.Value);

                if (caixaTransacao.Cheque != null)
                    comando.Parameters.AddWithValue("@idCheque", caixaTransacao.Cheque.Id);
                else
                    comando.Parameters.AddWithValue("@idCheque", DBNull.Value);

                if (caixaTransacao.Cartao != null)
                    comando.Parameters.AddWithValue("@idCartao", caixaTransacao.Cartao.Id);
                else
                    comando.Parameters.AddWithValue("@idCartao", DBNull.Value);


                conexao.Open();

                //comando.ExecuteNonQuery();
                caixaTransacao.Id = (long)comando.ExecuteScalar();

                if (caixaTransacao.Caixa != null)
                {
                    decimal saldo = 0;
                    if (caixaTransacao.Valor > 0)
                        saldo = caixaTransacao.Caixa.Saldo + caixaTransacao.Valor;
                    else
                        saldo = caixaTransacao.Caixa.Saldo - -caixaTransacao.Valor;

                    caixaTransacao.Caixa.Saldo = saldo;
                    Library.CaixaBD.Update(caixaTransacao.Caixa);
                }
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void Delete(Library.CaixaTransacao caixaTransacao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM CaixaTransacao WHERE id='" + caixaTransacao.Id + "'";

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.CaixaTransacao> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                using (SqlCommand comando = new SqlCommand())
                {

                    string query = "SELECT * FROM CaixaTransacao AS ct " +
                        " LEFT JOIN Venda AS v ON v.id = ct.idVenda ";

                    int p = 0;
                    string pre = "";
                    foreach (Library.Classes.QItem qi in args)
                    {
                        if (p == 0)
                            pre = "WHERE ";
                        else
                            pre = " AND ";

                        p++;

                        switch (qi.Campo)
                        {
                            case "ct.id":
                                query += pre + "ct.id = @id";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "ct.idCaixa":
                                query += pre + "ct.idCaixa = @idCaixa";
                                comando.Parameters.AddWithValue("@idCaixa", qi.Objeto);
                                break;
                            case "ct.hora":
                                query += pre + "ct.hora = @hora";
                                comando.Parameters.AddWithValue("@hora", qi.Objeto);
                                break;
                            case "ct.tipo":
                                query += pre + "ct.tipo = @tipo";
                                comando.Parameters.AddWithValue("@tipo", qi.Objeto);
                                break;
                            case "ct.valor":
                                query += pre + "ct.valor = @valor";
                                comando.Parameters.AddWithValue("@valor", qi.Objeto);
                                break;
                            case "v.id":
                                query += pre + "v.id = @idVenda";
                                comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
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
                }

                List<Library.CaixaTransacao> caixaTransacoes = new List<Library.CaixaTransacao>();

                while (rdr.Read())
                {
                    Library.CaixaTransacao caixaTransacao = new CaixaTransacao();
                    caixaTransacao.Id = (long)rdr["id"];
                    caixaTransacao.Caixa = Library.CaixaBD.FindCaixaById((long)rdr["idCaixa"]);
                    caixaTransacao.Hora = (TimeSpan)rdr["hora"];
                    caixaTransacao.Tipo = rdr["tipo"].ToString();
                    caixaTransacao.Valor = (decimal)rdr["valor"];

                    if (!string.IsNullOrEmpty(rdr["idDespesa"].ToString()))
                        caixaTransacao.Despesa = Library.DespesaBD.FindDespesaById((long)rdr["idDespesa"]);
                    else
                        caixaTransacao.Despesa = null;

                    if (!string.IsNullOrEmpty(rdr["idVenda"].ToString()))
                        caixaTransacao.Venda = Library.VendaBD.FindVendaById((long)rdr["idVenda"]);
                    else
                        caixaTransacao.Venda = null;

                    if (!string.IsNullOrEmpty(rdr["idVendaParcela"].ToString()))
                        caixaTransacao.VendaParcela = Library.VendaParcelaBD.FindVendaParcelaById((long)rdr["idVendaParcela"]);
                    else
                        caixaTransacao.VendaParcela = null;

                    if (!string.IsNullOrEmpty(rdr["idComissao"].ToString()))
                        caixaTransacao.Comissao = Library.ComissaoBD.FindComissaoById((long)rdr["idComissao"]);
                    else
                        caixaTransacao.Comissao = null;

                    if (!string.IsNullOrEmpty(rdr["idCheque"].ToString()))
                        caixaTransacao.Cheque = Library.ChequeBD.FindChequeById((long)rdr["idCheque"]);
                    else
                        caixaTransacao.Cheque = null;

                    if (!string.IsNullOrEmpty(rdr["idCartao"].ToString()))
                        caixaTransacao.Cartao = Library.CartaoBD.FindCartaoById((long)rdr["idCartao"]);
                    else
                        caixaTransacao.Cartao = null;

                    caixaTransacoes.Add(caixaTransacao);
                }

                return caixaTransacoes;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return null;
        }

        static public Library.CaixaTransacao FindCaixaTransacaoById(long idCaixaTransacao)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.CaixaTransacao caixaTransacao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM CaixaTransacao WHERE id=" + idCaixaTransacao + "", conexao);

                ds = new DataSet();

                dap.Fill(ds, "CaixaTransacao");

                if (ds.Tables["CaixaTransacao"].Rows.Count == 1)
                {
                    caixaTransacao = new CaixaTransacao();
                    caixaTransacao.Id = (long)ds.Tables["CaixaTransacao"].Rows[0]["id"];
                    caixaTransacao.Caixa = Library.CaixaBD.FindCaixaById((long)ds.Tables["CaixaTransacao"].Rows[0]["idCaixa"]);
                    caixaTransacao.Hora = (TimeSpan)ds.Tables["CaixaTransacao"].Rows[0]["hora"];
                    caixaTransacao.Tipo = ds.Tables["CaixaTransacao"].Rows[0]["tipo"].ToString();
                    caixaTransacao.Valor = (decimal)ds.Tables["CaixaTransacao"].Rows[0]["valor"];

                    if (!string.IsNullOrEmpty(ds.Tables["CaixaTransacao"].Rows[0]["idDespesa"].ToString()))
                        caixaTransacao.Despesa = Library.DespesaBD.FindDespesaById((long)ds.Tables["CaixaTransacao"].Rows[0]["idDespesa"]);
                    else
                        caixaTransacao.Despesa = null;

                    if (!string.IsNullOrEmpty(ds.Tables["CaixaTransacao"].Rows[0]["idVenda"].ToString()))
                        caixaTransacao.Venda = Library.VendaBD.FindVendaById((long)ds.Tables["CaixaTransacao"].Rows[0]["idVenda"]);
                    else
                        caixaTransacao.Venda = null;

                    if (!string.IsNullOrEmpty(ds.Tables["CaixaTransacao"].Rows[0]["idVendaParcela"].ToString()))
                        caixaTransacao.VendaParcela = Library.VendaParcelaBD.FindVendaParcelaById((long)ds.Tables["CaixaTransacao"].Rows[0]["idVendaParcela"]);
                    else
                        caixaTransacao.VendaParcela = null;

                    if (!string.IsNullOrEmpty(ds.Tables["CaixaTransacao"].Rows[0]["idComissao"].ToString()))
                        caixaTransacao.Comissao = Library.ComissaoBD.FindComissaoById((long)ds.Tables["CaixaTransacao"].Rows[0]["idComissao"]);
                    else
                        caixaTransacao.Comissao = null;

                    if (!string.IsNullOrEmpty(ds.Tables["CaixaTransacao"].Rows[0]["idCheque"].ToString()))
                        caixaTransacao.Cheque = Library.ChequeBD.FindChequeById((long)ds.Tables["CaixaTransacao"].Rows[0]["idCheque"]);
                    else
                        caixaTransacao.Cheque = null;

                    if (!string.IsNullOrEmpty(ds.Tables["CaixaTransacao"].Rows[0]["idCartao"].ToString()))
                        caixaTransacao.Cartao = Library.CartaoBD.FindCartaoById((long)ds.Tables["CaixaTransacao"].Rows[0]["idCartao"]);
                    else
                        caixaTransacao.Cartao = null;
                }
                return caixaTransacao;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
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

                comando.CommandText = "SELECT IDENT_CURRENT('CaixaTransacao') AS lastId";

                conexao.Open();
                long lastId = 0;
                long.TryParse(comando.ExecuteScalar().ToString(), out lastId);


                return lastId + 1;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }
    }
}
