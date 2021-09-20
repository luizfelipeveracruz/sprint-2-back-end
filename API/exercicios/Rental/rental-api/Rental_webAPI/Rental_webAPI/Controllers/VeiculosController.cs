using Microsoft.AspNetCore.Mvc;
using Rental_webAPI.Domains;
using Rental_webAPI.Interfaces;
using Rental_webAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Controllers
{   //Define que o tipo de resposta da API será no Formato JSON.
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController.
    
    // ex: http://localhost:5000/api/clientes
    
    [Route("api/[controller]")]
    
    //Define que é um controlador de API.
    
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<VeiculoDomain> ListaVeiculos = _VeiculoRepository.ListarTodos();

                return Ok(ListaVeiculos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            try
            {
                VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorid(id);

                if (VeiculoBuscado == null)
                {
                    return NotFound("Veiculo não encontrado");
                }

                return Ok(VeiculoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            try
            {
                _VeiculoRepository.Cadastrar(novoVeiculo);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idDeleta}")]
        public IActionResult Delete(int idDeleta)
        {
            try
            {
                _VeiculoRepository.Deletar(idDeleta);
                return StatusCode(204);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Put(VeiculoDomain VeiculoAtualizar)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorid(VeiculoAtualizar.idVeiculo);

            if (VeiculoBuscado != null)
            {
                try
                {
                    _VeiculoRepository.Atualizar(VeiculoAtualizar);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }

            return NotFound(new
            {
                mensagem = "Veiculo não encontrado",
                Coderro = true
            });

        }

    }
}
