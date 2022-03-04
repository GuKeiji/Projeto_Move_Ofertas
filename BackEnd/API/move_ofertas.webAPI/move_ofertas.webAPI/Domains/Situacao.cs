using System;
using System.Collections.Generic;

#nullable disable

namespace move_ofertas.webAPI.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Oferta = new HashSet<Ofertum>();
            Reservas = new HashSet<Reserva>();
        }

        public byte IdSituacao { get; set; }
        public string NomeSituacao { get; set; }

        public virtual ICollection<Ofertum> Oferta { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
