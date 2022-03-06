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
                        Mensagem = "Não existem ofertas cadastradas"
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

        [HttpPatch("Alterar/{id}")]
        public IActionResult Alterar(Ofertum ofertaAtualizada, int id)
        {
            try
            {
                _ofertaRepository.Alterar(ofertaAtualizada, id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult RemoverOferta(int id)
        {
            try
            {
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
                        Mensagem = "Não existe oferta com esse ID"
                    });
                }

                _ofertaRepository.RemoverOferta(id);

                return StatusCode(200, new
                {
                    Mensagem = "Oferta removida"
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPost("imagem/bd")]
        public IActionResult postBD(IFormFile arquivo)
        {
            try
            {
                //analise de tamanho do arquivo.
                if (arquivo.Length > 5000000) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                string extensao = arquivo.FileName.Split('.').Last();

                //if (extensao != "png")
                //    return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos." });


                int idOferta = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _ofertaRepository.SalvarImagemBD(arquivo, idOferta);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }

        [HttpGet("imagem/bd")]
        public IActionResult getbd()
        {
            try
            {

                int idOferta = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _ofertaRepository.ConsultarImagemBD(idOferta);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("verify/validade")]
        public IActionResult VerificarVal(int id)
        {
            try
            {              
               if (id == 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Id inválido"
                    });
                }             
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(_ofertaRepository.VerificarValidade(id));
        }
    }
}
