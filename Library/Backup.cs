using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Backup
    {
        private Backup()
        {
        }

        static public void Execute(string file)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "BACKUP DATABASE VendaBD TO DISK=@back";

                comando.Parameters.AddWithValue("@back", file);

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
    }
}
