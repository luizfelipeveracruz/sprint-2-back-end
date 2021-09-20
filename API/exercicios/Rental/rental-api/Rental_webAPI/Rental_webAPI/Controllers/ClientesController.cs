using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_webAPI.Domains;
using Rental_webAPI.Interfaces;
using Rental_webAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controlador responsável pelo end points referentes aos clientes.
/// </summary>
namespace Rental_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no Formato JSON.
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/clientes
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]
    public class ClientesController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface IClienteRepository 
        /// </summary>
        private IClienteRepository _ClienteRepository { get; set; }

        /// <summary>
        /// Instacia um objeto _ClienteRepository para que haja a referencia dos método no reposotório.
        /// </summary>
        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        //IActionResult = Resultado de uma acao.
        //Get() = nome generico
        public IActionResult Get()
        {
            try 
            { 
            //Lista de clientes
            //Se conectar com o Repositorio.

            //Criar uma lista nomeada listaClientes para receber os dados.
            List<ClienteDomain> listaClientes = _ClienteRepository.ListarTodos();

            //Retorna os status code 200(OK) com a lista cliente no formato JSON
            return Ok(listaClientes);
            } catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado!");
            }

            return Ok(clienteBuscado);
            //return StatusCode(200, clienteBuscado);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            //Fazer a chamada para o método .Cadastrar();
            _ClienteRepository.Cadastrar(novoCliente);

            //Retorna um status code 201 - Created.
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, ClienteDomain clienteAtualizado)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Cliente não encontrado!",
                        erro = true
                    });
            }

                _ClienteRepository.AtualizarIdUrl(id, clienteAtualizado);

                return NoContent();
        
        }
        
            [HttpDelete("{IdDeleta}")]
        public IActionResult Delete(int IdDeleta)
        {
                //Fazer a chamada para o método .Deletar();
                _ClienteRepository.Deletar(IdDeleta);
            
                //Retorna um status code 204 - Deleted.
                return StatusCode(204);

        }
    }
}
