using System;
using System.Configuration;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace SeuProjeto.Data
{
    public class CadastroDAO
    {
        private readonly string ConnectionString;

        public CadastroDAO()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["PostgreConnection"].ConnectionString;
        }

        
        private void RegistrarLog(string tipoOperacao)
        {
          
            string sql = "INSERT INTO auditoria (data_hora, tipo_mov) VALUES (CURRENT_TIMESTAMP, @Tipo)";

            using (var conn = new NpgsqlConnection(ConnectionString))
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Tipo", tipoOperacao);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Falha ao registrar log: " + ex.Message);
                }
            }
        }

       

        public bool InserirCadastro(string texto, int numero)
        {
            string sql = "INSERT INTO cadastro (campo_texto, campo_numerico) VALUES (@Texto, @Numero)";

            using (var conn = new NpgsqlConnection(ConnectionString))
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Texto", texto);
                cmd.Parameters.AddWithValue("@Numero", numero);

                try
                {
                    conn.Open();
                    bool sucesso = cmd.ExecuteNonQuery() > 0;

                    if (sucesso) RegistrarLog("Insert");

                    return sucesso;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
        }

        public bool AtualizarCadastro(int id, string novoTexto, int novoNumero)
        {
            string sql = "UPDATE cadastro SET campo_texto = @Texto, campo_numerico = @Numero WHERE id = @Id";

            using (var conn = new NpgsqlConnection(ConnectionString))
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Texto", novoTexto);
                cmd.Parameters.AddWithValue("@Numero", novoNumero);

                try
                {
                    conn.Open();
                    bool sucesso = cmd.ExecuteNonQuery() > 0;

                    if (sucesso) RegistrarLog("Update"); // REGISTRA O LOG

                    return sucesso;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar: {ex.Message}");
                    return false;
                }
            }
        }

        public bool ExcluirCadastro(int id)
        {
            string sql = "DELETE FROM cadastro WHERE id = @Id";

            using (var conn = new NpgsqlConnection(ConnectionString))
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    conn.Open();
                    bool sucesso = cmd.ExecuteNonQuery() > 0;

                    if (sucesso) RegistrarLog("Delete"); // REGISTRA O LOG

                    return sucesso;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir: {ex.Message}");
                    return false;
                }
            }
        }

        public DataTable ListarCadastros()
        {
            string sql = "SELECT id, campo_texto, campo_numerico FROM cadastro ORDER BY id";
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(ConnectionString))
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao listar: " + ex.Message);
                }
            }
            return dt;
        }
    }
}