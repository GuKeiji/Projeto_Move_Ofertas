using System;
using System.Collections.Generic;

#nullable disable

namespace move_ofertas.webAPI.Domains
{
    public partial class Categorium
    {
        public Categorium()
        {
            Oferta = new HashSet<Ofertum>();
        }

        public short IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Ofertum> Oferta { get; set; }
    }
}
