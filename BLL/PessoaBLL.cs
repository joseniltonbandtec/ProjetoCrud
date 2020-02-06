using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.Model;
using Crud.Dao;
using System.Data;

namespace Crud.Bll
{
    class PessoaBLL
    {
        PessoaDAO pessoaDao = new PessoaDAO();


        // Método para salvar
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                pessoaDao.Salvar(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        // Método para listar

        public void Cadastro(Pessoa pessoa)
        {
            try
            {
                pessoaDao.Cadastro(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = pessoaDao.Listar();
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //Metodo para editar os dados da pessoas
        public void Editar(Pessoa pessoa)
        {
            try
            {
                pessoaDao.Editar(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Deletar(Pessoa pessoa)
        {
            try
            {
                pessoaDao.Excluir(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable Pesquisa(Pessoa pessoa)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = pessoaDao.Pesquisa(pessoa);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
