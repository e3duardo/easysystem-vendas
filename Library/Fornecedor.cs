using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Fornecedor
    {
        public Fornecedor()
        {
        }


        public long Id { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Cnpj { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Fax { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Nome { get; set; }
        public string Observacoes { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
    public class FornecedorBD
    {
        private FornecedorBD()
        {
        }

        static public void Save(Library.Fornecedor fornecedor)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Fornecedor (bairro, cep, cidade, cnpj, contato, email, endereco, estado, fax, inscricaoEstadual, nome, site, telefone, dataCadastro) VALUES (@bairro, @cep, @cidade, @cnpj, @contato, @email, @endereco, @estado, @fax, @inscricaoEstadual, @nome, @site, @telefone, @dataCadastro)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@cep", fornecedor.Cep);
                comando.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@contato", fornecedor.Contato);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
                comando.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                comando.Parameters.AddWithValue("@estado", fornecedor.Estado);
                comando.Parameters.AddWithValue("@fax", fornecedor.Fax);
                comando.Parameters.AddWithValue("@inscricaoEstadual", fornecedor.InscricaoEstadual);
                comando.Parameters.AddWithValue("@nome", fornecedor.Nome);
                comando.Parameters.AddWithValue("@site", fornecedor.Site);
                comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                comando.Parameters.AddWithValue("@dataCadastro", fornecedor.DataCadastro);

                conexao.Open();

                //comando.ExecuteNonQuery();
                fornecedor.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Fornecedor fornecedor)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Fornecedor SET bairro = @bairro, cep = @cep, cidade = @cidade, cnpj = @cnpj, contato = @contato, email = @email, endereco = @endereco, estado = @estado, fax = @fax, inscricaoEstadual = @inscricaoEstadual, nome = @nome, telefone = @telefone, dataCadastro = @dataCadastro WHERE (id= " + fornecedor.Id + ")";
                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                comando.Parameters.AddWithValue("@cep", fornecedor.Cep);
                comando.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@contato", fornecedor.Contato);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
                comando.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                comando.Parameters.AddWithValue("@estado", fornecedor.Estado);
                comando.Parameters.AddWithValue("@fax", fornecedor.Fax);
                comando.Parameters.AddWithValue("@inscricaoEstadual", fornecedor.InscricaoEstadual);
                comando.Parameters.AddWithValue("@nome", fornecedor.Nome);
                comando.Parameters.AddWithValue("@site", fornecedor.Site);
                comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                comando.Parameters.AddWithValue("@dataCadastro", fornecedor.DataCadastro);

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

        static public void DeleteById(long idFornecedor)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Fornecedor WHERE id='" + idFornecedor + "'";

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

        static public List<Library.Fornecedor> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Fornecedor AS f ";

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
                        case "f.id":
                            query += pre + "(f.id = @id)";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "f.nome LIKE %%":
                            query += pre + "(f.nome LIKE '%' + @nome + '%')";
                            comando.Parameters.AddWithValue("@nome", qi.Objeto);
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

                List<Library.Fornecedor> fornecedores = new List<Library.Fornecedor>();

                while (rdr.Read())
                {
                    Library.Fornecedor fornecedor = new Fornecedor();
                    fornecedor.Id = (long)rdr["id"];
                    fornecedor.Bairro = rdr["bairro"].ToString();
                    fornecedor.Cep = rdr["cep"].ToString();
                    fornecedor.Cidade = rdr["cidade"].ToString();
                    fornecedor.Cnpj = rdr["cnpj"].ToString();
                    fornecedor.Contato = rdr["contato"].ToString();
                    fornecedor.Email = rdr["email"].ToString();
                    fornecedor.Endereco = rdr["endereco"].ToString();
                    fornecedor.Estado = rdr["estado"].ToString();
                    fornecedor.Fax = rdr["fax"].ToString();
                    fornecedor.InscricaoEstadual = rdr["inscricaoEstadual"].ToString();
                    fornecedor.Nome = rdr["nome"].ToString();
                    fornecedor.Site = rdr["site"].ToString();
                    fornecedor.Telefone = rdr["telefone"].ToString();
                    fornecedor.DataCadastro = (DateTime)rdr["dataCadastro"];

                    fornecedores.Add(fornecedor);
                }

                return fornecedores;
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

        static public Library.Fornecedor FindById(long idFornecedor)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Fornecedor Fornecedor = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Fornecedor WHERE id='" + idFornecedor + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Fornecedor");

                if (ds.Tables["Fornecedor"].Rows.Count == 1)
                {
                    Fornecedor = new Fornecedor();
                    Fornecedor.Id = (long)ds.Tables["Fornecedor"].Rows[0]["id"];
                    Fornecedor.Bairro = ds.Tables["Fornecedor"].Rows[0]["bairro"].ToString();
                    Fornecedor.Cep = ds.Tables["Fornecedor"].Rows[0]["cep"].ToString();
                    Fornecedor.Cidade = ds.Tables["Fornecedor"].Rows[0]["cidade"].ToString();
                    Fornecedor.Cnpj = ds.Tables["Fornecedor"].Rows[0]["cnpj"].ToString();
                    Fornecedor.Contato = ds.Tables["Fornecedor"].Rows[0]["contato"].ToString();
                    Fornecedor.Email = ds.Tables["Fornecedor"].Rows[0]["email"].ToString();
                    Fornecedor.Endereco = ds.Tables["Fornecedor"].Rows[0]["endereco"].ToString();
                    Fornecedor.Estado = ds.Tables["Fornecedor"].Rows[0]["estado"].ToString();
                    Fornecedor.Fax = ds.Tables["Fornecedor"].Rows[0]["fax"].ToString();
                    Fornecedor.InscricaoEstadual = ds.Tables["Fornecedor"].Rows[0]["inscricaoEstadual"].ToString();
                    Fornecedor.Nome = ds.Tables["Fornecedor"].Rows[0]["nome"].ToString();
                    Fornecedor.Site = ds.Tables["Fornecedor"].Rows[0]["site"].ToString();
                    Fornecedor.Telefone = ds.Tables["Fornecedor"].Rows[0]["telefone"].ToString();
                    Fornecedor.DataCadastro = (DateTime)ds.Tables["Fornecedor"].Rows[0]["dataCadastro"];

                }
                return Fornecedor;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Fornecedor') AS lastId";

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
