using Rental_webAPI.Domains;
using Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Repository
{
    public class AluguelRepository : IAluguelRepository
    {   //Conexão pelas infos de login do senai
        /// <summary>
        /// String de conexão que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// initial  catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando login e senha
        /// integrated security = Faz a autenticação com o usuário do sistema(windows)
        /// </summary>
        //private string stringConexao = "Data Source=NOTE0113I2\\SQLEXPRESS; initial catalog=GBM_Rental; user id=sa; pwd=Senai@132";

        //Conecta pelo windows de casa
        /// <summary>
        /// String de conexão que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// initial  catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando login e senha
        /// integrated security = Faz a autenticação com o usuário do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=LAPTOP-DLKSO2O5\\SQLEXPRESS; initial catalog=Rental_M; integrated security=true";
        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Aluguel SET IdVeiculo = @novoVeiculo, IdCliente = @novoCliente, DataRetirada = @novaDataR, DataDevolucao = @novaDataD WHERE IdAluguel = @idaluguel;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@novoCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@novaDataR", aluguelAtualizado.DataRetirada);
                    cmd.Parameters.AddWithValue("@novaDataD", aluguelAtualizado.DataDevolucao);

                    cmd.Parameters.AddWithValue("@idaluguel", aluguelAtualizado.idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

      

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryselectById = "SELECT IdAluguel, primeiroNome, sobreNome, nomeModelo, DataRetirada, DataDevolucao FROM Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo WHERE IdAluguel = @idaluguel;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryselectById, con))
                {
                    cmd.Parameters.AddWithValue("@idaluguel", idAluguel);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            Cliente = new ClienteDomain()
                            {
                                primeiroNome = rdr[1].ToString(),
                                sobreNome = rdr[2].ToString()
                            },
                            Veiculo = new VeiculoDomain()
                            {
                                Modelo = new ModeloDomain()
                                {
                                    nomeModelo = rdr[3].ToString()
                                },
                            },
                            DataRetirada = Convert.ToDateTime(rdr[5]),
                            DataDevolucao = Convert.ToDateTime(rdr[6])
                        };

                        return aluguelBuscado;
                    }
                }

                return null;
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel(IdVeiculo, IdCliente, DataRetirada, DataDevolucao) VALUES (@novoVeiculo, @novoCliente, @novaDataR, @novaDataD);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@novoCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@novaDataR", novoAluguel.DataRetirada);
                    cmd.Parameters.AddWithValue("@novaDataD", novoAluguel.DataDevolucao);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Aluguel WHERE IdAluguel = @idaluguel;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idaluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> ListaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryselectAll = "SELECT IdAluguel, primeiroNome, sobreNome, nomeModelo, CorVeiculo, DataRetirada, DataDevolucao FROM Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryselectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            Cliente = new ClienteDomain()
                            {
                                primeiroNome = rdr[1].ToString(),
                                sobreNome = rdr[2].ToString()
                            },
                            Veiculo = new VeiculoDomain()
                            {
                                Modelo = new ModeloDomain()
                                {
                                    nomeModelo = rdr[3].ToString()
                                },
                        
                            },
                            DataRetirada = Convert.ToDateTime(rdr[5]),
                            DataDevolucao = Convert.ToDateTime(rdr[6])
                        };

                        ListaAlugueis.Add(aluguel);
                    }
                }

                return ListaAlugueis;
            }
        }
    }
}
