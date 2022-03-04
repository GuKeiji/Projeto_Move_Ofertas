using Microsoft.AspNetCore.Http;
using move_ofertas.webAPI.Contexts;
using move_ofertas.webAPI.Domains;
using move_ofertas.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Repositories
{
    public class OfertasRepository : IOfertaRepository
    {
        MoveOfertasContext ctx = new MoveOfertasContext();
        public void AlterarDescricao(string descricao, int id)
        {
            Ofertum ofertaBuscada = BuscarPorId(id);
            if (descricao != null)
            {
                ofertaBuscada.Descricao = descricao;
                ctx.Oferta.Update(ofertaBuscada);
                ctx.SaveChanges();
            }
        }

        public Ofertum BuscarPorId(int id)
        {
            return ctx.Oferta.FirstOrDefault(c => c.IdOferta == id);
        }

        public void CadastrarOferta(Ofertum novaOferta)
        {
            ctx.Oferta.Add(novaOferta);
            ctx.SaveChanges();
        }

        public string ConsultarImagemBD(int id)
        {
            Imagemofertum imagemOferta = new Imagemofertum();

            imagemOferta = ctx.Imagemoferta.FirstOrDefault(i => i.IdOferta == id);

            if (imagemOferta != null)
            {
                return Convert.ToBase64String(imagemOferta.Binario);
            }

            return null;
        }

        public List<Ofertum> ListarMinhasOfertas(int id, int idTipoUsuario)
        {
            if (idTipoUsuario == 1)
            {
                Empresa empresa = ctx.Empresas.FirstOrDefault(u => u.IdUsuario == id);

                int idEmpresa = empresa.IdEmpresa;

                return ctx.Oferta
                                .Where(o => o.IdEmpresa == idEmpresa)
                                .Select(p => new Ofertum()
                                {
                                    NomeProduto = p.NomeProduto,
                                    Valor = p.Valor,
                                    Quantidade = p.Quantidade,
                                    DataFabricacao = p.DataFabricacao,
                                    DataValidade = p.DataValidade,
                                    Descricao = p.Descricao,
                                    IdCategoriaNavigation = new Categorium()
                                    {
                                        NomeCategoria = p.IdCategoriaNavigation.NomeCategoria
                                    },
                                    IdEmpresaNavigation = new Empresa()
                                    {
                                        NomeEmpresa = p.IdEmpresaNavigation.NomeEmpresa
                                    }
                                })
                                .ToList();
            }
            return null;
            /*else if (idTipoUsuario == 2)
            {
                Cliente cliente = ctx.Clientes.FirstOrDefault(u => u.IdUsuario == id);

                int idCliente = cliente.IdCliente;

                return ctx.Oferta
                                .Where(o => o.IdCliente == IdCliente)
                                .Select(p => new Ofertum()
                                {
                                    NomeProduto = p.NomeProduto,
                                    Valor = p.Valor,
                                    Quantidade = p.Quantidade,
                                    DataFabricacao = p.DataFabricacao,
                                    DataValidade = p.DataValidade,
                                    SituacaoOferta = p.SituacaoOferta,
                                    Imagem = p.Imagem,
                                    Descricao = p.Descricao,
                                    IdCategoriaNavigation = new Categorium()
                                    {
                                        NomeCategoria = p.IdCategoriaNavigation.NomeCategoria
                                    },
                                    IdEmpresaNavigation = new Empresa()
                                    {
                                        NomeEmpresa = p.IdEmpresaNavigation.NomeEmpresa
                                    }
                                })
                                .ToList();
            }
            */

        }

        public List<Ofertum> ListarTodas()
        {
            return ctx.Oferta
                                .Select(p => new Ofertum()
                                {
                                    NomeProduto = p.NomeProduto,
                                    Valor = p.Valor,
                                    Quantidade = p.Quantidade,
                                    DataFabricacao = p.DataFabricacao,
                                    DataValidade = p.DataValidade,
                                    Descricao = p.Descricao,
                                    IdCategoriaNavigation = new Categorium()
                                    {
                                        NomeCategoria = p.IdCategoriaNavigation.NomeCategoria
                                    },
                                    IdEmpresaNavigation = new Empresa()
                                    {
                                        NomeEmpresa = p.IdEmpresaNavigation.NomeEmpresa
                                    },
                                    IdSituacaoNavigation = new Situacao()
                                    {
                                        NomeSituacao = p.IdSituacaoNavigation.NomeSituacao
                                    }
                                })
                                .ToList();
        }

        public void RemoverOferta(int id)
        {
            ctx.Oferta.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public void SalvarImagemBD(IFormFile foto, int id)
        {
            Imagemofertum imagemOferta = new Imagemofertum();

            using (var ms = new MemoryStream())
            {
                //copia a imagem enviada para a memoria.
                foto.CopyTo(ms);
                //ToArray = são os bytes da imagem.
                imagemOferta.Binario = ms.ToArray();
                //nome do arquivo
                imagemOferta.NomeArquivo = foto.FileName;
                //extensão do arquivo
                imagemOferta.MimeType = foto.FileName.Split('.').Last();
                //id_usuario
                imagemOferta.IdOferta = id;
            }

            //ANALISAR SE O USUARIO JA POSSUI FOTO DE PERFIL
            Imagemofertum fotoexistente = new Imagemofertum();
            fotoexistente = ctx.Imagemoferta.FirstOrDefault(i => i.IdOferta == id);

            if (fotoexistente != null)
            {
                fotoexistente.Binario = imagemOferta.Binario;
                fotoexistente.NomeArquivo = imagemOferta.NomeArquivo;
                fotoexistente.MimeType = imagemOferta.MimeType;
                fotoexistente.IdOferta = id;

                //atualiza a imagem de perfil do usuario.
                ctx.Imagemoferta.Update(fotoexistente);
            }
            else
            {
                ctx.Imagemoferta.Add(imagemOferta);
            }

            ctx.SaveChanges();
        }
    }
}
