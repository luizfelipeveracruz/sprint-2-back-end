using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_webAPI.Domains;
using Rental_webAPI.Interfaces;
using Rental_webAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Properties.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AluguelDomain> ListaAlgueis = _AluguelRepository.ListarTodos();

                return Ok(ListaAlgueis);
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
                AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

                if (aluguelBuscado != null)
                {
                    return Ok(aluguelBuscado);
                }

                return NotFound("aluguel não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain NovoAluguel)
        {
            try
            {
                _AluguelRepository.Cadastrar(NovoAluguel);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{IdDeleta}")]
        public IActionResult Delete(int IdDeleta)
        {
            try
            {
                _AluguelRepository.Deletar(IdDeleta);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Put(AluguelDomain AluguelAtualizar)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(AluguelAtualizar.idAluguel);

            if (AluguelBuscado != null)
            {
                try
                {
                    _AluguelRepository.AtualizarIdCorpo(AluguelAtualizar);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound(new
            {
                mensagem = "Aluguel não encontrado",
                Coderro = true
            });
        }
    }
}
