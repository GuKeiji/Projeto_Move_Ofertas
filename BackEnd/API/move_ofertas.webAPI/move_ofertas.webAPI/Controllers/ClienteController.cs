using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Clientes
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }
        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente novoCliente)
        {
            try
            {
                _clienteRepository.Cadastrar(novoCliente);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_clienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
