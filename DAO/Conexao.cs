using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Crud.Dao
{
    public class Conexao
    {
        string conecta = "DATABASE=Crud; SERVER=localhost; UID=root; PWD=junior";
        protected MySqlConnection conexao = null;

        // metodo para concetar no banco
        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        // Método para fechar a coneção do banco

        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
