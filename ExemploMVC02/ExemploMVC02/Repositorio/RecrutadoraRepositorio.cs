using ExemploMVC02.DataBase;
using ExemploMVC02.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExemploMVC02.Repositorio
{
    public class RecrutadoraRepositorio
    {

        public List<Recrutadora> ObterTodos()
        {
            List<Recrutadora> recrutadoras = new List<Recrutadora>();
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "SELECT id, nome, cpf, tempo_empresa, salario FROM recrutadoras";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            foreach (DataRow linha in tabela.Rows)
            {
                Recrutadora recrutadora = new Recrutadora()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    CPF = linha[2].ToString(),
                    TempoEmpresa = Convert.ToByte(linha[3].ToString()),
                    Salario = Convert.ToDecimal(linha[4].ToString())
                };
                recrutadoras.Add(recrutadora);
            }

            return recrutadoras;
        }


        public int Cadastrar(Recrutadora recrutadora)
        {
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "INSERT INTO recrutadoras (nome, salario, cpf, tempo_empresa) OUTPUT INSERTED.ID VALUES (@NOME, @SALARIO, @CPF, @TEMPO_EMPRESA)";
            command.Parameters.AddWithValue("@NOME", recrutadora.Nome);
            command.Parameters.AddWithValue("@SALARIO", recrutadora.Salario);
            command.Parameters.AddWithValue("@CPF", recrutadora.CPF);
            command.Parameters.AddWithValue("@TEMPO_EMPRESA", recrutadora.TempoEmpresa);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Recrutadora recrutadora)
        {
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "UPDATE recrutadoras SET nome = @NOME, cpf = @CPF, tempo_empresa = @TEMPO_EMPRESA, salario = @SALARIO WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", recrutadora.Nome);
            command.Parameters.AddWithValue("@SALARIO", recrutadora.Salario);
            command.Parameters.AddWithValue("@CPF", recrutadora.CPF);
            command.Parameters.AddWithValue("@TEMPO_EMPRESA", recrutadora.TempoEmpresa);
            command.Parameters.AddWithValue("@ID", recrutadora.Id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "DELETE FROM recrutadoras WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;


            return command.ExecuteNonQuery() == 1;
        }

        public Recrutadora ObterPeloId(int id)
        {

            Recrutadora recrutadora = null;
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "SELECT nome, cpf, tempo_empresa, salario FROM recrutadoras WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(command.ExecuteReader());
            if(tabela.Rows.Count == 1)
            {
                recrutadora = new Recrutadora();
                recrutadora.Id = id;
                recrutadora.Nome = tabela.Rows[0][0].ToString();
                recrutadora.CPF = tabela.Rows[0][1].ToString();
                recrutadora.TempoEmpresa = Convert.ToByte(tabela.Rows[0][2].ToString());
                recrutadora.Salario = Convert.ToDecimal(tabela.Rows[0][3].ToString());
            }
            return recrutadora;
        }


    }
}