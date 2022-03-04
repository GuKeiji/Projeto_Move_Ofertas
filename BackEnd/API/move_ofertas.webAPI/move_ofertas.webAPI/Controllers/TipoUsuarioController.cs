using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using move_ofertas.webAPI.Interfaces;
using move_ofertas.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try 
            {
                return Ok(_tipoUsuarioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
