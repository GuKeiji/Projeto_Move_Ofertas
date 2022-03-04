using System;
using System.Collections.Generic;

#nullable disable

namespace move_ofertas.webAPI.Domains
{
    public partial class Imagemofertum
    {
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public byte[] Binario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public virtual Ofertum IdOfertaNavigation { get; set; }
    }
}
