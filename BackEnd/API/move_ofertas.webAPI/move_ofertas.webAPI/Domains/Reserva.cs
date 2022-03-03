using System;
using System.Collections.Generic;

#nullable disable

namespace move_ofertas.webAPI.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdCliente { get; set; }
        public byte? IdSituacao { get; set; }
        public int? IdOferta { get; set; }
        public DateTime DataReserva { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Ofertum IdOfertaNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
