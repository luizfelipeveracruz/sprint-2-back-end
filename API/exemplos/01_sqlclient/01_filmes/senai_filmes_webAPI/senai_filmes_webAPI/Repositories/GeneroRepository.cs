﻿using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{

    
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source = Nome do Servidor
        /// inital catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando Login e Senha.
        /// integrated security = Faz a autenticação com o usuario do sistema (Windows).
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";

        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; integrated security=true";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idGenero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            
            
                //Cria uma listaGeneros onde serão armazenados os dados.
                List<GeneroDomain> listaGenero = new List<GeneroDomain>();

                //Declara a SQL connection con passando a string de conexao como parametro.
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    //Declara a instrucao a ser executada
                    string querySelectALL = "SELECT idGenero,nomeGenero FROM GENERO;";

                    //Abre a conexão com o banco de dados.
                    con.Open();

                    //Declara o SqlDataReader rar para percorrer a tabela do banco de dados.
                    SqlDataReader rdr;

                    //Declara o SQLCommand cmd passando a query que sera executada e a conexão com parâmetros.
                    using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                    {
                        //executa a query e armaneza os dados no rdr.
                        rdr = cmd.ExecuteReader();

                        //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                        while (rdr.Read())
                        {
                            //Instancia um objeto genero do tipo GeneroDomain
                            GeneroDomain genero = new GeneroDomain()
                            {
                                //atribui a propriedade idGenero o valor da primeira coluna na tabela do banco de dados.
                                idGenero = Convert.ToInt32(rdr[0]),

                                //atribui a propriedade nomeGenero o valor da segunda coluna na tabela do banco de dados.
                                nomeGenero = rdr[1].ToString()
                            };

                            //Adicionar o objeto genero criado a lista listaGeneros.
                            listaGenero.Add(genero);
                        }
                    }
                }


                return listaGenero;

        }
    }
}
