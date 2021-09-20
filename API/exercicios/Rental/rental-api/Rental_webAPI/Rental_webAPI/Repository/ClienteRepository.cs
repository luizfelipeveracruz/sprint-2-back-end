using Rental_webAPI.Domains;
using Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        //Conexão pelas infos de login do senai
        /// <summary>
        /// String de conexão que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// initial  catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando login e senha
        /// integrated security = Faz a autenticação com o usuário do sistema(windows)
        /// </summary>
        //private string stringConexao = "Data Source=\\SQLEXPRESS; initial catalog=Rental_M; user id=sa; pwd=Senai@132";

        //Conecta pelo windows de casa
        /// <summary>
        /// String de conexão que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// initial  catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando login e senha
        /// integrated security = Faz a autenticação com o usuário do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=localhost\\SQLEXPRESS01; initial catalog=Rental_M; integrated security=true";


        public void Atualizar(ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Cliente SET NomeCliente = @novoNome, SobrenomeCliente = @novoSobrenome, CPF = @novoCPF WHERE IdCliente = @Id;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", ClienteAtualizado.primeiroNome);
                    cmd.Parameters.AddWithValue("@novoSobrenome", ClienteAtualizado.sobreNome);
                    cmd.Parameters.AddWithValue("@novoCPF", ClienteAtualizado.CPF);
                    cmd.Parameters.AddWithValue("@Id", ClienteAtualizado.idCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, primeiroNome, sobreNome, CPF FROM Cliente WHERE idCliente = @idcliente;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idcliente", idCliente);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            primeiroNome = rdr[1].ToString(),
                            sobreNome = rdr[2].ToString(),
                            CPF = rdr[3].ToString()
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }


        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Cliente(primeiroNome, sobreNome, CPF) VALUES (@novoNome, @novoSobrenome, @novoCPF);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", novoCliente.primeiroNome);
                    cmd.Parameters.AddWithValue("@novoSobrenome", novoCliente.sobreNome);
                    cmd.Parameters.AddWithValue("@novoCPF", novoCliente.CPF);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Cliente WHERE idCliente = @idCliente;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    cmd.ExecuteNonQuery();
                }
            }
     
        }


        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> ListaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCliente, primeiroNome, sobreNome, CPF FROM Cliente;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            primeiroNome = rdr[1].ToString(),
                            sobreNome = rdr[2].ToString(),
                            CPF = rdr[3].ToString()
                        };

                        ListaClientes.Add(cliente);
                    }

                }
            }

            return ListaClientes;
        }






    }
}
