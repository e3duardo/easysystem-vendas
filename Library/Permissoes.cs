using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Permissoes
    {
        public Permissoes()
        {
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCadastro { get; set; }

        #region tabInicial
        public int inicialPessoaFisica { get; set; }
        public int inicialPessoaJuridica { get; set; }
        public int inicialFornecedor { get; set; }
        public int inicialProduto { get; set; }
        public int inicialCondicional { get; set; }
        public int inicialVenda { get; set; }
        #endregion

        #region tabCadastros
        public int cadastrosPessoaFisica { get; set; }
        public int cadastrosPessoaJuridica { get; set; }
        public int cadastrosFuncionario { get; set; }
        public int cadastrosCargo { get; set; }
        public int cadastrosPermissoes { get; set; }
        public int cadastrosMudarSenha { get; set; }
        public int cadastrosComissoes { get; set; }
        public int cadastrosProduto { get; set; }
        public int cadastrosFornecedor { get; set; }
        public int cadastrosSetor { get; set; }
        public int cadastrosEstoque { get; set; }
        #endregion

        #region tabFinanceiro
        public int financeiroCaixa { get; set; }
        public int financeiroTrocaDevolucao { get; set; }
        public int financeiroDespesa { get; set; }
        public int financeiroReceberParcelas { get; set; }
        public int financeiroCheques { get; set; }
        public int financeiroCartoes { get; set; }
        #endregion

        #region tabVenda
        public int vendaVenda { get; set; }
        public int vendaCondicional { get; set; }
        public int vendaVendasListar { get; set; }
        public int vendaCondicionaisListar { get; set; }
        #endregion

        #region tabRelatorios
        #endregion

        #region tabManutencao
        public int manutencaoBackup { get; set; }
        #endregion
    }

    public class PermissoesBD
    {
        private PermissoesBD()
        {
        }

        static public void Save(Library.Permissoes permissoes)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Seguranca (nome, descricao, dataCadastro, " +

                "inicialPessoaFisica, inicialPessoaJuridica, inicialFornecedor, inicialProduto, inicialCondicional, inicialVenda, " +
                "cadastrosPessoaFisica, cadastrosPessoaJuridica, cadastrosFuncionario, cadastrosCargo, cadastrosPermissoes, cadastrosMudarSenha, cadastrosComissoes, cadastrosProduto, cadastrosFornecedor, cadastrosSetor, cadastrosEstoque, " +
                "financeiroCaixa, financeiroTrocaDevolucao, financeiroDespesa, financeiroReceberParcelas, financeiroCheques, financeiroCartoes, " +
                "vendaVenda, vendaCondicional, vendaVendasListar, vendaCondicionaisListar, " +
                "manutencaoBackup" +

                ") VALUES (@nome, @descricao, @dataCadastro, " +

                "@inicialPessoaFisica, @inicialPessoaJuridica, @inicialFornecedor, @inicialProduto, @inicialCondicional, @inicialVenda, " +
                "@cadastrosPessoaFisica, @cadastrosPessoaJuridica, @cadastrosFuncionario, @cadastrosCargo, @cadastrosPermissoes, @cadastrosMudarSenha, @cadastrosComissoes, @cadastrosProduto, @cadastrosFornecedor, @cadastrosSetor, @cadastrosEstoque, " +
                "@financeiroCaixa, @financeiroTrocaDevolucao, @financeiroDespesa, @financeiroReceberParcelas, @financeiroCheques, @financeiroCartoes, " +
                "@vendaVenda, @vendaCondicional, @vendaVendasListar, @vendaCondicionaisListar, " +
                "@manutencaoBackup)"

                + "SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@nome", permissoes.Nome);
                comando.Parameters.AddWithValue("@descricao", permissoes.Descricao);
                comando.Parameters.AddWithValue("@dataCadastro", permissoes.DataCadastro);

                #region parametros
                comando.Parameters.AddWithValue("@inicialPessoaFisica", permissoes.inicialPessoaFisica);
                comando.Parameters.AddWithValue("@inicialPessoaJuridica", permissoes.inicialPessoaJuridica);
                comando.Parameters.AddWithValue("@inicialFornecedor", permissoes.inicialFornecedor);
                comando.Parameters.AddWithValue("@inicialProduto", permissoes.inicialProduto);
                comando.Parameters.AddWithValue("@inicialCondicional", permissoes.inicialCondicional);
                comando.Parameters.AddWithValue("@inicialVenda", permissoes.inicialVenda);

                comando.Parameters.AddWithValue("@cadastrosPessoaFisica", permissoes.cadastrosPessoaFisica);
                comando.Parameters.AddWithValue("@cadastrosPessoaJuridica", permissoes.cadastrosPessoaJuridica);
                comando.Parameters.AddWithValue("@cadastrosFuncionario", permissoes.cadastrosFuncionario);
                comando.Parameters.AddWithValue("@cadastrosCargo", permissoes.cadastrosCargo);
                comando.Parameters.AddWithValue("@cadastrosPermissoes", permissoes.cadastrosPermissoes);
                comando.Parameters.AddWithValue("@cadastrosMudarSenha", permissoes.cadastrosMudarSenha);
                comando.Parameters.AddWithValue("@cadastrosComissoes", permissoes.cadastrosComissoes);
                comando.Parameters.AddWithValue("@cadastrosProduto", permissoes.cadastrosProduto);
                comando.Parameters.AddWithValue("@cadastrosFornecedor", permissoes.cadastrosFornecedor);
                comando.Parameters.AddWithValue("@cadastrosSetor", permissoes.cadastrosSetor);
                comando.Parameters.AddWithValue("@cadastrosEstoque", permissoes.cadastrosEstoque);
                
                comando.Parameters.AddWithValue("@financeiroCaixa", permissoes.financeiroCaixa);
                comando.Parameters.AddWithValue("@financeiroTrocaDevolucao", permissoes.financeiroTrocaDevolucao);
                comando.Parameters.AddWithValue("@financeiroDespesa", permissoes.financeiroDespesa);
                comando.Parameters.AddWithValue("@financeiroReceberParcelas", permissoes.financeiroReceberParcelas);
                comando.Parameters.AddWithValue("@financeiroCheques", permissoes.financeiroCheques);
                comando.Parameters.AddWithValue("@financeiroCartoes", permissoes.financeiroCartoes);

                comando.Parameters.AddWithValue("@vendaVenda", permissoes.vendaVenda);
                comando.Parameters.AddWithValue("@vendaCondicional", permissoes.vendaCondicional);
                comando.Parameters.AddWithValue("@vendaVendasListar", permissoes.vendaVendasListar);
                comando.Parameters.AddWithValue("@vendaCondicionaisListar", permissoes.vendaCondicionaisListar);

                comando.Parameters.AddWithValue("@manutencaoBackup", permissoes.manutencaoBackup);
                #endregion

                conexao.Open();

                //comando.ExecuteNonQuery();
                permissoes.Id = (long)comando.ExecuteScalar();

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

        static public void Update(Library.Permissoes permissoes)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Seguranca SET nome = @nome, descricao = @descricao, dataCadastro = @dataCadastro, " +

                "inicialPessoaFisica = @inicialPessoaFisica, inicialPessoaJuridica = @inicialPessoaJuridica, inicialFornecedor = @inicialFornecedor, inicialProduto = @inicialProduto, inicialCondicional = @inicialCondicional, inicialVenda = @inicialVenda, " +
                "cadastrosPessoaFisica = @cadastrosPessoaFisica, cadastrosPessoaJuridica = @cadastrosPessoaJuridica, cadastrosFuncionario = @cadastrosFuncionario, cadastrosCargo = @cadastrosCargo, cadastrosPermissoes = @cadastrosPermissoes, cadastrosMudarSenha = @cadastrosMudarSenha, cadastrosComissoes = @cadastrosComissoes, cadastrosProduto = @cadastrosProduto, cadastrosFornecedor = @cadastrosFornecedor, cadastrosSetor = @cadastrosSetor, cadastrosEstoque = @cadastrosEstoque, " +
                "financeiroCaixa = @financeiroCaixa, financeiroTrocaDevolucao = @financeiroTrocaDevolucao, financeiroDespesa = @financeiroDespesa, financeiroReceberParcelas = @financeiroReceberParcelas, financeiroCheques = @financeiroCheques, financeiroCartoes = @financeiroCartoes, " +
                "vendaVenda = @vendaVenda, vendaCondicional = @vendaCondicional, vendaVendasListar = @vendaVendasListar, vendaCondicionaisListar = @vendaCondicionaisListar, " +
                "manutencaoBackup = @manutencaoBackup" +

                " WHERE (id= " + permissoes.Id + ")";


                comando.Parameters.AddWithValue("@nome", permissoes.Nome);
                comando.Parameters.AddWithValue("@descricao", permissoes.Descricao);
                comando.Parameters.AddWithValue("@dataCadastro", permissoes.DataCadastro);

                #region parametros
                comando.Parameters.AddWithValue("@inicialPessoaFisica", permissoes.inicialPessoaFisica);
                comando.Parameters.AddWithValue("@inicialPessoaJuridica", permissoes.inicialPessoaJuridica);
                comando.Parameters.AddWithValue("@inicialFornecedor", permissoes.inicialFornecedor);
                comando.Parameters.AddWithValue("@inicialProduto", permissoes.inicialProduto);
                comando.Parameters.AddWithValue("@inicialCondicional", permissoes.inicialCondicional);
                comando.Parameters.AddWithValue("@inicialVenda", permissoes.inicialVenda);

                comando.Parameters.AddWithValue("@cadastrosPessoaFisica", permissoes.cadastrosPessoaFisica);
                comando.Parameters.AddWithValue("@cadastrosPessoaJuridica", permissoes.cadastrosPessoaJuridica);
                comando.Parameters.AddWithValue("@cadastrosFuncionario", permissoes.cadastrosFuncionario);
                comando.Parameters.AddWithValue("@cadastrosCargo", permissoes.cadastrosCargo);
                comando.Parameters.AddWithValue("@cadastrosPermissoes", permissoes.cadastrosPermissoes);
                comando.Parameters.AddWithValue("@cadastrosMudarSenha", permissoes.cadastrosMudarSenha);
                comando.Parameters.AddWithValue("@cadastrosComissoes", permissoes.cadastrosComissoes);
                comando.Parameters.AddWithValue("@cadastrosProduto", permissoes.cadastrosProduto);
                comando.Parameters.AddWithValue("@cadastrosFornecedor", permissoes.cadastrosFornecedor);
                comando.Parameters.AddWithValue("@cadastrosSetor", permissoes.cadastrosSetor);
                comando.Parameters.AddWithValue("@cadastrosEstoque", permissoes.cadastrosEstoque);

                comando.Parameters.AddWithValue("@financeiroCaixa", permissoes.financeiroCaixa);
                comando.Parameters.AddWithValue("@financeiroTrocaDevolucao", permissoes.financeiroTrocaDevolucao);
                comando.Parameters.AddWithValue("@financeiroDespesa", permissoes.financeiroDespesa);
                comando.Parameters.AddWithValue("@financeiroReceberParcelas", permissoes.financeiroReceberParcelas);
                comando.Parameters.AddWithValue("@financeiroCheques", permissoes.financeiroCheques);
                comando.Parameters.AddWithValue("@financeiroCartoes", permissoes.financeiroCartoes);

                comando.Parameters.AddWithValue("@vendaVenda", permissoes.vendaVenda);
                comando.Parameters.AddWithValue("@vendaCondicional", permissoes.vendaCondicional);
                comando.Parameters.AddWithValue("@vendaVendasListar", permissoes.vendaVendasListar);
                comando.Parameters.AddWithValue("@vendaCondicionaisListar", permissoes.vendaCondicionaisListar);

                comando.Parameters.AddWithValue("@manutencaoBackup", permissoes.manutencaoBackup);
                #endregion

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

        static public void Delete(Library.Permissoes permissoes)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Seguranca WHERE id='" + permissoes.Id + "'";

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

        static public List<Library.Permissoes> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Seguranca AS s ";

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
                        case "s.id":
                            query += pre + "s.id = @id";
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

                List<Library.Permissoes> permissoes = new List<Library.Permissoes>();

                while (rdr.Read())
                {
                    Library.Permissoes permissao = new Permissoes();
                    permissao.Id = (long)rdr["id"];
                    permissao.Nome = rdr["nome"].ToString();
                    permissao.Descricao = rdr["descricao"].ToString();
                    permissao.DataCadastro = (DateTime)rdr["dataCadastro"];

                    #region parametros
                    permissao.inicialPessoaFisica = (int)rdr["inicialPessoaFisica"];
                    permissao.inicialPessoaJuridica = (int)rdr["inicialPessoaJuridica"];
                    permissao.inicialFornecedor = (int)rdr["inicialFornecedor"];
                    permissao.inicialProduto = (int)rdr["inicialProduto"];
                    permissao.inicialCondicional = (int)rdr["inicialCondicional"];
                    permissao.inicialVenda = (int)rdr["inicialVenda"];

                    permissao.cadastrosPessoaFisica = (int)rdr["cadastrosPessoaFisica"];
                    permissao.cadastrosPessoaJuridica = (int)rdr["cadastrosPessoaJuridica"];
                    permissao.cadastrosFuncionario = (int)rdr["cadastrosFuncionario"];
                    permissao.cadastrosCargo = (int)rdr["cadastrosCargo"];
                    permissao.cadastrosPermissoes = (int)rdr["cadastrosPermissoes"];
                    permissao.cadastrosMudarSenha = (int)rdr["cadastrosMudarSenha"];
                    permissao.cadastrosComissoes = (int)rdr["cadastrosComissoes"];
                    permissao.cadastrosProduto = (int)rdr["cadastrosProduto"];
                    permissao.cadastrosFornecedor = (int)rdr["cadastrosFornecedor"];
                    permissao.cadastrosSetor = (int)rdr["cadastrosSetor"];
                    permissao.cadastrosEstoque = (int)rdr["cadastrosEstoque"];
                    
                    permissao.financeiroCaixa = (int)rdr["financeiroCaixa"];
                    permissao.financeiroTrocaDevolucao = (int)rdr["financeiroTrocaDevolucao"];
                    permissao.financeiroDespesa = (int)rdr["financeiroDespesa"];
                    permissao.financeiroReceberParcelas = (int)rdr["financeiroReceberParcelas"];
                    permissao.financeiroCheques = (int)rdr["financeiroCheques"];
                    permissao.financeiroCartoes = (int)rdr["financeiroCartoes"];

                    permissao.vendaVenda = (int)rdr["vendaVenda"];
                    permissao.vendaCondicional = (int)rdr["vendaCondicional"];
                    permissao.vendaVendasListar = (int)rdr["vendaVendasListar"];
                    permissao.vendaCondicionaisListar = (int)rdr["vendaCondicionaisListar"];

                    permissao.manutencaoBackup = (int)rdr["manutencaoBackup"];
                    #endregion

                    permissoes.Add(permissao);
                }

                return permissoes;
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

        static public Library.Permissoes FindById(long idSeguranca)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Permissoes permissao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Seguranca WHERE id='" + idSeguranca + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Seguranca");

                if (ds.Tables["Seguranca"].Rows.Count == 1)
                {
                    permissao = new Permissoes();
                    permissao.Id = (long)ds.Tables["Seguranca"].Rows[0]["id"];
                    permissao.Nome = ds.Tables["Seguranca"].Rows[0]["nome"].ToString();
                    permissao.Descricao = ds.Tables["Seguranca"].Rows[0]["descricao"].ToString();
                    permissao.DataCadastro = (DateTime)ds.Tables["Seguranca"].Rows[0]["dataCadastro"];

                    #region parametros
                    permissao.inicialPessoaFisica = (int)ds.Tables["Seguranca"].Rows[0]["inicialPessoaFisica"];
                    permissao.inicialPessoaJuridica = (int)ds.Tables["Seguranca"].Rows[0]["inicialPessoaJuridica"];
                    permissao.inicialFornecedor = (int)ds.Tables["Seguranca"].Rows[0]["inicialFornecedor"];
                    permissao.inicialProduto = (int)ds.Tables["Seguranca"].Rows[0]["inicialProduto"];
                    permissao.inicialCondicional = (int)ds.Tables["Seguranca"].Rows[0]["inicialCondicional"];
                    permissao.inicialVenda = (int)ds.Tables["Seguranca"].Rows[0]["inicialVenda"];

                    permissao.cadastrosPessoaFisica = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosPessoaFisica"];
                    permissao.cadastrosPessoaJuridica = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosPessoaJuridica"];
                    permissao.cadastrosFuncionario = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosFuncionario"];
                    permissao.cadastrosCargo = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosCargo"];
                    permissao.cadastrosPermissoes = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosPermissoes"];
                    permissao.cadastrosMudarSenha = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosMudarSenha"];
                    permissao.cadastrosComissoes = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosComissoes"];
                    permissao.cadastrosProduto = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosProduto"];
                    permissao.cadastrosFornecedor = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosFornecedor"];
                    permissao.cadastrosSetor = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosSetor"];
                    permissao.cadastrosEstoque = (int)ds.Tables["Seguranca"].Rows[0]["cadastrosEstoque"];

                    permissao.financeiroCaixa = (int)ds.Tables["Seguranca"].Rows[0]["financeiroCaixa"];
                    permissao.financeiroTrocaDevolucao = (int)ds.Tables["Seguranca"].Rows[0]["financeiroTrocaDevolucao"];
                    permissao.financeiroDespesa = (int)ds.Tables["Seguranca"].Rows[0]["financeiroDespesa"];
                    permissao.financeiroReceberParcelas = (int)ds.Tables["Seguranca"].Rows[0]["financeiroReceberParcelas"];
                    permissao.financeiroCheques = (int)ds.Tables["Seguranca"].Rows[0]["financeiroCheques"];
                    permissao.financeiroCartoes = (int)ds.Tables["Seguranca"].Rows[0]["financeiroCartoes"];

                    permissao.vendaVenda = (int)ds.Tables["Seguranca"].Rows[0]["vendaVenda"];
                    permissao.vendaCondicional = (int)ds.Tables["Seguranca"].Rows[0]["vendaCondicional"];
                    permissao.vendaVendasListar = (int)ds.Tables["Seguranca"].Rows[0]["vendaVendasListar"];
                    permissao.vendaCondicionaisListar = (int)ds.Tables["Seguranca"].Rows[0]["vendaCondicionaisListar"];

                    permissao.manutencaoBackup = (int)ds.Tables["Seguranca"].Rows[0]["manutencaoBackup"];
                    #endregion
                }
                return permissao;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Seguranca') AS lastId";

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
