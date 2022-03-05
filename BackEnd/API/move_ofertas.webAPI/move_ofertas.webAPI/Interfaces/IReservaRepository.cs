using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Interfaces
{
    interface IReservaRepository
    {
        List<Reserva> ListarTodos();
        List<Reserva> ListarMinhasReservas(int id, int idTipoUsuario);

        void Cadastrar(Reserva novaReserva);
    }
}
