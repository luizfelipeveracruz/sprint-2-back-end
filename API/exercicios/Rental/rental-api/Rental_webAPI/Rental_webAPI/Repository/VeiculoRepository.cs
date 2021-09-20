using Rental_webAPI.Domains;
using Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        //Conexão pelas infos de login do senai
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

        public void Atualizar(VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Veiculo SET idEmpresa = @novaEmpresa, idModelo = @novoModelo, WHERE idVeiculo =  @idveiculo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novaEmpresa", veiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@novoModelo", veiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@idveiculo", veiculoAtualizado.idVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorid(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryById = "SELECT idVeiculo, nomeEmpresa, nomeModelo, nomeMarca, FROM Veiculo LEFT JOIN Empresa ON Veiculo.idEmpresa = Empresa.idEmpresa INNER JOIN Modelo ON Veiculo.idModelo = Modelo.idModelo INNER JOIN Marca ON Modelo.idMarca = Marca.idMarca WHERE idVeiculo = @idveiculo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryById, con))
                {
                    cmd.Parameters.AddWithValue("@idveiculo", idVeiculo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[1].ToString()
                            },
                            Modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[2].ToString(),
                                 Marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[3].ToString()
                                }
                            },
                        };

                        return veiculoBuscado;
                    }

                    return null;
                }
            }
        }


        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo(idEmpresa, idModelo, VALUES (@novaEmpresa, @novoModelo);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novaEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@novoModelo", novoVeiculo.idModelo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idDeletar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculo WHERE idVeiculo = @idveiculo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idveiculo", idDeletar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idVeiculo, nomeEmpresa, nomeModelo, nomeMarca, FROM Veiculo LEFT JOIN Empresa ON Veiculo.idEmpresa = Empresa.idEmpresa INNER JOIN Modelo ON Veiculo.idModelo = Modelo.idModelo INNER JOIN Marca ON Modelo.idMarca = Marca.idMarca;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[1].ToString()
                            },
                            Modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[2].ToString(),
                                Marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[3].ToString()
                                }
                            },
                        };

                        ListaVeiculos.Add(veiculo);
                    }
                }

                return ListaVeiculos;
            }
        }




    }
}
