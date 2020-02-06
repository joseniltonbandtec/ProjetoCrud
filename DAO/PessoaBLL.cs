using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Crud.Model;
using System.Data;

namespace Crud.Dao
{
    public class PessoaDAO : Conexao
    {
        MySqlCommand comando = null;

        public void Cadastro(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("INSERT INTO Usuarios (NomeUsuario, Senha, Idade, Numr_celular) VALUES (@nome, @senha, @idade, @cel)", conexao);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@senha", pessoa.Sexo);
                comando.Parameters.AddWithValue("@idade", pessoa.Telefone);
                comando.Parameters.AddWithValue("@cel", pessoa.Celular);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Salvar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO pessoa (nome, sexo, telefone, celular, endereco, bairro, cidade, estado) VALUES (@nome, @sexo, @tel, @cel, @endereco, @bairro, @cidade, @estado)", conexao);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@tel", pessoa.Telefone);
                comando.Parameters.AddWithValue("@cel", pessoa.Celular);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        public DataTable Listar()
        {
            try
            {
                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM Pessoa ORDER BY nome", conexao);

                da.SelectCommand = comando;

                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        // Método para editar os dados da pessoa

        public void Editar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE pessoa set nome = @nome, sexo = @sexo, telefone = @tel, celular = @cel, endereco = @endereco, bairro = @bairro, cidade = @cidade, estado = @estado WHERE id_pessoa = @idPessoa", conexao);

                comando.Parameters.AddWithValue("@idPessoa", pessoa.Id_Pessoa);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@tel", pessoa.Telefone);
                comando.Parameters.AddWithValue("@cel", pessoa.Celular);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM pessoa WHERE id_pessoa = @idPessoa", conexao);

                comando.Parameters.AddWithValue("@idPessoa", pessoa.Id_Pessoa);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        public DataTable Pesquisa(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                comando = new MySqlCommand("SELECT * FROM pessoa WHERE nome LIKE '%' @nome '%' ORDER BY nome", conexao);

                comando.Parameters.AddWithValue("@nome", pessoa.Nome);

                da.SelectCommand = comando;
                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
