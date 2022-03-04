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
    public class OfertasController : ControllerBase
    {
        private IOfertaRepository _ofertaRepository { get; set; }

        public OfertasController()
        {
            _ofertaRepository = new OfertasRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Ofertum> listaOferta = _ofertaRepository.ListarTodas();
                if (listaOferta == null)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não existem consultas agendadas"
                    });
                }
                return Ok(listaOferta);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Ofertum novaOferta)
        {
            try
            {
                if (novaOferta.IdEmpresa == null || novaOferta.DataFabricacao < DateTime.Now || novaOferta.DataValidade < DateTime.Now)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Os dados estão incorretos"
                    });
                }
                _ofertaRepository.CadastrarOferta(novaOferta);

                return StatusCode(201, new
                {
                    Mensagem = "Oferta cadastrada",
                    novaOferta
                });
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("Lista/Minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {

                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                int idTipoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                List<Ofertum> listaOferta = _ofertaRepository.ListarMinhasOfertas(id, idTipoUsuario);

                if (listaOferta.Count == 0)
                {
                    return NotFound(new
                    {
                        Mensagem = "Não existem ofertas com esse usuário"
                    });
                }

                if (idTipoUsuario == 1)
                {
                    return Ok(new
                    {
                        Mensagem = $"A empresa tem {_ofertaRepository.ListarMinhasOfertas(id, idTipoUsuario).Count} ofertas",
                        listaOferta
                    });
                }
                
                return null;

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        [HttpPatch("AlterarDescricao/{id}")]
        public IActionResult AlterarDescricao(Ofertum ofertaAtualizada, int id)
        {
            try
            {
                if (ofertaAtualizada.Descricao == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Informe a descrição"
                    });
                }

                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "ID inválido"
                    });
                }

                if (_ofertaRepository.BuscarPorId(id) == null)
                {
                    return NotFound(new
                    {
                        Mensagem = "Não existem ofertas com esse ID"
                    });
                }
                _ofertaRepository.AlterarDescricao(ofertaAtualizada.Descricao, id);
                return StatusCode(200, new
                {
                    Mensagem = "Descrição da oferta alterada",
                    ofertaAtualizada
                });
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
