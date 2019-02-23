using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Library.Classes;
using Library.Converter;

namespace Library
{
    public class Cliente
    {
        public Cliente()
        {
        }


        public long Id { get; set; }
        public string Bairro { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Fax { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Nome { get; set; }
        public string NomeContato { get; set; }
        public string NomeFantasia { get; set; }
        public string Observacoes { get; set; }
        public string Pessoa { get; set; }
        public string Rg { get; set; }
        public string ReferenciaComercial { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataCadastro { get; set; }

        public int AptoVendaAPrazo { get; set; }
        public decimal LimiteVendaAPrazo { get; set; }
        public int VencimentoVendaAPrazo { get; set; }

        public string Filiacao { get; set; }


        
    }
    public class ClienteBD
    {
        private ClienteBD()
        {
        }

        static public void Save(Library.Cliente cliente)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                using (SqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "INSERT INTO Cliente (bairro, celular, cep, cpf, cnpj, cidade, email, endereco, estado, fax, inscricaoEstadual, nascimento, nome, nomeContato, nomeFantasia, observacoes, pessoa, rg, referenciaComercial, site, telefone, dataCadastro, limiteVendaAPrazo, aptoVendaAPrazo, vencimentoVendaAPrazo, filiacao) VALUES (@bairro, @celular, @cep, @cpf, @cnpj, @cidade, @email, @endereco, @estado, @fax, @inscricaoEstadual, @nascimento, @nome, @nomeContato, @nomeFantasia, @observacoes, @pessoa, @rg, @referenciaComercial, @site, @telefone, @dataCadastro, @limiteVendaAPrazo, @aptoVendaAPrazo, @vencimentoVendaAPrazo, @filiacao)"
                    + "SELECT CAST(scope_identity() AS bigint)";

                    if (cliente.Bairro != null && cliente.Bairro != "")
                        comando.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    else
                        comando.Parameters.AddWithValue("@bairro", DBNull.Value);

                    if (cliente.Celular != null && cliente.Celular != "")
                        comando.Parameters.AddWithValue("@celular", cliente.Celular);
                    else
                        comando.Parameters.AddWithValue("@celular", DBNull.Value);

                    if (cliente.Cep != null && cliente.Cep != "")
                        comando.Parameters.AddWithValue("@cep", cliente.Cep);
                    else
                        comando.Parameters.AddWithValue("@cep", DBNull.Value);

                    if (cliente.Cpf != null && cliente.Cpf != "")
                        comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    else
                        comando.Parameters.AddWithValue("@cpf", DBNull.Value);

                    if (cliente.Cnpj != null && cliente.Cnpj != "")
                        comando.Parameters.AddWithValue("@cnpj", cliente.Cnpj);
                    else
                        comando.Parameters.AddWithValue("@cnpj", DBNull.Value);

                    if (cliente.Cidade != null && cliente.Cidade != "")
                        comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    else
                        comando.Parameters.AddWithValue("@cidade", DBNull.Value);

                    if (cliente.Email != null && cliente.Email != "")
                        comando.Parameters.AddWithValue("@email", cliente.Email);
                    else
                        comando.Parameters.AddWithValue("@email", DBNull.Value);

                    if (cliente.Endereco != null && cliente.Endereco != "")
                        comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    else
                        comando.Parameters.AddWithValue("@endereco", DBNull.Value);

                    if (cliente.Estado != null && cliente.Estado != "")
                        comando.Parameters.AddWithValue("@estado", cliente.Estado);
                    else
                        comando.Parameters.AddWithValue("@estado", DBNull.Value);

                    if (cliente.Fax != null && cliente.Fax != "")
                        comando.Parameters.AddWithValue("@fax", cliente.Fax);
                    else
                        comando.Parameters.AddWithValue("@fax", DBNull.Value);

                    if (cliente.InscricaoEstadual != null && cliente.InscricaoEstadual != "")
                        comando.Parameters.AddWithValue("@inscricaoEstadual", cliente.InscricaoEstadual);
                    else
                        comando.Parameters.AddWithValue("@inscricaoEstadual", DBNull.Value);

                    if (cliente.Nascimento != null & cliente.Nascimento > SqlDateTime.MinValue.Value & cliente.Nascimento < SqlDateTime.MaxValue.Value)
                        comando.Parameters.AddWithValue("@nascimento", cliente.Nascimento);
                    else
                        comando.Parameters.AddWithValue("@nascimento", SqlDateTime.Null);

                    if (cliente.Nome != null && cliente.Nome != "")
                        comando.Parameters.AddWithValue("@nome", cliente.Nome);
                    else
                        comando.Parameters.AddWithValue("@nome", DBNull.Value);

                    if (cliente.NomeContato != null && cliente.NomeContato != "")
                        comando.Parameters.AddWithValue("@nomeContato", cliente.NomeContato);
                    else
                        comando.Parameters.AddWithValue("@nomeContato", DBNull.Value);

                    if (cliente.NomeFantasia != null && cliente.NomeFantasia != "")
                        comando.Parameters.AddWithValue("@nomeFantasia", cliente.NomeFantasia);
                    else
                        comando.Parameters.AddWithValue("@nomeFantasia", DBNull.Value);

                    if (cliente.Observacoes != null && cliente.Observacoes != "")
                        comando.Parameters.AddWithValue("@observacoes", cliente.Observacoes);
                    else
                        comando.Parameters.AddWithValue("@observacoes", DBNull.Value);

                    if (cliente.Pessoa != null && cliente.Pessoa != "")
                        comando.Parameters.AddWithValue("@pessoa", cliente.Pessoa);
                    else
                        comando.Parameters.AddWithValue("@pessoa", DBNull.Value);

                    if (cliente.Rg != null && cliente.Rg != "")
                        comando.Parameters.AddWithValue("@rg", cliente.Rg);
                    else
                        comando.Parameters.AddWithValue("@rg", DBNull.Value);

                    if (cliente.ReferenciaComercial != null && cliente.ReferenciaComercial != "")
                        comando.Parameters.AddWithValue("@referenciaComercial", cliente.ReferenciaComercial);
                    else
                        comando.Parameters.AddWithValue("@referenciaComercial", DBNull.Value);

                    if (cliente.Site != null && cliente.Site != "")
                        comando.Parameters.AddWithValue("@site", cliente.Site);
                    else
                        comando.Parameters.AddWithValue("@site", DBNull.Value);

                    if (cliente.Telefone != null && cliente.Telefone != "")
                        comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    else
                        comando.Parameters.AddWithValue("@telefone", DBNull.Value);

                    if (cliente.DataCadastro != null)
                        comando.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);
                    else
                        comando.Parameters.AddWithValue("@dataCadastro", "00/00/0000 00:00");


                    comando.Parameters.AddWithValue("@limiteVendaAPrazo", cliente.LimiteVendaAPrazo);
                    comando.Parameters.AddWithValue("@aptoVendaAPrazo", cliente.AptoVendaAPrazo);
                    comando.Parameters.AddWithValue("@vencimentoVendaAPrazo", cliente.VencimentoVendaAPrazo);

                    comando.Parameters.AddWithValue("@filiacao", cliente.Filiacao);


                    conexao.Open();

                    //comando.ExecuteNonQuery();
                    cliente.Id = (long)comando.ExecuteScalar();
                }
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
        }

        static public void Update(Library.Cliente cliente)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                using (SqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "UPDATE Cliente SET bairro = @bairro, celular = @celular, cep = @cep, cpf = @cpf, cnpj = @cnpj, cidade = @cidade, email = @email, endereco = @endereco, estado = @estado, fax = @fax, inscricaoEstadual = @inscricaoEstadual, nascimento = @nascimento, nome = @nome, nomeContato = @nomeContato, nomeFantasia = @nomeFantasia, observacoes = @observacoes, pessoa = @pessoa, rg = @rg, referenciaComercial = @referenciaComercial, site = @site, telefone = @telefone, dataCadastro = @dataCadastro, limiteVendaAPrazo = @limiteVendaAPrazo, aptoVendaAPrazo = @aptoVendaAPrazo, vencimentoVendaAPrazo = @vencimentoVendaAPrazo, filiacao = @filiacao WHERE (id= " + cliente.Id + ")";

                    if (cliente.Bairro != null && cliente.Bairro != "")
                        comando.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    else
                        comando.Parameters.AddWithValue("@bairro", DBNull.Value);

                    if (cliente.Celular != null && cliente.Celular != "")
                        comando.Parameters.AddWithValue("@celular", cliente.Celular);
                    else
                        comando.Parameters.AddWithValue("@celular", DBNull.Value);

                    if (cliente.Cep != null && cliente.Cep != "")
                        comando.Parameters.AddWithValue("@cep", cliente.Cep);
                    else
                        comando.Parameters.AddWithValue("@cep", DBNull.Value);

                    if (cliente.Cpf != null && cliente.Cpf != "")
                        comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    else
                        comando.Parameters.AddWithValue("@cpf", DBNull.Value);

                    if (cliente.Cnpj != null && cliente.Cnpj != "")
                        comando.Parameters.AddWithValue("@cnpj", cliente.Cnpj);
                    else
                        comando.Parameters.AddWithValue("@cnpj", DBNull.Value);

                    if (cliente.Cidade != null && cliente.Cidade != "")
                        comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    else
                        comando.Parameters.AddWithValue("@cidade", DBNull.Value);

                    if (cliente.Email != null && cliente.Email != "")
                        comando.Parameters.AddWithValue("@email", cliente.Email);
                    else
                        comando.Parameters.AddWithValue("@email", DBNull.Value);

                    if (cliente.Endereco != null && cliente.Endereco != "")
                        comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    else
                        comando.Parameters.AddWithValue("@endereco", DBNull.Value);

                    if (cliente.Estado != null && cliente.Estado != "")
                        comando.Parameters.AddWithValue("@estado", cliente.Estado);
                    else
                        comando.Parameters.AddWithValue("@estado", DBNull.Value);

                    if (cliente.Fax != null && cliente.Fax != "")
                        comando.Parameters.AddWithValue("@fax", cliente.Fax);
                    else
                        comando.Parameters.AddWithValue("@fax", DBNull.Value);

                    if (cliente.InscricaoEstadual != null && cliente.InscricaoEstadual != "")
                        comando.Parameters.AddWithValue("@inscricaoEstadual", cliente.InscricaoEstadual);
                    else
                        comando.Parameters.AddWithValue("@inscricaoEstadual", DBNull.Value);

                    if (cliente.Nascimento != null)
                        comando.Parameters.AddWithValue("@nascimento", cliente.Nascimento);
                    else
                        comando.Parameters.AddWithValue("@nascimento", SqlDateTime.Null);

                    if (cliente.Nome != null && cliente.Nome != "")
                        comando.Parameters.AddWithValue("@nome", cliente.Nome);
                    else
                        comando.Parameters.AddWithValue("@nome", DBNull.Value);

                    if (cliente.NomeContato != null && cliente.NomeContato != "")
                        comando.Parameters.AddWithValue("@nomeContato", cliente.NomeContato);
                    else
                        comando.Parameters.AddWithValue("@nomeContato", DBNull.Value);

                    if (cliente.NomeFantasia != null && cliente.NomeFantasia != "")
                        comando.Parameters.AddWithValue("@nomeFantasia", cliente.NomeFantasia);
                    else
                        comando.Parameters.AddWithValue("@nomeFantasia", DBNull.Value);

                    if (cliente.Observacoes != null && cliente.Observacoes != "")
                        comando.Parameters.AddWithValue("@observacoes", cliente.Observacoes);
                    else
                        comando.Parameters.AddWithValue("@observacoes", DBNull.Value);

                    if (cliente.Pessoa != null && cliente.Pessoa != "")
                        comando.Parameters.AddWithValue("@pessoa", cliente.Pessoa);
                    else
                        comando.Parameters.AddWithValue("@pessoa", DBNull.Value);

                    if (cliente.Rg != null && cliente.Rg != "")
                        comando.Parameters.AddWithValue("@rg", cliente.Rg);
                    else
                        comando.Parameters.AddWithValue("@rg", DBNull.Value);

                    if (cliente.ReferenciaComercial != null && cliente.ReferenciaComercial != "")
                        comando.Parameters.AddWithValue("@referenciaComercial", cliente.ReferenciaComercial);
                    else
                        comando.Parameters.AddWithValue("@referenciaComercial", DBNull.Value);

                    if (cliente.Site != null && cliente.Site != "")
                        comando.Parameters.AddWithValue("@site", cliente.Site);
                    else
                        comando.Parameters.AddWithValue("@site", DBNull.Value);

                    if (cliente.Telefone != null && cliente.Telefone != "")
                        comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    else
                        comando.Parameters.AddWithValue("@telefone", DBNull.Value);

                    if (cliente.DataCadastro != null)
                        comando.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);
                    else
                        comando.Parameters.AddWithValue("@dataCadastro", "00/00/0000 00:00");

                    comando.Parameters.AddWithValue("@limiteVendaAPrazo", cliente.LimiteVendaAPrazo);
                    comando.Parameters.AddWithValue("@aptoVendaAPrazo", cliente.AptoVendaAPrazo);
                    comando.Parameters.AddWithValue("@vencimentoVendaAPrazo", cliente.VencimentoVendaAPrazo);

                    comando.Parameters.AddWithValue("@filiacao", cliente.Filiacao);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
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
        }

        static public bool DeleteById(long idCliente)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Cliente WHERE id='" + idCliente + "'";

                conexao.Open();
                int teste = comando.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.Cliente> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                using (SqlCommand comando = new SqlCommand())
                {
                    string query = "SELECT * FROM Cliente AS c ";

                    int p = 0;
                    string pre = "";
                    foreach (Library.Classes.QItem qi in args)
                    {
                        if (p == 0)
                            pre = " WHERE ";
                        else
                            pre = " AND ";

                        p++;

                        switch (qi.Campo)
                        {
                            case "c.id":
                                query += pre + "(c.id = @id)";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "c.nome LIKE %%":
                                query += pre + "(c.nome LIKE '%' + @nome + '%')";
                                comando.Parameters.AddWithValue("@nome", qi.Objeto);
                                break;
                            case "c.pessoa":
                                query += pre + "(c.pessoa = @pessoa)";
                                comando.Parameters.AddWithValue("@pessoa", qi.Objeto);
                                break;
                            case "c.cpf":
                                query += pre + "(c.cpf LIKE @cpf)";
                                comando.Parameters.AddWithValue("@cpf", qi.Objeto);
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
                List<Library.Cliente> clientes = new List<Library.Cliente>();

                while (rdr.Read())
                {
                    Library.Cliente cliente = new Cliente();
                    cliente.Id = (long)rdr["id"];
                    cliente.Bairro = rdr["bairro"].ToString();
                    cliente.Celular = rdr["celular"].ToString();
                    cliente.Cep = rdr["cep"].ToString();
                    cliente.Cpf = rdr["cpf"].ToString();
                    cliente.Cnpj = rdr["cnpj"].ToString();
                    cliente.Cidade = rdr["cidade"].ToString();
                    cliente.Email = rdr["email"].ToString();
                    cliente.Endereco = rdr["endereco"].ToString();
                    cliente.Estado = rdr["estado"].ToString();
                    cliente.Fax = rdr["fax"].ToString();
                    cliente.InscricaoEstadual = rdr["inscricaoEstadual"].ToString();
                    DateTime data = DateTime.MinValue;
                    DateTime.TryParse(rdr["nascimento"].ToString(), out data);
                    cliente.Nascimento = data;
                    cliente.Nome = rdr["nome"].ToString();
                    cliente.NomeContato = rdr["nomeContato"].ToString();
                    cliente.NomeFantasia = rdr["nomeFantasia"].ToString();
                    cliente.Observacoes = rdr["observacoes"].ToString();
                    cliente.Pessoa = rdr["pessoa"].ToString();
                    cliente.Rg = rdr["Rg"].ToString();
                    cliente.ReferenciaComercial = rdr["referenciaComercial"].ToString();
                    cliente.Site = rdr["site"].ToString();
                    cliente.Telefone = rdr["telefone"].ToString();
                    cliente.DataCadastro = (DateTime)rdr["dataCadastro"];
                    cliente.LimiteVendaAPrazo = (decimal)rdr["limiteVendaAPrazo"];
                    cliente.AptoVendaAPrazo = (int)rdr["aptoVendaAPrazo"];
                    cliente.VencimentoVendaAPrazo = (int)rdr["vencimentoVendaAPrazo"];
                    cliente.Filiacao = rdr["filiacao"].ToString();

                    clientes.Add(cliente);
                }

                return clientes;
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

        static public Library.Cliente FindById(long idCliente)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Cliente cliente = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Cliente WHERE id='" + idCliente + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Cliente");

                if (ds.Tables["Cliente"].Rows.Count == 1)
                {
                    cliente = new Cliente();
                    cliente.Id = (long)ds.Tables["Cliente"].Rows[0]["id"];
                    cliente.Bairro = ds.Tables["Cliente"].Rows[0]["bairro"].ToString();
                    cliente.Celular = ds.Tables["Cliente"].Rows[0]["celular"].ToString();
                    cliente.Cep = ds.Tables["Cliente"].Rows[0]["cep"].ToString();
                    cliente.Cpf = ds.Tables["Cliente"].Rows[0]["cpf"].ToString();
                    cliente.Cnpj = ds.Tables["Cliente"].Rows[0]["cnpj"].ToString();
                    cliente.Cidade = ds.Tables["Cliente"].Rows[0]["cidade"].ToString();
                    cliente.Email = ds.Tables["Cliente"].Rows[0]["email"].ToString();
                    cliente.Endereco = ds.Tables["Cliente"].Rows[0]["endereco"].ToString();
                    cliente.Estado = ds.Tables["Cliente"].Rows[0]["estado"].ToString();
                    cliente.Fax = ds.Tables["Cliente"].Rows[0]["fax"].ToString();
                    cliente.InscricaoEstadual = ds.Tables["Cliente"].Rows[0]["inscricaoEstadual"].ToString();
                    DateTime data = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["Cliente"].Rows[0]["nascimento"].ToString(), out data);
                    cliente.Nascimento = data;
                    cliente.Nome = ds.Tables["Cliente"].Rows[0]["nome"].ToString();
                    cliente.NomeContato = ds.Tables["Cliente"].Rows[0]["nomeContato"].ToString();
                    cliente.NomeFantasia = ds.Tables["Cliente"].Rows[0]["nomeFantasia"].ToString();
                    cliente.Observacoes = ds.Tables["Cliente"].Rows[0]["observacoes"].ToString();
                    cliente.Pessoa = ds.Tables["Cliente"].Rows[0]["pessoa"].ToString();
                    cliente.Rg = ds.Tables["Cliente"].Rows[0]["Rg"].ToString();
                    cliente.ReferenciaComercial = ds.Tables["Cliente"].Rows[0]["referenciaComercial"].ToString();
                    cliente.Site = ds.Tables["Cliente"].Rows[0]["site"].ToString();
                    cliente.Telefone = ds.Tables["Cliente"].Rows[0]["telefone"].ToString();
                    cliente.DataCadastro = (DateTime)ds.Tables["Cliente"].Rows[0]["dataCadastro"];
                    cliente.LimiteVendaAPrazo = (decimal)ds.Tables["Cliente"].Rows[0]["limiteVendaAPrazo"];
                    cliente.AptoVendaAPrazo = (int)ds.Tables["Cliente"].Rows[0]["aptoVendaAPrazo"];
                    cliente.VencimentoVendaAPrazo = (int)ds.Tables["Cliente"].Rows[0]["vencimentoVendaAPrazo"];
                    cliente.Filiacao = ds.Tables["Cliente"].Rows[0]["filiacao"].ToString();


                    return cliente;
                }
                else
                    return null;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Cliente') AS lastId";

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


        static public List<Library.VendaParcela> GetParcelasAtrasadasById(long idCliente)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT vp.id, vp.idVenda, vp.data, vp.pago, vp.valor " +
                                    "FROM Cliente as c " +
                                    "INNER JOIN Venda as v on c.id = v.idCliente " +
                                    "INNER JOIN VendaParcela as vp on vp.idVenda = v.id " +
                                    "WHERE (c.id = " + idCliente + ") and (vp.pago = 0) and (CONVERT(varchar,vp.data, 23) < CONVERT(varchar,GETDATE(),23 ))";

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.VendaParcela> vendaParcelas = new List<Library.VendaParcela>();

                while (rdr.Read())
                {
                    Library.VendaParcela vendaParcela = new VendaParcela();
                    vendaParcela.Id = (long)rdr["id"];
                    vendaParcela.Venda = Library.VendaBD.FindVendaById((long)rdr["idVenda"]);
                    vendaParcela.Data = (DateTime)rdr["data"];
                    vendaParcela.Pago = (int)rdr["pago"];
                    vendaParcela.Valor = (decimal)rdr["valor"];

                    vendaParcelas.Add(vendaParcela);
                }

                return vendaParcelas;
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

        static public decimal GetParcelasAtrasadasValorById(long idCliente)
        {
            try
            {
                List<Library.VendaParcela> vendaparcelas = Library.ClienteBD.GetParcelasAtrasadasById(idCliente);

                decimal valor = 0;
                foreach (Library.VendaParcela vp in vendaparcelas)
                {
                    valor += (decimal)vp.Valor;
                }

                return valor;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            return 0;
        }
    }
}
