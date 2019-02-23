using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Library
{
    public class Funcionario
    {
        public Funcionario()
        {
        }

        public long Id { get; set; }
        public Library.Cargo Cargo { get; set; }
        public Library.Permissoes Permissao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Celular { get; set; }
        public int ComissaoVenda { get; set; }
        public int Comissao { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public int? DiaPagamento { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public decimal Salario { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
    public class FuncionarioBD
    {
        private FuncionarioBD()
        {
        }

        static public void Save(Library.Funcionario funcionario)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Funcionario (idCargo, idSeguranca, login, senha, bairro, cep, cidade, comissaoVenda, comissao, celular, cpf, email, endereco, estado, diaPagamento,nascimento,nome,rg,salario,site,telefone,dataCadastro) VALUES (@idCargo, @idSeguranca, @login, @senha, @bairro, @cep, @cidade, @comissaoVenda, @comissao, @celular, @cpf, @email, @endereco, @estado, @diaPagamento, @nascimento, @nome, @rg, @salario, @site, @telefone, @dataCadastro)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idCargo", funcionario.Cargo.Id);
                comando.Parameters.AddWithValue("@idSeguranca", funcionario.Permissao.Id);
                comando.Parameters.AddWithValue("@login", funcionario.Login);
                comando.Parameters.AddWithValue("@senha", new Library.Classes.Password(funcionario.Senha).ToString());
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cep", funcionario.Cep);
                comando.Parameters.AddWithValue("@celular", funcionario.Celular);
                comando.Parameters.AddWithValue("@cidade", funcionario.Celular);
                comando.Parameters.AddWithValue("@comissaoVenda", funcionario.ComissaoVenda);
                comando.Parameters.AddWithValue("@comissao", funcionario.Comissao);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@diaPagamento", funcionario.DiaPagamento);
                if (funcionario.Nascimento != null & funcionario.Nascimento > SqlDateTime.MinValue.Value & funcionario.Nascimento < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@nascimento", funcionario.Nascimento);
                else
                    comando.Parameters.AddWithValue("@nascimento", SqlDateTime.Null);
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@site", funcionario.Site);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@dataCadastro", funcionario.DataCadastro);
                
                conexao.Open();

                //comando.ExecuteNonQuery();
                funcionario.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Funcionario funcionario)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Funcionario SET idCargo = @idCargo, idSeguranca = @idSeguranca, login = @login, senha = @senha, bairro = @bairro, cep = @cep, cidade = @cidade, comissaoVenda = @comissaoVenda, comissao = @comissao, celular = @celular, cpf = @cpf, email = @email, endereco = @endereco, estado = @estado, diaPagamento = @diaPagamento, nascimento = @nascimento, nome = @nome, rg = @rg, salario = @salario, telefone = @telefone, dataCadastro = @dataCadastro WHERE (id= " + funcionario.Id + ")";
                comando.Parameters.AddWithValue("@idCargo", funcionario.Cargo.Id);
                comando.Parameters.AddWithValue("@idSeguranca", funcionario.Permissao.Id);
                comando.Parameters.AddWithValue("@login", funcionario.Login);
                comando.Parameters.AddWithValue("@senha", funcionario.Senha);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cep", funcionario.Cep);
                comando.Parameters.AddWithValue("@celular", funcionario.Celular);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@comissaoVenda", funcionario.ComissaoVenda);
                comando.Parameters.AddWithValue("@comissao", funcionario.Comissao);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@diaPagamento", funcionario.DiaPagamento);
                if (funcionario.Nascimento != null & funcionario.Nascimento > SqlDateTime.MinValue.Value & funcionario.Nascimento < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@nascimento", funcionario.Nascimento);
                else
                    comando.Parameters.AddWithValue("@nascimento", SqlDateTime.Null);
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@site", funcionario.Site);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@dataCadastro", funcionario.DataCadastro);

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

        static public void DeleteById(long idFuncionario)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Funcionario WHERE id='" + idFuncionario + "'";

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

        static public List<Library.Funcionario> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Funcionario AS f ";

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

                List<Library.Funcionario> funcionarios = new List<Library.Funcionario>();

                while (rdr.Read())
                {
                    Library.Funcionario funcionario = new Funcionario();
                    funcionario.Id = (long)rdr["id"];
                    funcionario.Cargo = Library.CargoBD.FindById((long)rdr["idCargo"]);
                    funcionario.Permissao = Library.PermissoesBD.FindById((long)rdr["idSeguranca"]);
                    funcionario.Login = rdr["login"].ToString();
                    funcionario.Senha = rdr["senha"].ToString();
                    funcionario.Bairro = rdr["bairro"].ToString();
                    funcionario.Cep = rdr["cep"].ToString();
                    funcionario.Celular = rdr["celular"].ToString();
                    funcionario.Cidade = rdr["cidade"].ToString();
                    funcionario.ComissaoVenda = (int)rdr["comissaoVenda"];
                    funcionario.Comissao = (int)rdr["comissao"];
                    funcionario.Cpf = rdr["cpf"].ToString();
                    funcionario.Email = rdr["email"].ToString();
                    funcionario.Endereco = rdr["endereco"].ToString();
                    funcionario.Estado = rdr["estado"].ToString();
                    funcionario.DiaPagamento = (int)rdr["diaPagamento"];
                    DateTime data = DateTime.MinValue;
                    DateTime.TryParse(rdr["nascimento"].ToString(), out data);
                    funcionario.Nascimento = data; 
                    funcionario.Nome = rdr["nome"].ToString();
                    funcionario.Rg = rdr["rg"].ToString();
                    funcionario.Salario = (decimal)rdr["salario"];
                    funcionario.Site = rdr["site"].ToString();
                    funcionario.Telefone = rdr["telefone"].ToString();
                    funcionario.DataCadastro = (DateTime)rdr["dataCadastro"];

                    funcionarios.Add(funcionario);
                }

                return funcionarios;
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

        static public Library.Funcionario FindById(long idFuncionario)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Funcionario funcionario = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Funcionario WHERE id='" + idFuncionario + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Funcionario");

                if (ds.Tables["Funcionario"].Rows.Count == 1)
                {
                    funcionario = new Funcionario();
                    funcionario.Id = (long)ds.Tables["Funcionario"].Rows[0]["id"];
                    funcionario.Cargo = Library.CargoBD.FindById((long)ds.Tables["Funcionario"].Rows[0]["idCargo"]);
                    funcionario.Permissao = Library.PermissoesBD.FindById((long)ds.Tables["Funcionario"].Rows[0]["idSeguranca"]);
                    funcionario.Login = ds.Tables["Funcionario"].Rows[0]["login"].ToString();
                    funcionario.Senha = ds.Tables["Funcionario"].Rows[0]["senha"].ToString();
                    funcionario.Bairro = ds.Tables["Funcionario"].Rows[0]["bairro"].ToString();
                    funcionario.Cep = ds.Tables["Funcionario"].Rows[0]["cep"].ToString();
                    funcionario.Celular = ds.Tables["Funcionario"].Rows[0]["celular"].ToString();
                    funcionario.Cidade = ds.Tables["Funcionario"].Rows[0]["cidade"].ToString();
                    funcionario.ComissaoVenda = (int)ds.Tables["Funcionario"].Rows[0]["comissaoVenda"];
                    funcionario.Comissao = (int)ds.Tables["Funcionario"].Rows[0]["comissao"];
                    funcionario.Cpf = ds.Tables["Funcionario"].Rows[0]["cpf"].ToString();
                    funcionario.Email = ds.Tables["Funcionario"].Rows[0]["email"].ToString();
                    funcionario.Endereco = ds.Tables["Funcionario"].Rows[0]["endereco"].ToString();
                    funcionario.Estado = ds.Tables["Funcionario"].Rows[0]["estado"].ToString();
                    funcionario.DiaPagamento = (int)ds.Tables["Funcionario"].Rows[0]["diaPagamento"];
                    DateTime data = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["Funcionario"].Rows[0]["nascimento"].ToString(), out data);
                    funcionario.Nascimento = data; 
                    funcionario.Nome = ds.Tables["Funcionario"].Rows[0]["nome"].ToString();
                    funcionario.Rg = ds.Tables["Funcionario"].Rows[0]["rg"].ToString();
                    funcionario.Salario = (decimal)ds.Tables["Funcionario"].Rows[0]["salario"];
                    funcionario.Site = ds.Tables["Funcionario"].Rows[0]["site"].ToString();
                    funcionario.Telefone = ds.Tables["Funcionario"].Rows[0]["telefone"].ToString();
                    funcionario.DataCadastro = (DateTime)ds.Tables["Funcionario"].Rows[0]["dataCadastro"];
                }
                return funcionario;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Funcionario') AS lastId";

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

        static public bool Logar(string login, string senha, out Library.Funcionario funcionario, out string menssage)
        {
            SqlDataReader rdr1 = null;
            SqlDataReader rdr2 = null;
            SqlConnection conexao = null;
            int count1 = 0;
            int count2 = 0;

            try
            {



                using (SqlCommand comando1 = new SqlCommand())
                {
                    conexao = new SqlConnection(global::Connection.Connection.String());
                    conexao.Open();

                    string query1 = "SELECT * FROM Funcionario WHERE login = @login";
                    comando1.Parameters.AddWithValue("@login", login);
                    comando1.Connection = conexao;
                    comando1.CommandText = query1;
                    rdr1 = comando1.ExecuteReader();

                    while (rdr1.Read())
                        count1++;

                    conexao = null;
                }


                List<Library.Funcionario> funcionarios = new List<Library.Funcionario>();

                if (count1 > 0)
                {
                    using (SqlCommand comando2 = new SqlCommand())
                    {
                        conexao = new SqlConnection(global::Connection.Connection.String());
                        conexao.Open();

                        string query2 = "SELECT * FROM Funcionario WHERE login = @login AND senha = @senha";
                        comando2.Parameters.AddWithValue("@login", login);
                        comando2.Parameters.AddWithValue("@senha", new Library.Classes.Password(senha).ToString());
                        comando2.Connection = conexao;
                        comando2.CommandText = query2;

                        rdr2 = comando2.ExecuteReader();

                        while (rdr2.Read())
                        {
                            count2++;

                            Library.Funcionario funcionarioTMP = new Funcionario();
                            funcionarioTMP.Id = (long)rdr2["id"];
                            funcionarioTMP.Cargo = Library.CargoBD.FindById((long)rdr2["idCargo"]);
                            funcionarioTMP.Permissao = Library.PermissoesBD.FindById((long)rdr2["idSeguranca"]);
                            funcionarioTMP.Login = rdr2["login"].ToString();
                            funcionarioTMP.Senha = rdr2["senha"].ToString();
                            funcionarioTMP.Bairro = rdr2["bairro"].ToString();
                            funcionarioTMP.Cep = rdr2["cep"].ToString();
                            funcionarioTMP.Celular = rdr2["celular"].ToString();
                            funcionarioTMP.Cidade = rdr2["cidade"].ToString();
                            funcionarioTMP.ComissaoVenda = (int)rdr2["comissaoVenda"];
                            funcionarioTMP.Comissao = (int)rdr2["comissao"];
                            funcionarioTMP.Cpf = rdr2["cpf"].ToString();
                            funcionarioTMP.Email = rdr2["email"].ToString();
                            funcionarioTMP.Endereco = rdr2["endereco"].ToString();
                            funcionarioTMP.Estado = rdr2["estado"].ToString();
                            funcionarioTMP.DiaPagamento = (int)rdr2["diaPagamento"];
                            DateTime data = DateTime.MinValue;
                            DateTime.TryParse(rdr2["nascimento"].ToString(), out data);
                            funcionarioTMP.Nascimento = data;
                            funcionarioTMP.Nome = rdr2["nome"].ToString();
                            funcionarioTMP.Rg = rdr2["rg"].ToString();
                            funcionarioTMP.Salario = (decimal)rdr2["salario"];
                            funcionarioTMP.Site = rdr2["site"].ToString();
                            funcionarioTMP.Telefone = rdr2["telefone"].ToString();
                            funcionarioTMP.DataCadastro = (DateTime)rdr2["dataCadastro"];

                            funcionarios.Add(funcionarioTMP);
                        }
                        conexao = null;
                    }

                    if (count2 != 0)
                    {
                        funcionario = funcionarios[0];
                        menssage = "Usuário encontrado!";
                        return true;
                    }
                    else
                    {
                        menssage = "Login e Senha incompatíveis!";
                        funcionario = null;
                        return false;
                    }
                }
                else
                {
                    menssage = "Usuário não encontrado!";
                    funcionario = null;
                    return false;
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
            menssage = "Erro - Contate um desenvolvedor. [(22) 3852-2203]";
            funcionario = null;
            return false;
        }
    }
}
