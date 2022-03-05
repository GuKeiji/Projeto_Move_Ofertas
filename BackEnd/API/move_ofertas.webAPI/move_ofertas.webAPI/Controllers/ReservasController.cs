using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using move_ofertas.webAPI.Domains;
using move_ofertas.webAPI.Interfaces;
using move_ofertas.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {

        private IReservaRepository _reservaRepository { get; set; }

        public ReservasController()
        {
            _reservaRepository = new ReservaRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Reserva novaReserva)
        {
            try
            {
                _reservaRepository.Cadastrar(novaReserva);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_reservaRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Lista/Minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {

                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                int idTipoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                List<Reserva> listaReservas = _reservaRepository.ListarMinhasReservas(id, idTipoUsuario);

                if (listaReservas.Count == 0)
                {
                    return NotFound(new
                    {
                        Mensagem = "Não existem reservas com esse usuário"
                    });
                }

                if (idTipoUsuario == 1)
                {
                    return Ok(new
                    {
                        Mensagem = $"Você tem {_reservaRepository.ListarMinhasReservas(id, idTipoUsuario).Count} reservas",
                        listaReservas
                    });
                }

                return null;

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }
    }
}
