using move_ofertas.webAPI.Contexts;
using move_ofertas.webAPI.Domains;
using move_ofertas.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        MoveOfertasContext ctx = new MoveOfertasContext();

        public void Cadastrar(Reserva novaReserva)
        {
            ctx.Reservas.Add(novaReserva);

            ctx.SaveChanges();
        }

        public List<Reserva> ListarMinhasReservas(int id, int idTipoUsuario)
        {
            if (idTipoUsuario == 2)
            {
                Cliente cliente = ctx.Clientes.FirstOrDefault(u => u.IdUsuario == id);

                int idCliente = cliente.IdCliente;

                return ctx.Reservas
                                .Where(o => o.IdCliente == idCliente)
                                .Select(p => new Reserva()
                                {
                                    DataReserva = p.DataReserva,
                                    IdOfertaNavigation = new Ofertum()
                                    {
                                        NomeProduto = p.IdOfertaNavigation.NomeProduto,
                                        Valor = p.IdOfertaNavigation.Valor,
                                        Quantidade = p.IdOfertaNavigation.Quantidade,
                                        DataFabricacao = p.IdOfertaNavigation.DataFabricacao,
                                        DataValidade = p.IdOfertaNavigation.DataValidade,
                                        Descricao = p.IdOfertaNavigation.Descricao,
                                        IdCategoriaNavigation = new Categorium()
                                        {
                                            NomeCategoria = p.IdOfertaNavigation.IdCategoriaNavigation.NomeCategoria
                                        },
                                        IdEmpresaNavigation = new Empresa()
                                        {
                                            NomeEmpresa = p.IdOfertaNavigation.IdEmpresaNavigation.NomeEmpresa
                                        }
                                    }
                                })
                                .ToList();                                
            }
            return null;
        }

        public List<Reserva> ListarTodos()
        {
            return ctx.Reservas.ToList();  
        }
    }
}
